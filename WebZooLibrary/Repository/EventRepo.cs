using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using WebZooLibrary.Model;

namespace WebZooLibrary.Repository
{
    public class EventRepo : ICollectionRepo<Event, int>
    {
        static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB; Database=WebZoo; Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False;Application Name=\"SQL Server Management Studio\";Command Timeout=30";

        public Event Get(int id)
        {
           throw new NotImplementedException();
        }

        public List<Event> GetAll()
        {
            List<Event> events = new List<Event>();

            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();

                string sqlCode = "SELECT id, name, date, starthour, endhour, maxattendents, currentattendents, description, imgpath FROM Event; ";

                SqlCommand command = new SqlCommand(sqlCode, connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Event e = new Event(reader.GetInt32(0), reader.GetString(1), DateOnly.FromDateTime(reader.GetDateTime(2)), TimeOnly.FromTimeSpan(reader.GetTimeSpan(3)), TimeOnly.FromTimeSpan(reader.GetTimeSpan(4)), reader.GetInt32(5), reader.GetInt32(6), reader.GetString(7), reader.GetString(8));
                     
                    events.Add(e);
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

            return events;
        }
        public void Add(Event item) { }
        public void Remove(int id) { }
        public void Edit(Event item) { }
    }
}
