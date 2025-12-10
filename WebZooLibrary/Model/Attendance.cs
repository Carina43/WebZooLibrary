using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebZooLibrary.Model
{
    public class Attendance
    {
        public int ID { get; set; }
        public string Attendee { get; set; }
        public int EventID { get; set; }

        public Attendance(int id, string attendee, int eventID)
            {
            ID = id;
            Attendee = attendee;
            EventID = eventID; 
            }
    }
}
