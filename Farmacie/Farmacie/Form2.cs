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
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace Farmacie
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        void getMedicamente() 
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-OS7I765\\SQLEXPRESS;Initial Catalog=Farmacie;Integrated Security=True");
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand("SELECT Denumire,Prospect,ID_Categorie,ID_Lot,Pret_vanzare,Doza_administrare FROM Medicamente", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            
            con.Open();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            getMedicamente();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-OS7I765\\SQLEXPRESS;Initial Catalog=Farmacie;Integrated Security=True");
            con.Open();

            string sql = "SELECT ID_Medicament FROM Medicamente WHERE Prospect=@dev";

            SqlCommand command = new SqlCommand(sql, con);
            command.Parameters.AddWithValue("@dev", textBox3.Text);

            Object idObj = command.ExecuteScalar();
            if (idObj == null)
            {
                MessageBox.Show("Prospectul nu se poate updata! Daca doriti sa il schimbati va rugam sa faci o inserare noua si sa o stergeti pe cea curenta daca este cazul !");
            }
            else
            {
                SqlCommand cmd = new SqlCommand("Update Medicamente set Denumire=@Denumire, Prospect=@Prospect, ID_Categorie=@ID_Categorie, ID_Lot=@ID_Lot, Pret_vanzare=@Pret_vanzare, Doza_administrare=@Doza_administrare where Prospect=@Prospect", con);
                cmd.Parameters.AddWithValue("@Denumire", textBox2.Text);
                cmd.Parameters.AddWithValue("@Prospect", textBox3.Text);
                cmd.Parameters.AddWithValue("@ID_Categorie", textBox4.Text);
                cmd.Parameters.AddWithValue("@ID_Lot", textBox5.Text);
                cmd.Parameters.AddWithValue("@Pret_vanzare", textBox6.Text);
                cmd.Parameters.AddWithValue("@Doza_administrare", textBox7.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updatat cu succes!");
            }
            con.Close();
            getMedicamente();
        }

        private void button4_Click(object sender, EventArgs e)
        {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-OS7I765\\SQLEXPRESS;Initial Catalog=Farmacie;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Denumire,Prospect,ID_Categorie,ID_Lot,Pret_vanzare,Doza_administrare FROM Medicamente", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-OS7I765\\SQLEXPRESS;Initial Catalog=Farmacie;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into Medicamente(Denumire,Prospect,ID_Categorie,ID_Lot,Pret_vanzare,Doza_administrare)Values(@Denumire,@Prospect,@ID_Categorie,@ID_Lot,@Pret_vanzare,@Doza_administrare)", con);
            cmd.Parameters.AddWithValue("@Denumire", textBox2.Text);
            cmd.Parameters.AddWithValue("@Prospect", textBox3.Text);
            cmd.Parameters.AddWithValue("@ID_Categorie", int.Parse(textBox4.Text));
            cmd.Parameters.AddWithValue("@ID_Lot", int.Parse(textBox5.Text));
            cmd.Parameters.AddWithValue("@Pret_vanzare", int.Parse(textBox6.Text));
            cmd.Parameters.AddWithValue("@Doza_administrare", textBox7.Text);
            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Adaugat cu succes!");
            getMedicamente();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-OS7I765\\SQLEXPRESS;Initial Catalog=Farmacie;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete from Medicamente where Prospect=@Prospect", con);
            cmd.Parameters.AddWithValue("@Prospect", textBox3.Text);
            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Sters cu succes!");
            getMedicamente();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-OS7I765\\SQLEXPRESS;Initial Catalog=Farmacie;Integrated Security=True");
            con.Open();
            string s = "%" + textBox8.Text + "%";
            SqlCommand cmd = new SqlCommand("SELECT Denumire,Prospect,ID_Categorie,ID_Lot,Pret_vanzare,Doza_administrare FROM Medicamente WHERE Denumire LIKE @de",con);
            cmd.Parameters.AddWithValue("@de", s);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();   
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
          //  textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form4 s4 = new Form4();
            s4.Show();
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
            Meniu back = new Meniu();
            back.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
