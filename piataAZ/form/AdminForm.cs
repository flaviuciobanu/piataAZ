using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using piataAZ.repository;
namespace piataAZ
{
    public partial class AdminForm : Form
    {
        private String  username;
        private UserDAL userDAL;
        public AdminForm(string username)
        {
            this.username = username;
            this.userDAL = new UserDAL();
           
            InitializeComponent();
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            String username = textBox1.Text;
            String pass = textBox2.Text;
            String nume = textBox3.Text;
            
            userDAL.adaugaAngajat(username, pass, nume);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<string> counts = userDAL.getCount();
            string s = "";
            foreach (string ss in counts)
            {
                s = s + ss + "\r\n";
            }
            MessageBox.Show(s);
        }
    }
}
