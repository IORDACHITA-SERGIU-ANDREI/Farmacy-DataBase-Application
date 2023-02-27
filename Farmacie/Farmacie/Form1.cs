namespace Farmacie
{
    public partial class Login_meniu : Form
    {
        public Login_meniu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
;       }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text.Equals("admin1")) && (textBox2.Text.Equals("admin2")))
            {
                MessageBox.Show("Login Succesful");
                this.Hide();
                Meniu ss = new Meniu();
                ss.Show();
            }
            else
            {
                MessageBox.Show("Username or Password is not correct");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}