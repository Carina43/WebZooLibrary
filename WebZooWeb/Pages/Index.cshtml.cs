using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebZooLibrary.Model;
using WebZooLibrary.Service;

namespace WebZooWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly EventService _eventService = new EventService();


        [BindProperty]
        public DateOnly Today { get; set; }
        [BindProperty]
        public List<Event> Events { get; set; }
        [BindProperty]
        public List<Event> Upcoming { get; set; } = new List<Event>();

        public IndexModel(ILogger<IndexModel> logger, EventService eventService)
        {
            _logger = logger;
            _eventService = eventService;
            Events = _eventService.GetAll();
        }

        public void OnGet()
        {
            Today = DateOnly.FromDateTime(DateTime.Now);
            foreach(Event e in Events)
            {
                if(e.Date >= Today && Upcoming.Count < 2)
                {
                    Upcoming.Add(e);
                }
            }
        }
    }
}
