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
using Forum.DAL.Repository;
using Newtonsoft.Json.Serialization;
using Cross_cutting.ExceptionHandlingFilter;
using Cross_cutting.Interfaces;

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
            services.AddScoped<DbContext, ApplicationDbContext>();
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            services.Scan(scan => scan.FromAssembliesOf(typeof(IRoomService),typeof(IRepository<>))
                          .AddClasses(classes => classes.AssignableTo<IScopedService>())
                          .AsImplementedInterfaces()
                          .WithScopedLifetime());
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
            });
            services.AddMvc(opt => opt.Filters.Add(typeof(ErrorHandlerAttribute)))
                .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
            services.AddAutoMapper(typeof(Startup).Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
                              IHostingEnvironment env)
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
    }
}