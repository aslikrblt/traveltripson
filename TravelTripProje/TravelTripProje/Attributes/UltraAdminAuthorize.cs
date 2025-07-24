using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace TravelTripProje.Attributes
{
    public class UltraAdminAuthorize : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            if (!user.Identity.IsAuthenticated)
            {
                context.Result = new RedirectToActionResult("Login", "GirisYap", null);
                return;
            }

            var userRole = user.FindFirst(ClaimTypes.Role)?.Value;

            if (userRole != "UltraAdmin")
            {
                context.Result = new ForbidResult(); // 403 Forbidden
                return;
            }
        }
    }
}
