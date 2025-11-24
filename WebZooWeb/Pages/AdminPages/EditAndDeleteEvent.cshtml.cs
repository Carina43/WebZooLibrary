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
        public int editID { set; get; }

        private readonly EventService _eventService = new EventService();

        [BindProperty]
        public List<Event> Events { get; set; }

        public EditAndDeleteEventModel(EventService eventService)
        {
            _eventService = eventService;
            Events = _eventService.GetAll();
        }
        public void OnGet(int Id)
        {
            editID = Id;
        }

        public IActionResult OnPost(int editID)
        {
            //_eventService.Edit();
            return RedirectToPage("/EventPages/EventOverview");
        }
    }
}
