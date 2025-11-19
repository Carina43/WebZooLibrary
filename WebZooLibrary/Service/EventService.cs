using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebZooLibrary.Repository;
using WebZooLibrary.Model;

namespace WebZooLibrary.Service
{
    public class EventService
    {
        private ICollectionRepo<Event, int> _eventRepo = new EventRepo();


        public List<Event> GetAll()
        {
            return _eventRepo.GetAll();
        }
    }
}
