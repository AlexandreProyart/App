using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormApp_Application
{
    public partial class Form2 : Form
    {
        public string connectionString;
        public string role;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            labelRole.Text = role;

            if (role == "Admin")
            {
                labelRole.ForeColor = Color.DarkOliveGreen;
            }
        }

        private void Form2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void accueilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Form.ActiveForm.Close(); Ferme la form active
        }
    }
}
