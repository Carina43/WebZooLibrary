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
    internal class AttendanceRepo : ICollectionRepo<Attendance, int>
    {
        static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB; Database=WebZoo; Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False;Application Name=\"SQL Server Management Studio\";Command Timeout=30";

        public Attendance Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Attendance> GetAll()
        {
            List<Attendance> attendance = new List<Attendance>();
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                string sqlCode = "SELECT id, attendee, event FROM Attendance; ";

                SqlCommand command = new SqlCommand(sqlCode, connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Attendance u = new Attendance(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2));

                    attendance.Add(u);
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
            return attendance;
        }

        public void Add(Attendance u)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                string sqlCode = "INSERT INTO Attendance(attendee, event)" +
                "VALUES (@Attendee, @Event);";

                SqlCommand command = new SqlCommand(sqlCode, connection);

                command.Parameters.AddWithValue("@Attendee", u.Attendee);
                command.Parameters.AddWithValue("@Event", u.EventID);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error:\n{ex}");
            }
            finally
            {
                connection.Close();
            }
        }        

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(Attendance u)
        {
            throw new NotImplementedException();
        }
    }
}
