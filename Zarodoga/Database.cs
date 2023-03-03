using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zarodoga
{
    internal class Database
    {
        static public MySqlCommand cmd;
        static public MySqlConnection connection;
        public Database(string server = "localhost", string user = "root", string password = "", string db = "zaro")
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = server;
            builder.UserID = user;
            builder.Password = password;
            builder.Database = db;
            connection = new MySqlConnection(builder.ConnectionString);
            if (Kapcsolat())
            {
                cmd = connection.CreateCommand();
            }
        }

        private bool Kapcsolat()
        {
            try
            {
                connection.Open();
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        private void Open()
        {

            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }
        }

        private void Close()
        {

            if (connection.State != System.Data.ConnectionState.Closed)
            {
                connection.Close();
            }
        }
        public List<diak> getAllDiak()
        {
            List<diak> list = new List<diak>();
            cmd.CommandText = "SELECT * FROM `diak`;";
            Open();
            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    diak diak = new diak(dr.GetString("Nev"), dr.GetString("Sz_Datum"), dr.GetString("Anyja_Sz_nev"), dr.GetString("Diak_ID"), dr.GetString("osztaly"));
                    list.Add(diak);
                }
            }
            
            Close();
            return list;
        }

    

    }
}
