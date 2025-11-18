using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebZooLibrary.Model;

namespace WebZooLibrary.Repository
{
    public class EventRepo : ICollectionRepo<Event, int>
    {
        public Event Get(int id)
        {
           throw new NotImplementedException();
        }
        public List<Event> GetAll()
        {
            throw new NotImplementedException();
        }
        public void Add(Event item) { }
        public void Remove(int id) { }
        public void Edit(Event item) { }
    }
}
