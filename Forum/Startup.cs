﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Forum.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Forum.DAL.Domain;
using AutoMapper;
using Forum.BLL.Interfaces;
using Forum.BLL.Services;
using Forum.DAL.Repository;
using Newtonsoft.Json.Serialization;
using Cross_cutting.ExceptionHandlingFilter;
using Microsoft.Extensions.Logging;
using Serilog.AspNetCore;
using Serilog.Sinks.File;
using Serilog;

namespace Forum.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) 
        {
            services.AddDbContext<ApplicationDbContext>(options =>
               options
               .UseLazyLoadingProxies()
               .UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                                    b => b.MigrationsAssembly("Forum.DAL")));

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            
            services.AddScoped<DbContext, ApplicationDbContext>();
            services.AddScoped(typeof(IEmailSender), typeof(EmailSender));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ITopicService, TopicService>();
            services.AddScoped<ITopicRepository, TopicRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISubscriptionsRepository, SubscriptionsRepository>();
            services.AddScoped<ISubscriptionService, SubscriptionService>();
            services.Configure<IdentityOptions>(options =>
            {
                // Default Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
            });
            services.AddMvc(opt => opt.Filters.Add(typeof(ErrorHandlerAttribute)))
                .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
            services.AddAutoMapper(x => x.AddProfile(new MapperProfile()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
            IHostingEnvironment env,
            RoleManager<IdentityRole> roleManager,
            UserManager<User> userManager)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            if (!ConfigureRoles(roleManager,userManager).Result)
            {
                throw new Exception("Error on creating roles!");
            }
            
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Admin}/{action=Index}/{id?}"
                );
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                
            });
        }

        private async Task<bool> ConfigureRoles(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            var ownerRoleExists = roleManager.RoleExistsAsync("Owner");
            var adminRoleExists = roleManager.RoleExistsAsync("Admin");
            Task.WaitAll(ownerRoleExists, adminRoleExists);
            List<Task<IdentityResult>> tasks = new List<Task<IdentityResult>>();
            //If role doesn't exist then create
            if (!ownerRoleExists.Result)
                tasks.Add(roleManager.CreateAsync(new IdentityRole("Owner")));
            if (!adminRoleExists.Result)
                tasks.Add(roleManager.CreateAsync(new IdentityRole("Admin")));
            await Task.WhenAll(tasks);
            foreach (var task in tasks)
                if (!task.Result.Succeeded)
                    return false;
            var user = new User
            {
                UserName = Configuration.GetSection("OwnerEmail").Get<string>(),
                FirstName = "Radu",
                LastName = "Cebotari",
                Email = Configuration.GetSection("OwnerEmail").Get<string>()
            };
            await userManager.CreateAsync(user,"30101997aB&");
            var ownerUser = await userManager.FindByEmailAsync(Configuration.GetSection("OwnerEmail").Get<string>());
            var isAlreadyOwner = await userManager.IsInRoleAsync(ownerUser, "Owner");
            IdentityResult result = null;
            if (!isAlreadyOwner)
                result = await userManager.AddToRoleAsync(ownerUser, "Owner");
            if (result != null && !result.Succeeded)
            { 
                return false;
            }
            return true;
        }
    }
}