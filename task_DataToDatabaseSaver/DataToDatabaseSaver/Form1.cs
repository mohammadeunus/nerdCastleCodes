using Microsoft.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace DataToDatabaseSaver
{
    public partial class Form1 : Form
    {
        string connectionString = @"Data Source=DESKTOP-R0B9L4A\SQLEXPRESS;Initial Catalog=DataToDatabase;Integrated Security=True;TrustServerCertificate=True";
        
        public Form1()
        {
            InitializeComponent();
            
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            string sp_insert = "INSERT INTO PERSON (Name, Email, Contact) VALUES('" + textBoxName.Text + "', '" + textBoxEmail.Text + "','" + textBoxContact.Text + "'); ";
            SqlConnection CN = new SqlConnection(connectionString);
            CN.Open();
            SqlCommand cmd = new SqlCommand(sp_insert, CN);

            int i = cmd.ExecuteNonQuery();

            CN.Close();
            if (i > 0)
            {
                labelOutput.Text = i + " Data Saved";
            }

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection CN = new SqlConnection(connectionString);

                string querry_fetch = "SELECT * FROM PERSON where email='" + textBoxSearch.Text + "'";
                CN.Open();
                SqlCommand sdaa = new SqlCommand(querry_fetch, CN);

                var ik = sdaa.ExecuteReader();
                labelOutput.Text= ik.ToString();
                CN.Close();
            }
            catch (Exception ex)
            {
                labelOutput.Text = ex.Message;
            }
        }
    }
}