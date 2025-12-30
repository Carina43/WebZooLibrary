using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebZooLibrary.Model
{
    public class Event : IComparable<Event>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly StartHour { get; set; }
        public TimeOnly EndHour { get; set; }
        public int MaxAttendents { get; set; }
        public int CurrentAttendents { get; set; }
        public string Description { get; set; }
        public string ImgPath { get; set; }

        public Event(int id, string name, DateOnly date, TimeOnly starthour, TimeOnly endhour, int maxattendents, int currentattendents, string description, string imgpath)
        {
            Id = id;
            Name = name;
            Date = date;
            StartHour = starthour;
            EndHour = endhour;
            MaxAttendents = maxattendents;
            CurrentAttendents = currentattendents;
            Description = description;
            ImgPath = imgpath;
        }

        public int CompareTo(Event other)
        {
            if (other == null) return 1;

            int dateComparison = Date.CompareTo(other.Date);
            if (dateComparison != 0) return dateComparison;

            int timeComparison = StartHour.CompareTo(other.StartHour);
            if (timeComparison != 0) return timeComparison;

            return Id.CompareTo(other.Id);
        }
    }
}
