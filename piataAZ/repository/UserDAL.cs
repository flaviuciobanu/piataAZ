    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using piataAZ.repository;
namespace piataAZ.repository
{
    class UserDAL : AbstractDAL
    {
        
        public UserDAL() : base()
        {
                    
       
        }

        

        public int login(String username, String password)
        {
            openConnection();

            try
            {
                String sql = "SELECT * FROM Admins WHERE username='" + username + "' AND password='" + password + "'";

                MySqlCommand cmd = new MySqlCommand(sql, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows) { reader.Close(); return 0; }
                else
                {
                    reader.Close();
                    sql = "SELECT * FROM Employees WHERE username='" + username + "' AND password='" + password + "'";
                    cmd = new MySqlCommand(sql, connection);
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows) return 1;
                    else return -1;
                }


            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                connection.Close();

            }
            closeConnection();

            return -1;

        }


         public bool adaugaAngajat(string username, string pass, string nume)
        {
            openConnection();
            String sql = "INSERT INTO Employees (username, password, nume) VALUES ('" + username + "','" + pass + "','" + nume + "');";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            cmd.ExecuteNonQuery();

            closeConnection();
            return true;

        }

         public List<string> getCount()
         {
             List<string> counts = new List<string>();
             try
             {
                 openConnection();
                 String sql = "SELECT emp.username, emp.nrAnunturi FROM employees emp";

                 MySqlCommand cmd = new MySqlCommand(sql, connection);
                 MySqlDataReader reader = cmd.ExecuteReader();
                 if (reader.HasRows)
                 {
                     while (reader.Read())
                     {
                         counts.Add(reader.GetString(0) + " " + reader.GetInt32(1));
                     }
                 }                 
                 closeConnection();
                 return counts;

             }
             catch (Exception e)
             {
                 closeConnection();
                 return null;
             }

         }
    
        
      
        
    }
}
