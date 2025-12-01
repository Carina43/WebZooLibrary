using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebZooWeb.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }

        public IActionResult OnPost()
        {
            if (Username == "admin" && Password == "123")
            {
                HttpContext.Session.SetString("UserRole", "Admin");
                return RedirectToPage("/Index");
            }
            ModelState.AddModelError("", "Invalid Login.");
            return Page();
        }

        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/login");
        }

        public void OnGet()
        {
        }
    }
}
