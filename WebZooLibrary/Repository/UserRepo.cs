using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using WebZooLibrary.Model;

namespace WebZooLibrary.Repository
{
    public class UserRepo : ICollectionRepo<User, string>
    {
        static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB; Database=WebZoo; Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False;Application Name=\"SQL Server Management Studio\";Command Timeout=30";

        public User Get(string id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            List<User> users = new List<User>();
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                string sqlCode = "SELECT id, password, isAdmin FROM Student; ";

                SqlCommand command = new SqlCommand(sqlCode, connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    User u = new User(reader.GetString(0), reader.GetString(1), reader.GetBoolean(2));

                    users.Add(u);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error:\n" + ex);
            }
            finally
            {
                connection.Close();
            }
            return users;
        }

        public void Add(User u)
        {
            throw new NotImplementedException();
        }

        public void Remove(string id)
        {
            throw new NotImplementedException();
        }

        public void Edit(User u)
        {
            throw new NotImplementedException();
        }
    }
}
