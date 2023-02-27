using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Farmacie
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-OS7I765\\SQLEXPRESS;Initial Catalog=Farmacie;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Medicamente.Denumire, Medicamente.Pret_vanzare, (SELECT AVG(Medicamente2.Pret_vanzare) FROM Medicamente AS Medicamente2 " +
                                            "WHERE Medicamente2.ID_Categorie = Medicamente.ID_Categorie) AS 'Pret mediu categorie'" +
                                            "FROM Medicamente WHERE Medicamente.Pret_vanzare < (SELECT AVG(Medicamente2.Pret_vanzare) FROM Medicamente AS Medicamente2 " +
                                            "WHERE Medicamente2.ID_Categorie = Medicamente.ID_Categorie)", con);
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
            SqlCommand cmd = new SqlCommand("SELECT Medicamente.Denumire, Lot.Cantitate, (SELECT AVG(Lot2.Cantitate) FROM Lot AS Lot2 " +
                                            "WHERE Lot2.ID_Promotie = Lot.ID_Promotie) AS 'Cantitate medie promotie' FROM Medicamente INNER JOIN Lot ON Medicamente.ID_Lot = Lot.ID_Lot " +
                                            "WHERE Lot.Cantitate < (SELECT AVG(Lot2.Cantitate) FROM Lot AS Lot2 WHERE Lot2.ID_Promotie = Lot.ID_Promotie)", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-OS7I765\\SQLEXPRESS;Initial Catalog=Farmacie;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Medicamente.Denumire FROM Medicamente " +
                                            "WHERE(SELECT COUNT(DISTINCT Comanda.ID_Furnizor) FROM Comanda " +
                                            "INNER JOIN Lot ON Comanda.ID_Lot = Lot.ID_Lot " +
                                            "WHERE Lot.ID_Lot = Medicamente.ID_Lot) >= @nr", con);
            cmd.Parameters.AddWithValue("@nr", int.Parse(textBox1.Text));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            Form4 back = new Form4();
            back.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
