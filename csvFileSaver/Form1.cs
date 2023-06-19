namespace csvFileSaver
{
    public partial class Form1 : Form
    {
        public string Name { get; set; }
        public string Email { get; set; } 
        public string ContactNumber { get; set; }

        public Form1()
        {
            InitializeComponent();

        }
          
        private void buttonInsertDataInCSV(object sender, EventArgs e)
        {
            Name = textBoxName.Text;
            Email = textBoxEmail.Text;
            ContactNumber = textBoxContact.Text;

            // Create a CSV file path in the desired directory
            string directoryPath = @"E:\project\nerdCastle";
            string fileName = "data.csv";
            string filePath = Path.Combine(directoryPath, fileName);

            bool checkFileExistence = File.Exists(filePath);
            // Write the data to the CSV file
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                //// Check if the CSV file already exists
                if (!checkFileExistence)
                {
                    string csvHeaders = "Name,Email,Contact";
                    writer.WriteLine(csvHeaders);
                }

                // Create a string with the property values separated by commas
                string csvLine = $"{Name},{Email},{ContactNumber}";

                // Write the line to the CSV file
                writer.WriteLine(csvLine);
            }

        }
    }
}