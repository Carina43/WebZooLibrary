using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebZooLibrary.Repository;
using WebZooLibrary.Model;
using System.Diagnostics;

namespace WebZooLibrary.Service
{
    public class UserService
    {
        private ICollectionRepo<User, string> _userRepo = new UserRepo();
        private ICollectionRepo<Attendance, int> _attendanceRepo = new AttendanceRepo();

        public List<User> GetAllUsers()
        {
            return _userRepo.GetAll();
        }

        public List<Attendance> GetAllAttendances()
        {
            return _attendanceRepo.GetAll();
        }

        public bool CheckAttendance(string user, int eventID)
        {
            var userAttendance = GetAllAttendances().Where(a => a.Attendee == user);

            if (!userAttendance.Any())
            {
                return true;
            }

            foreach (var a in userAttendance)
            {
                Debug.WriteLine($"CHECKATT: {a.EventID} - {a.Attendee}");

                if (a.EventID == eventID)
                {
                    Debug.WriteLine($"CHECKATT: {eventID} fundet!");

                    return false;
                }
            }

            return true;
        }

        public void AttendEvent(string user, int eventID)
        {
            _attendanceRepo.Add(new Attendance(1, user, eventID));
        }
    }
}
