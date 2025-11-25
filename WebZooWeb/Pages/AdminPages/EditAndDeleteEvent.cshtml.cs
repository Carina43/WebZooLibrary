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
        //public void OnGet()
        //{
        //    //EditID = Id;
        //    Date = DateOnly.FromDateTime(DateTime.Now);
        //}

        public void OnGetModal(int id)
        {
            Debug.WriteLine($"OnGetModal {id}");
            foreach(Event e in Events)
            {
                if(e.Id == id)
                {
                    EditID = e.Id;
                    Name = e.Name;
                    Date = e.Date;
                    StartHour = e.StartHour;
                    EndHour = e.EndHour;
                    MaxAttendents = e.MaxAttendents;
                    CurrentAttendents = e.CurrentAttendents;
                    Description = e.Description;
                    ImgPath = e.ImgPath;
                }
            }
        }

        //public IActionResult OnPostEdit()
        //{

        //    return RedirectToPage("/EditAndDeleteEvent");
        //}

        public IActionResult OnPost(int editID)
        {
            //_eventService.Edit();
            return RedirectToPage("/EventPages/EventOverview");
        }
    }
}
