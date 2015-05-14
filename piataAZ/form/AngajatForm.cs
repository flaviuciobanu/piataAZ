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
    public partial class AngajatForm : Form
    {
        AnuntDAL anuntDAL;
        private string username;
        public AngajatForm(string username)
        {
            InitializeComponent();             
            this.username = username;
            anuntDAL = new AnuntDAL();
            refreshTable();
            

        }

        private void refreshTable()
        {
            MySqlDataAdapter adapter = anuntDAL.findAnunturi(username);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void clearFields()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

        }   

        private void button1_Click(object sender, EventArgs e)
        {
            String titlu = textBox1.Text;
            String descriere = textBox2.Text;
            String poza = textBox3.Text;
            anuntDAL.adaugaAnunt(username, titlu, descriere, poza);
            clearFields();
            refreshTable();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            int id = Convert.ToInt32(selectedRow.Cells[0].Value);
            anuntDAL.stergeAnunt(id);
            refreshTable();
        }
    }
}
