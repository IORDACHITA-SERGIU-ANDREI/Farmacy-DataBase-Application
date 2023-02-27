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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Farmacie
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-OS7I765\\SQLEXPRESS;Initial Catalog=Farmacie;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into Categorie(Denumire,Descriere,Pret_impus)Values(@Denumire,@Descriere,@Pret_impus)", con);
            cmd.Parameters.AddWithValue("@Denumire", textBox2.Text);
            cmd.Parameters.AddWithValue("@Descriere", textBox3.Text);
            cmd.Parameters.AddWithValue("@Pret_impus", textBox4.Text);
            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Adaugat cu succes!");
            getCategorie();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-OS7I765\\SQLEXPRESS;Initial Catalog=Farmacie;Integrated Security=True");
            con.Open();
          
            string sql = "SELECT ID_Categorie FROM Categorie WHERE Descriere=@dev";
            string sql2 = "SELECT ID_Categorie FROM Categorie WHERE Denumire=@Denumire";

            SqlCommand command = new SqlCommand(sql, con);
            command.Parameters.AddWithValue("@dev", textBox3.Text);

            SqlCommand command2 = new SqlCommand(sql2, con);
            command2.Parameters.AddWithValue("@Denumire", textBox2.Text);
            Object idObj = command.ExecuteScalar();
            Object id2Obj = command2.ExecuteScalar();
            if(idObj == null && id2Obj == null)
            {
                MessageBox.Show("Nu se exista o inregistare in tabel care sa fie updatata");
            }
            else if(idObj == null && id2Obj != null)
            {
                int id2 = (int)id2Obj;
                SqlCommand cmd = new SqlCommand("Update Categorie set Denumire=@Denumire, Descriere=@Descriere, Pret_impus=@Pret_impus where ID_Categorie=@id2", con);
                cmd.Parameters.AddWithValue("@id2", id2);
                cmd.Parameters.AddWithValue("@Denumire", textBox2.Text);
                cmd.Parameters.AddWithValue("@Descriere", textBox3.Text);
                cmd.Parameters.AddWithValue("@Pret_impus", textBox4.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updatat cu succes!");

            }
            else
            {
                int id = (int)idObj;
                SqlCommand cmd = new SqlCommand("Update Categorie set Denumire=@Denumire, Descriere=@Descriere, Pret_impus=@Pret_impus where ID_Categorie=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@Denumire", textBox2.Text);
                cmd.Parameters.AddWithValue("@Descriere", textBox3.Text);
                cmd.Parameters.AddWithValue("@Pret_impus", textBox4.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updatat cu succes!");
            }
            con.Close();
            getCategorie();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-OS7I765\\SQLEXPRESS;Initial Catalog=Farmacie;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete from Categorie where Descriere=@Descriere", con);
            cmd.Parameters.AddWithValue("@Descriere", textBox3.Text);
            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Sters cu succes!");
            getCategorie();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-OS7I765\\SQLEXPRESS;Initial Catalog=Farmacie;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Denumire,Descriere,Pret_impus FROM Categorie", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-OS7I765\\SQLEXPRESS;Initial Catalog=Farmacie;Integrated Security=True");
            con.Open();
            string s = "%" + textBox8.Text + "%";
            SqlCommand cmd = new SqlCommand("SELECT Denumire,Descriere,Pret_impus FROM Categorie WHERE Denumire LIKE @de", con);
            cmd.Parameters.AddWithValue("@de", s);
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            da.Dispose();
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        void getCategorie()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-OS7I765\\SQLEXPRESS;Initial Catalog=Farmacie;Integrated Security=True");
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand("SELECT Denumire,Descriere,Pret_impus FROM Categorie", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            con.Open();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            getCategorie();   
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
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
    }
}
