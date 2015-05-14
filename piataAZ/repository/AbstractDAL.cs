using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Diagnostics;


namespace piataAZ.repository
{
   public abstract class AbstractDAL
    {
       protected MySqlConnection connection;
        
       public AbstractDAL(){
           string connectionString = String.Format("server={0};user id={1}; password={2}; database={3}; pooling=false", "localhost", "root",
                "","mydb");

            connection = new MySqlConnection(connectionString);          

       }
       protected bool openConnection()
       {
           try
           {
               connection.Open();
               return true;
           }
           catch (MySqlException ex)
           {

               switch (ex.Number)
               {
                   case 0:
                       Debug.WriteLine("Cannot connect to server");
                       break;

                   case 1045:
                       Debug.WriteLine("Invalid username/password, please try again");
                       break;

               }
               return false;
           }
       }

        protected void closeConnection()
        {
            connection.Close();
        }
    }
}
