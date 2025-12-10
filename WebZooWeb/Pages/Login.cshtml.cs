using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebZooLibrary.Service;
using WebZooWeb.Helpers;

namespace WebZooWeb.Pages
{
    public class LoginModel : PageModel
    {
        private readonly UserService _userService = new UserService();

        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }


        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            foreach(var user in _userService.GetAllUsers())
            {
                if (Username == user.ID && Password == user.Password && user.IsAdmin)
                {
                    HttpContext.Session.SetString("UserRole", "Admin");
                    HttpContext.Session.SetString("UserID", Username);

                    return RedirectToPage("/Index");
                }
                else if(Username == user.ID && Password == user.Password && !user.IsAdmin)
                {
                    HttpContext.Session.SetString("UserRole", "User");
                    HttpContext.Session.SetString("UserID", Username);

                    return RedirectToPage("/Index");
                }
            }
            TempData["Message"] = "Ugyldigt log ind!";
            return Page();
        }

        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }

       
    }
}
