using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Linq;
using System.Text;

namespace Cross_cutting.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            return principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
        public static string GetUserRole(this ClaimsPrincipal principal)
        {
            var role = principal.Claims.Where(p => p.Type == ClaimTypes.Role)
                             .Select(p => p.Value).FirstOrDefault();
            if (role == null)
                return "Simple User";
            return role;
        }
        public static bool IsAdmin(this ClaimsPrincipal principal)
        {
            var role = GetUserRole(principal);
            if (role == "Admin" || role == "Owner")
                return true;
            return false;
        }
    }
}
