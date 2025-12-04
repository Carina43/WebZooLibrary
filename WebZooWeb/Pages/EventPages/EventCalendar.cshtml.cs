using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebZooLibrary.Service;
using WebZooLibrary.Model;
using System.Diagnostics;

namespace WebZooWeb.Pages.EventPages
{
    public class EventCalendarModel : PageModel
    {
        private readonly EventService _eventService = new EventService();

        [BindProperty]
        public List<Event> Events { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Today { get; set; }
        public int NextMonth { get; set; }
        public int NextYear { get; set; }
        [BindProperty]
        public int EventID { set; get; }
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

        public EventCalendarModel(EventService eventService)
        {
            _eventService = eventService;
            Events = _eventService.GetAll();
            foreach (Event e in Events)
            {
                Debug.WriteLine($"Events: {e.Name}");
            }
        }

        public void OnGet()
        {
            var now = DateTime.Now;
            Year = now.Year;
            Month = now.Month;
            Today = now.Day;
            NextYear = Year;
            NextMonth = Month + 1;
            if(NextMonth == 13) { NextMonth = 1; NextYear++; }


        }

        public IActionResult OnPostSignUp()
        {   
            Debug.WriteLine($"EVentID: {EventID}"); 
            Event ev = _eventService.Get(EventID);
            ev.CurrentAttendents++;
            _eventService.Edit(ev);

            return RedirectToPage("/EventPages/EventCalendar");
        }
    }
}
