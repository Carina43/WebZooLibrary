using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebZooLibrary.Service;
using WebZooLibrary.Model;

namespace WebZooWeb.Pages.EventPages
{
    public class EventOverviewModel : PageModel
    {
        private EventService _eventService = new EventService();

        [BindProperty]
        public List<Event> Events { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Today { get; set; }

        public EventOverviewModel(EventService eventService)
        {
            _eventService = eventService;
            Events = _eventService.GetAll();
           
        }

        public void OnGet()
        {
            var now = DateOnly.FromDateTime(DateTime.Now);
            Year = now.Year;
            Month = now.Month;
            Today = now.Day;

            List<Event> tempt = Events;

            foreach (Event e in tempt)
            {
                if (e.Date < now)
                {
                    Events.Remove(e);
                }
            }
        }
    }
}
