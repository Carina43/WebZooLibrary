using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebZooLibrary.Service;
using WebZooLibrary.Model;
using WebZooWeb.Helpers;

namespace WebZooWeb.Pages.AdminPages
{
    public class CreateEventModel : PageModel
    {
        private readonly EventService _eventService = new EventService();
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public DateOnly Date { get; set; } 
        [BindProperty]
        public TimeOnly StartHour { get; set; } = new TimeOnly(14, 0, 0);
        [BindProperty]
        public TimeOnly EndHour { get; set; } = new TimeOnly(20,0,0);
        [BindProperty]
        public int MaxAttendents { get; set; } = 50;
        [BindProperty]
        public int CurrentAttendents { get; set; } = 2;
        [BindProperty]
        public string Description { get; set; } 
        [BindProperty]
        public string ImgPath { get; set; } = "";

        public CreateEventModel(EventService eventService)
        {
            _eventService = eventService;
        }

        public IActionResult OnGet()
        {
            Date = DateOnly.FromDateTime(DateTime.Now);
            if (!AuthHelper.IsAdmin(HttpContext))
            {
                return RedirectToPage("/Login");
            }
            return Page();
        }


        public IActionResult OnPost()
        {
            if (Date < DateOnly.FromDateTime(DateTime.Now))
            {
                return Page();
            }

            if(Name == null) { Name = "Fredagsbar"; }
            if(Description == null) { Description = "info kommer senere.."; }
            _eventService.Add(Name, Date, StartHour, EndHour, MaxAttendents, CurrentAttendents, Description, ImgPath);
            return RedirectToPage ("/AdminPages/CreateEvent");
        }
    }
}
