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
        EventService eventService = new EventService();

        [TestMethod]
        public void GetAll_GetEventsFromDB_EventList()
        {
            // Arrange
            List<Event> events = new List<Event>();

            // Act
            events = eventService.GetAll();

            // Assert
            Assert.IsTrue(events.Count() > 0);
        }

        [TestMethod]
        public void Get_GetByID_ChosenEvent()
        {
            // Arrange 
            Event expected = eventService.GetAll().First();

            // Act 
            Event actual = eventService.Get(expected.Id);

            // Assert
            Assert.AreEqual(expected.Id, actual.Id);
        }
    }
}
