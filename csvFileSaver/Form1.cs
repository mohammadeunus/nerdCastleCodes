namespace csvFileSaver
{
    public partial class Form1 : Form
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int contactNumber { get; set; }
        public object ContactNumber { get; private set; }

        public Form1()
        {
            InitializeComponent();

        }

        private void insertDataInCSV(object sender, EventArgs e)
        {
            Name = textBoxName.Text;
            Email = textBoxEmail.Text;
            contactNumber = Int32.Parse(textBoxContact.Text);

            // Create a CSV file path in the desired directory
            string directoryPath = @"F:\aspNetEunus";
            string fileName = "data.csv";
            string filePath = Path.Combine(directoryPath, fileName);

            // Write the data to the CSV file
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                // Create a string with the property values separated by commas
                string csvLine = $"{Name},{Email},{ContactNumber}";

                // Write the line to the CSV file
                writer.WriteLine(csvLine);
            }

        }
    }
}