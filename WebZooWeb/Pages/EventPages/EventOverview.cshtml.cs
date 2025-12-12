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
        public List<Event> Events { get; set; } = new List<Event>();

        public EventOverviewModel(EventService eventService)
        {
            _eventService = eventService;           
        }

        public void OnGet()
        {
            var now = DateOnly.FromDateTime(DateTime.Now);

            List<Event> tempt = _eventService.GetAll();

            foreach (Event e in tempt)
            {
                if (e.Date >= now)
                {
                    Events.Add(e);
                }
            }
        }
    }
}
