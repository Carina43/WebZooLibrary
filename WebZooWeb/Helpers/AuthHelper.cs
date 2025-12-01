using static System.Net.WebRequestMethods;

namespace WebZooWeb.Helpers
{
    public class AuthHelper
    {
        public static bool IsAdmin(HttpContext ctx)
            => ctx.Session.GetString("UserRole") == "Admin";
    }
}
