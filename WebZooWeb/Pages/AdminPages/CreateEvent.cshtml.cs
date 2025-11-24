using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebZooLibrary.Service;
using WebZooLibrary.Model;

namespace WebZooWeb.Pages.AdminPages
{
    public class CreateEventModel : PageModel
    {
        private readonly EventService _eventService = new EventService();
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        [BindProperty]
        public TimeOnly StartHour { get; set; } = new TimeOnly(14, 0, 0);
        [BindProperty]
        public TimeOnly EndHour { get; set; } = new TimeOnly(20,0,0);
        [BindProperty]
        public int MaxAttendents { get; set; }
        [BindProperty]
        public int CurrentAttendents { get; set; }
        [BindProperty]
        public string Description { get; set; }
        [BindProperty]
        public string ImgPath { get; set; }

        public CreateEventModel(EventService eventService)
        {
            _eventService = eventService;
        }

        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            _eventService.Add(Name, Date, StartHour, EndHour, MaxAttendents, CurrentAttendents, Description, ImgPath);
            return RedirectToPage ("/CreateEvent");
        }
    }
}
