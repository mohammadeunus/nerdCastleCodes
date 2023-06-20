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
            SqlCommand cmd = new SqlCommand(sp_insert, CN); //it only returns an integer specifying the number of rows inserted, updated or deleted.

            int i = cmd.ExecuteNonQuery(); 

            CN.Close();
            if (i > 0)
            {
                labelOutput.Text = i + " Data Saved";
            }

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            using (SqlConnection CN = new SqlConnection(connectionString))
            { 
                string query_fetch = "SELECT COUNT(*) FROM PERSON WHERE email = '" + textBoxSearch.Text + "'";

                using (SqlCommand command = new SqlCommand(query_fetch, CN))
                { 
                    CN.Open();

                    int count = (int)command.ExecuteScalar(); //returns the first column of the first row in the database result set.

                    if (count > 0)
                    {
                        // Email exists in the database
                        labelOutput.Text = ("Email exists in the database.");
                    }
                    else
                    {
                        // Email does not exist in the database
                        labelOutput.Text = ("Email does not exist in the database.");
                    }
                }
            }

        }
    }
}