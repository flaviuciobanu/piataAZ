using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace piataAZ.repository
{
    class AnuntDAL : AbstractDAL
    {
        public AnuntDAL() : base() { }

        public MySqlDataAdapter findAnunturi(string username)
        {
           
            try
            {
                openConnection();
                String sql = "SELECT * FROM anunturi anunt where anunt.username = '" + username + "'" ;

                MySqlCommand cmd = new MySqlCommand(sql, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);                
                closeConnection();
                return adapter;

            }
            catch (Exception e)
            {
                closeConnection();
                return null;
            }

        }

        public bool adaugaAnunt(string username, string titlu, string descriere, string poza)
        {
            openConnection();
            String sql = "INSERT INTO Anunturi (titlu, descriere, poza, username) VALUES ('" + titlu + "','" + descriere + "','" + poza + "','" +  username + "');";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            cmd.ExecuteNonQuery();
            sql = "UPDATE Employees SET nrAnunturi = nrAnunturi + 1 WHERE  username='" + username + "'";
            cmd = new MySqlCommand(sql, connection);
            cmd.ExecuteNonQuery();

            closeConnection();
            return true;

        }
        public void stergeAnunt(int id)
        {
            openConnection();
           
           String sql = "DELETE FROM Anunturi WHERE  id='" + id + "'";
           MySqlCommand cmd = new MySqlCommand(sql, connection);
            cmd.ExecuteNonQuery();

            closeConnection();
          

        }
    }
}
