using System.Security.Claims;
using System.Security.Principal;
using System.Web;
namespace FitnessTracker.Helpers
{
    public static class UserHelpers
    {
        public static int GetUserId(this IPrincipal principal)
        {
            var claimsIdentity = (ClaimsIdentity)principal.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            return int.Parse(claim.Value);
        }

        public static string GetUsername(this IPrincipal principal)
        {

            var claimsIdentity = (ClaimsIdentity)principal.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.Name);
            return claim.Value;
        }

    }
}
