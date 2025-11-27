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

        public void Add(string name, DateOnly date, TimeOnly startHour, TimeOnly endHour, int maxAttendents, int currentAttendents, string description, string imgPath)
        {
            _eventRepo.Add(new Event(0, name, date, startHour, endHour, maxAttendents, currentAttendents, description, imgPath));
        }
        public void Edit(Event item)
        {
             _eventRepo.Edit(item);
        }
        public void Remove(int id)
        {
            _eventRepo.Remove(id);
        }
    }
}
