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
        public void Diak()
        {
            cmd.CommandText = "SELECT `Nev`,`Sz_Datum`,`Anyja_Sz_nev`,`Diak_ID`,`osztaly` FROM `diak` WHERE Nev LIKE '%%';  ";
            Open();
            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {

                }
            }
            Close();
        }
        
        public List<dock> getAllDock()
        {
            List<dock> list = new List<dock>();
            cmd.CommandText = "SELECT * FROM `dock` JOIN dokumentum USING (Dock_ID)JOIN diak USING (Diak_ID);";
            Open();
            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    dock dock = new dock(dr.GetInt32("ID"), dr.GetString("Diak_ID"), dr.GetInt32("Dock_ID"), dr.GetString("Nev"), dr.GetString("Dock_Nev")); ;
                    list.Add(dock);
                }
            }

            Close();
            return list;
        }

        public List<iratkozas> getAllIrat()
        {
            List<iratkozas> list = new List<iratkozas>();
            cmd.CommandText = " SELECT * FROM `be_ki_iratkozas`JOIN diak USING (Diak_ID)JOIN alt_iskolak USING (Isk_ID);";
            Open();
            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    iratkozas iratkozas = new iratkozas(dr.GetInt16("id"),dr.GetString("Diak_ID"),dr.GetInt16("Isk_ID"),dr.GetString("Ki_Be"), dr.GetString("Datum"),dr.GetString("Isk_nev"), dr.GetString("Nev") );
                    list.Add(iratkozas);
                }
            }

            Close();
            return list;
        }


    }
}
