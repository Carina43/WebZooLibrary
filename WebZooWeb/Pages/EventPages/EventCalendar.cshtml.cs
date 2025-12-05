using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebZooLibrary.Service;
using WebZooLibrary.Model;
using System.Diagnostics;
using WebZooWeb.Helpers;

namespace WebZooWeb.Pages.EventPages
{
    public class EventCalendarModel : PageModel
    {
        private readonly EventService _eventService = new EventService();

        [BindProperty]
        public List<Event> Events { get; set; } = new List<Event>();
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
            //Events = _eventService.GetAll();
            foreach (Event e in Events)
            {
                Debug.WriteLine($"Events: {e.Name}");
            }
        }

        public void OnGet()
        {
            var now = DateOnly.FromDateTime(DateTime.Now);
            Year = now.Year;
            Month = now.Month;
            Today = now.Day;
            NextYear = Year;
            NextMonth = Month + 1;
            if (NextMonth == 13) { NextMonth = 1; NextYear++; }

            List<Event> tempt = _eventService.GetAll();

            foreach (Event e in tempt)
            {
                if (e.Date >= now)
                {
                    Events.Add(e);
                }
            }
        }

        public IActionResult OnPostSignUp()
        {
            if (AuthHelper.IsUser(HttpContext) || AuthHelper.IsAdmin(HttpContext))
            {
                Event ev = _eventService.Get(EventID);

                if (ev.CurrentAttendents < ev.MaxAttendents)
                {
                    ev.CurrentAttendents++;
                    _eventService.Edit(ev);
                    TempData["Message"] = "Du er nu tilmeldt!";
                }
                //for (int i = ev.CurrentAttendents; i < (ev.MaxAttendents); i++)
                //{
                //    ev.CurrentAttendents++;
                //    _eventService.Edit(ev);
                //}
                //Debug.WriteLine($"EVentID: {EventID}");
                else
                {
                    TempData["Message"] = "Ikke tilmeldt, da kapacitet er fuld";
                }
              

            }

            return RedirectToPage("/EventPages/EventCalendar");



        }
    }
}
