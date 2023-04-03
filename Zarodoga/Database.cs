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

        public bool Kapcsolat()
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
        public void Open()
        {

            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }
        }

        public void Close()
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
        public  List<diak> Diak()
        {
            Kapcsolat();
            Open();
            List<diak> list1 = new List<diak>();
            cmd.CommandText = "SELECT `Nev`,`Sz_Datum`,`Anyja_Sz_nev`,`Diak_ID`,`osztaly` FROM `diak` WHERE Nev LIKE '%@nev%';  ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@nev",Program.AllDiak.textBox_nev.Text);
            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    diak diak1 = new diak(dr.GetString("Nev"), dr.GetString("Sz_Datum"), dr.GetString("Anyja_Sz_nev"), dr.GetString("Diak_ID"), dr.GetString("osztaly"));
                    list1.Add(diak1);

                }
            }
            
            Close();
            return list1;
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
 
        public void Be_Ki_Insert() 
        {
            Kapcsolat();
            Open();
            int altisk = 0;

            cmd.CommandText = "SELECT `Isk_ID` FROM `alt_iskolak` WHERE `Isk_nev` = @Isk_nev;";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Isk_nev", Program.Be_Ki_Iratkozas.comboBox_isk_nev.SelectedItem);
            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    altisk = dr.GetInt32("Isk_ID");
                    
                }
               
            }


            cmd.CommandText = "INSERT INTO `be_ki_iratkozas`(`Diak_ID`, `Isk_ID`, `Ki_Be`, `Datum`) VALUES (@Diak_ID, @Isk_ID, @Ki_Be, @Datum)";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Diak_ID", Program.Be_Ki_Iratkozas.textBox_IG_szam.Text);
            cmd.Parameters.AddWithValue("@Isk_ID", altisk);
            cmd.Parameters.AddWithValue("@Ki_Be", Program.Be_Ki_Iratkozas.comboBox_ki_be.SelectedItem);
            cmd.Parameters.AddWithValue("@Datum", Program.Be_Ki_Iratkozas.textBox_datum.Text);



            try
            {
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Sikeres adat rögzítés");
                    Program.Be_Ki_Iratkozas.textBox_IG_szam.Text = "";
                    Program.Be_Ki_Iratkozas.textBox_nev.Text = "";
                    Program.Be_Ki_Iratkozas.comboBox_isk_nev.Text = "";
                    Program.Be_Ki_Iratkozas.comboBox_ki_be.Text = "";
                    Program.Be_Ki_Iratkozas.textBox_datum.Text = "";
                }
                else
                {
                    MessageBox.Show("Sikertelen adat rögzítés");


                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            Close();

        }
        public void Be_Ki_Delete() 
        {
            Kapcsolat();
            Open();

            cmd.CommandText = "DELETE FROM `be_ki_iratkozas` WHERE `Diak_ID` =@diakid ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@diakid",Program.Be_Ki_Iratkozas.textBox_IG_szam.Text);
            try
            {
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Sikeres adat rögzítés");
                    Program.Be_Ki_Iratkozas.textBox_IG_szam.Text = "";
                    Program.Be_Ki_Iratkozas.textBox_nev.Text = "";
                    Program.Be_Ki_Iratkozas.comboBox_isk_nev.Text = "";
                    Program.Be_Ki_Iratkozas.comboBox_ki_be.Text = "";
                    Program.Be_Ki_Iratkozas.textBox_datum.Text = "";
                }
                else
                {
                    MessageBox.Show("Sikertelen adat rögzítés");


                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            Close();
        }
        public void Be_Ki_Update() 
        {
            Kapcsolat();
            Open();
            int altisk = 0;

            cmd.CommandText = "SELECT `Isk_ID` FROM `alt_iskolak` WHERE `Isk_nev` = @Isk_nev;";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Isk_nev", Program.Be_Ki_Iratkozas.comboBox_isk_nev.SelectedItem);
            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    altisk = dr.GetInt32("Isk_ID");

                }
            }
            cmd.Parameters.Clear();
            string diakid = Program.Be_Ki_Iratkozas.textBox_IG_szam.Text;
            cmd.CommandText =  $"UPDATE `be_ki_iratkozas` SET `Diak_ID`=@diakid,`Isk_ID`=@altisk,`Ki_Be`=@ki_be,`Datum`=@datum WHERE `Diak_ID` = {diakid}";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@diakid",Program.Be_Ki_Iratkozas.textBox_IG_szam.Text);
            cmd.Parameters.AddWithValue("@altisk", altisk);
            cmd.Parameters.AddWithValue("@ki_be",Program.Be_Ki_Iratkozas.comboBox_ki_be.SelectedItem);
            cmd.Parameters.AddWithValue("@datum",Program.Be_Ki_Iratkozas.textBox_datum.Text);
            try
            {
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Sikeres adat rögzítés");
                    Program.Be_Ki_Iratkozas.textBox_IG_szam.Text = "";
                    Program.Be_Ki_Iratkozas.textBox_nev.Text = "";
                    Program.Be_Ki_Iratkozas.comboBox_isk_nev.Text = "";
                    Program.Be_Ki_Iratkozas.comboBox_ki_be.Text = "";
                    Program.Be_Ki_Iratkozas.textBox_datum.Text = "";
                }
                else
                {
                    MessageBox.Show("Sikertelen adat rögzítés");


                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            Close();
        }
   
        public void Dock_Inser()
        {
            Kapcsolat();
            Open();
            int dockID = 0;
            
            cmd.CommandText = "SELECT `DocK_ID` FROM `dokumentum` WHERE `Dock_Nev` = @dockid;";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@dockid",Program.Dock_Form.comboBox_dock_nev.SelectedItem);
            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    dockID = dr.GetInt16("DocK_ID");

                }
            }

            cmd.CommandText = "INSERT INTO `dock`( `Diak_ID`, `Dock_ID`) VALUES (@diakid,@dockid)";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@diakid",Program.Dock_Form.textBox_ig_szam.Text);
            cmd.Parameters.AddWithValue("dockid",dockID);

            try
            {
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Sikeres adat rögzítés");
                    Program.Dock_Form.comboBox_dock_nev.Text = "";
                    Program.Dock_Form.textBox_ig_szam.Text = "";
                }
                else
                {
                    MessageBox.Show("Sikertelen adat rögzítés");


                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            Close();
        }
        public void Dock_Delete() 
        {
            Kapcsolat();
            Open();
            cmd.CommandText = "DELETE FROM `dock` WHERE `Diak_ID` = @diakid";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@diakid", Program.Dock_Form.textBox_ig_szam.Text);
            try
            {
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Sikeres adat rögzítés");
                    Program.Dock_Form.comboBox_dock_nev.Text = "";
                    Program.Dock_Form.textBox_ig_szam.Text = "";
                }
                else
                {
                    MessageBox.Show("Sikertelen adat rögzítés");


                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            Close();
        }
        public void Dock_Update() 
        {
            Kapcsolat();
            Open();
            int dockID = 0;
            cmd.CommandText = "SELECT `DocK_ID` FROM `dokumentum` WHERE `Dock_Nev` = @dockid;";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@dockid", Program.Dock_Form.comboBox_dock_nev.SelectedItem);
            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    dockID = dr.GetInt32("DocK_ID");
                   
                }
                
            }
           

            cmd.Parameters.Clear();
            string diakid = Program.Dock_Form.textBox_ig_szam.Text;
            cmd.CommandText = $"UPDATE `dock` SET `Diak_ID`=@diakid,`Dock_ID`=@dockid WHERE `Diak_ID`={diakid}";       
            cmd.Parameters.AddWithValue("@diakid",Program.Dock_Form.textBox_ig_szam.Text);
            cmd.Parameters.AddWithValue("@dockid",dockID);
            try
            {
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Sikeres adat módosítás");
                    Program.Dock_Form.comboBox_dock_nev.Text = "";
                    Program.Dock_Form.textBox_ig_szam.Text = "";
                }
                else
                {
                    MessageBox.Show("Sikertelen adat  módosítás");


                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            Close();

        }

        public void Diak_Insert() 
        {
            Kapcsolat();


            cmd.CommandText = "INSERT INTO `diak`(`Nev`, `Sz_Datum`, `Anyja_Sz_nev`, `Diak_ID`, `osztaly`) VALUES (@nev,@sz_datum,@anyja_sz_nev,@diakid,@osztaly)";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@nev",Program.AllDiak.textBox_nev.Text);
            cmd.Parameters.AddWithValue("@sz_datum", Program.AllDiak.textBoxSzdatum.Text);
            cmd.Parameters.AddWithValue("anyja_sz_nev", Program.AllDiak.textBoxanyjanev.Text);
            cmd.Parameters.AddWithValue("@diakid", Program.AllDiak.textBoxigszam.Text);
            cmd.Parameters.AddWithValue("@osztaly", Program.AllDiak.textBoxosztaly.Text);
            Open();
            try
            {
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Sikeres adat rögzítés");
                    Program.AllDiak.textBox_nev.Text = "";
                    Program.AllDiak.textBoxSzdatum.Text = "";
                    Program.AllDiak.textBoxanyjanev.Text = "";
                    Program.AllDiak.textBoxigszam.Text = "";
                    Program.AllDiak.textBoxosztaly.Text = "";
                }
                else
                {
                    MessageBox.Show("Sikertelen adat rögzítés");


                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            Close();
        }
        public void Diak_Delete() 
        {
            Kapcsolat();
            Open();

            cmd.CommandText = "DELETE FROM `diak` WHERE `Diak_ID` = @diakid;";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@diakid",Program.AllDiak.textBoxigszam.Text);
            try
            {
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Sikeres adat törlés");
                    Program.AllDiak.textBox_nev.Text = "";
                    Program.AllDiak.textBoxSzdatum.Text = "";
                    Program.AllDiak.textBoxanyjanev.Text = "";
                    Program.AllDiak.textBoxigszam.Text = "";
                    Program.AllDiak.textBoxosztaly.Text = "";
                }
                else
                {
                    MessageBox.Show("Sikertelen adat törlés");


                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            Close();
        }
        public void Diak_Update() 
        {
            Kapcsolat();
            Open();
            cmd.Parameters.Clear();
            string diakid = Program.AllDiak.textBoxigszam.Text;
            cmd.CommandText = $"UPDATE `diak` SET `Nev`=@nev,`Sz_Datum`=@szdatum,`Anyja_Sz_nev`=@anyjasznev,`Diak_ID`=@diakid,`osztaly`=@osztaly WHERE `Diak_ID`={diakid}";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@nev",Program.AllDiak.textBox_nev.Text);
            cmd.Parameters.AddWithValue("@szdatum",Program.AllDiak.textBoxSzdatum.Text);
            cmd.Parameters.AddWithValue("@anyjasznev",Program.AllDiak.textBoxanyjanev.Text);
            cmd.Parameters.AddWithValue("@diakid",Program.AllDiak.textBoxigszam.Text);

            cmd.Parameters.AddWithValue("@osztaly",Program.AllDiak.textBoxosztaly.Text);
            try
            {
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Sikeres adat módosítás");
                    Program.AllDiak.textBox_nev.Text = "";
                    Program.AllDiak.textBoxSzdatum.Text = "";
                    Program.AllDiak.textBoxanyjanev.Text = "";
                    Program.AllDiak.textBoxigszam.Text = "";
                    Program.AllDiak.textBoxosztaly.Text = "";
                }
                else
                {
                    MessageBox.Show("Sikertelen adat modosítás");


                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            Close();
        }


    }
}
