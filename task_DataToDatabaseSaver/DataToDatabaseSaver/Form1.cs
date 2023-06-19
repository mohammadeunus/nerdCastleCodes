using Microsoft.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace DataToDatabaseSaver
{
    public partial class Form1 : Form
    {
        public SqlConnection thisConnection = new SqlConnection(@"Data Source=DESKTOP-R0B9L4A\SQLEXPRESS;Initial Catalog=DataToDatabase;Integrated Security=True");
        SqlConnection CN;
        public Form1()
        {
            InitializeComponent();
             CN = new SqlConnection();
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            string sp_insert = "INSERT INTO PERSON (Name, Email, ContactNumber) VALUES('" + textBoxName.Text + "', '" + textBoxEmail.Text + "','" + textBoxContact.Text + "'); ";
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
                string querry_fetch = "SELECT * FROM PERSON where email='" + textBoxSearch.Text + "'";

                SqlCommand sdaa = new SqlCommand(querry_fetch, CN);

                SqlDataReader da = sdaa.ExecuteReader();

                CN.Close();
            }
            catch (Exception ex)
            {
                labelOutput.Text = ex.Message;
            }
        }
    }
}