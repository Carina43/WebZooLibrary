using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using System.Runtime;
using WebZooLibrary.Model;
using WebZooLibrary.Service;
using WebZooWeb.Helpers;

namespace WebZooWeb.Pages.AdminPages
{
    public class EditAndDeleteEventModel : PageModel
    {
        private readonly EventService _eventService = new EventService();

        [BindProperty]
        public int EditID { set; get; }
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public DateOnly Date { get; set; }
        [BindProperty]
        public TimeOnly StartHour { get; set; }
        [BindProperty]
        public TimeOnly EndHour { get; set; }
        [BindProperty]
        public int MaxAttendents { get; set; } 
        [BindProperty]
        public int CurrentAttendents { get; set; } 
        [BindProperty]
        public string Description { get; set; }
        [BindProperty]
        public string ImgPath { get; set; } = "/images/flamingopartyone.jpg";
        [BindProperty]
        public List<Event> Events { get; set; }


        public EditAndDeleteEventModel(EventService eventService)
        {
            _eventService = eventService;
            Events = _eventService.GetAll();
        }
        public IActionResult OnGet()
        {
            if (!AuthHelper.IsAdmin(HttpContext))
            {
                return RedirectToPage("/Login");
            }
            return Page();
        }

        public IActionResult OnPostEdit()
        {
            if (Date < DateOnly.FromDateTime(DateTime.Now))
            {
                TempData["Message"] = "Du kan ikke redigere events til tidligere end i dag";
                return RedirectToPage("/AdminPages/EditAndDeleteEvent");
            }
            else if(ImgPath == null)
            {
                ImgPath = "/images/flamingopartyone.jpg";
            }
            Debug.WriteLine($"PostEdit: {EditID}");
            _eventService.Edit(new Event(EditID, Name, Date, StartHour, EndHour, MaxAttendents, CurrentAttendents, Description, ImgPath));
            TempData["Message"] = "Event Redigeret";
            return RedirectToPage("/AdminPages/EditAndDeleteEvent");
        }

        public IActionResult OnPostRemove()
        {
            _eventService.Remove(EditID);
            TempData["Message"] = "Event Slettet!";

            return RedirectToPage("/AdminPages/EditAndDeleteEvent");
        }
    }
}
