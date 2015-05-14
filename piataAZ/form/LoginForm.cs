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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {


                String username=textBox1.Text;
                String pass=textBox2.Text;
                UserDAL user = new UserDAL();
              
                int tip = user.login(username,pass);
                if (tip == 1)
                {
                    AngajatForm m = new AngajatForm(username);
                    m.Show();
                }
                else {
                    AdminForm n = new AdminForm(username);
                    n.Show();
                }
                
        }

        
    }
}
