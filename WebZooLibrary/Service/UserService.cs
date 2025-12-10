using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebZooLibrary.Repository;
using WebZooLibrary.Model;

namespace WebZooLibrary.Service
{
    public class UserService
    {
        private ICollectionRepo<User, string> _userRepo = new UserRepo();
        //private ICollectionRepo<Attendance, int> _attendanceRepo = new AttendanceRepo();

        public List<User> GetAllUsers()
        {
            return _userRepo.GetAll();
        }
    }
}
