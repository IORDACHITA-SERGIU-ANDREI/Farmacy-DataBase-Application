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

namespace Farmacie
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-OS7I765\\SQLEXPRESS;Initial Catalog=Farmacie;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Medicamente.Denumire, Medicamente.Pret_vanzare FROM Medicamente " +
                                            "INNER JOIN Categorie ON Medicamente.ID_Categorie = Categorie.ID_Categorie " +
                                            "WHERE Categorie.Denumire = @de", con);
            cmd.Parameters.AddWithValue("@de",comboBox1.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-OS7I765\\SQLEXPRESS;Initial Catalog=Farmacie;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Medicamente.Denumire, Promotie.Nume_promotie, Promotie.Procent_reducere FROM Medicamente INNER JOIN Lot ON Medicamente.ID_Lot = Lot.ID_Lot INNER JOIN Promotie ON Lot.ID_Promotie = Promotie.ID_Promotie", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-OS7I765\\SQLEXPRESS;Initial Catalog=Farmacie;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Medicamente.Denumire FROM Medicamente " +
                                            "INNER JOIN Lot ON Medicamente.ID_Lot = Lot.ID_Lot " +
                                            "WHERE YEAR(Lot.Data_expirare) = YEAR(CURRENT_TIMESTAMP)", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-OS7I765\\SQLEXPRESS;Initial Catalog=Farmacie;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Medicamente.Denumire FROM Medicamente " +
                                            "INNER JOIN Lot ON Medicamente.ID_Lot = Lot.ID_Lot " +
                                            "WHERE Lot.Cantitate < @val", con);
            cmd.Parameters.AddWithValue("@val",Convert.ToInt32(textBox1.Text));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-OS7I765\\SQLEXPRESS;Initial Catalog=Farmacie;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Medicamente.Denumire FROM Medicamente " +
                                            "INNER JOIN Lot ON Medicamente.ID_Lot = Lot.ID_Lot " +
                                            "WHERE Lot.Data_expirare < CURRENT_TIMESTAMP", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-OS7I765\\SQLEXPRESS;Initial Catalog=Farmacie;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Medicamente.Denumire, Comanda.Pret_cumparare " +
                                            "FROM Medicamente " +
                                            "INNER JOIN Lot ON Medicamente.ID_Lot = Lot.ID_Lot " +
                                            "INNER JOIN Comanda ON Lot.ID_Lot = Comanda.ID_Lot " +
                                            "INNER JOIN Furnizor ON Comanda.ID_Furnizor = Furnizor.ID_Furnizor " +
                                            "WHERE Furnizor.Nume = @de6", con);
            cmd.Parameters.AddWithValue("@de6", comboBox2.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form5 s5 = new Form5();
            s5.Show();
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
            Meniu back = new Meniu();
            back.Show();
        }
    }
}
