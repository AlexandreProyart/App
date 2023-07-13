using Microsoft.Data.SqlClient;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormApp_Application
{
    public partial class Form1 : Form
    {
        public string connectionString = "server=localhost;port=3306;userid=app;password=;database=bdd";
        public MySqlConnection connection;

        public string pseudoAdminTextbox;
        public string passwordAdminTextbox;
        public string pseudoAdminBDD;
        public string passwordAdminBDD;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();
                MySqlCommand selectAllUser = new MySqlCommand(); //On crée une nouvelle requête
                selectAllUser.Connection = connection; //On associe la connexion à la bdd à la requête
                selectAllUser.CommandText = "SELECT * FROM User"; //On écrit la requête SQL voulue
                MySqlDataReader reader; //On se prépare à lire les données
                reader = selectAllUser.ExecuteReader(); //On associe la lecture à la reqûete qu'on a préparé avant

                while (reader.Read()) //Lis les valeurs de la table utilisateurs
                {
                        pseudoAdminBDD = Convert.ToString(reader.GetValue(1)); //On récupère la 1ère valeur de la 1ère ligne dans la bdd
                        passwordAdminBDD = Convert.ToString(reader.GetValue(2)); //On récupère la 2ème valeur de la 1ère ligne dans la bdd
                }
                reader.Close(); //On ferme la lecture
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
            finally
            {
                connection.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pseudoAdminTextbox = textBoxPseudo.Text;
            passwordAdminTextbox = textBoxPassword.Text;

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            if (pseudoAdminTextbox == pseudoAdminBDD && passwordAdminTextbox == passwordAdminBDD)
            {
                MessageBox.Show("You are connected as an administrator");
            }
            else
            {
                MessageBox.Show("Error");
            }
            connection.Close();
        }
    }
}
