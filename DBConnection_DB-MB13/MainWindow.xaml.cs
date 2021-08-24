using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace DBConnection_DB_MB13
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txtOutput.Text = "";
            string connStr = "server=localhost;user=root;database=sqlteacherdb;port=3306;password=root";
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                conn.Open();


                //3.) SQL - Kommandos ausführen
                string sql = "SELECT MITARBEITERNR, VORNAME, `NAME` FROM mitarbeiter";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    txtOutput.Text = txtOutput.Text + rdr[0] + " | " + rdr[1] + " " + rdr[2] + "\r\n";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                try
                {
                    conn.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Problem beim schlissen der Datenbank Verbindung.");
                }
            }
        }
    }
}
