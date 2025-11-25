using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using System.Runtime;
using WebZooLibrary.Model;
using WebZooLibrary.Service;

namespace WebZooWeb.Pages.AdminPages
{
    public class EditAndDeleteEventModel : PageModel
    {
        [BindProperty]
        public int EditID { set; get; }
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public DateOnly Date { get; set; }
        [BindProperty]
        public TimeOnly StartHour { get; set; } = new TimeOnly(14, 0, 0);
        [BindProperty]
        public TimeOnly EndHour { get; set; } = new TimeOnly(20, 0, 0);
        [BindProperty]
        public int MaxAttendents { get; set; } = 50;
        [BindProperty]
        public int CurrentAttendents { get; set; } = 2;
        [BindProperty]
        public string Description { get; set; } = "";
        [BindProperty]
        public string ImgPath { get; set; } = "";

        private readonly EventService _eventService = new EventService();

        [BindProperty]
        public List<Event> Events { get; set; }

        public EditAndDeleteEventModel(EventService eventService)
        {
            _eventService = eventService;
            Events = _eventService.GetAll();
        }
        public void OnGet()
        {

        }

        public IActionResult OnPostEdit()
        {
            Debug.WriteLine($"PostEdit: {EditID}");
            _eventService.Edit(new Event(EditID, Name, Date, StartHour, EndHour, MaxAttendents, CurrentAttendents, Description, ImgPath));
            return Page();
        }

        //public IActionResult OnPost(int editID)
        //{
        //    _eventService.Edit();
        //    return RedirectToPage("/EventPages/EventOverview");
        //}
    }
}
