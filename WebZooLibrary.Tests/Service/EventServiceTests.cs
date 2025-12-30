using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebZooLibrary.Service;
using WebZooLibrary.Model;

namespace WebZooLibrary.Tests.Service
{
    [TestClass]
    public class EventServiceTests
    {
        [TestMethod]
        public void GetAll_GetEventsFromDB_EventList()
        {
            // Arrange
            EventService eventService = new EventService();
            List<Event> events = new List<Event>();

            // Act
            events = eventService.GetAll();

            // Assert
            Assert.IsTrue(events.Count() > 0);
        }
    }
}
