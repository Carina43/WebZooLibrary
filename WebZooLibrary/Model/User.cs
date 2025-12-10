using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebZooLibrary.Model
{
    public class User
    {
        public string ID { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        public User(string id, string password, bool isAdmin)
        {
            ID = id; 
            Password = password;
            IsAdmin = isAdmin;
        }
    }
}
