using static System.Net.WebRequestMethods;

namespace WebZooWeb.Helpers
{
    public class AuthHelper
    {
        public static bool IsAdmin(HttpContext ctx)
            => ctx.Session.GetString("UserRole") == "Admin";

        public static bool IsUser(HttpContext ctx)
            => ctx.Session.GetString("UserRole") == "User";

        public static string GetUserID(HttpContext ctx)
        {
            return ctx.Session.GetString("UserID");
        }
    }
}
