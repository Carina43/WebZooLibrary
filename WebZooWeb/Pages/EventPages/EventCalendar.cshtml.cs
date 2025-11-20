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

        public EventCalendarModel(EventService eventService)
        {
            _eventService = eventService;
            Events = _eventService.GetAll();
        }

        public void OnGet()
        {
            var now = DateTime.Now;
            Year = now.Year;
            Month = now.Month;
            Today = now.Day;
            NextYear = Year;
            NextMonth = Month++;
            if(NextMonth == 13) { NextMonth = 1; NextYear++; }
        }
    }
}
