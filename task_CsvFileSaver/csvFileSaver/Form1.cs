namespace csvFileSaver
{
    public partial class Form1 : Form
    {
        public string Name { get; set; }
        public string Email { get; set; } 
        public string ContactNumber { get; set; }

        // Create a CSV file path in the desired directory
        string filePath = @"E:\project\nerdCastle\task_CsvFileSaver\data.csv";
        //string filePath = Path.Combine(directoryPath, fileName);

        public Form1()
        {
            InitializeComponent();

        }
        private void buttonInsertDataInCSV(object sender, EventArgs e)
        {
            Name = textBoxName.Text;
            Email = textBoxEmail.Text;
            ContactNumber = textBoxContact.Text;

            // Check email format
            if (!EmailHelper.IsValidEmail(Email))
            {
                output.Text = "Invalid email format.";
                return;
            }

            //check if the CSV file already exists or not
            bool checkFileExistence = File.Exists(filePath);
            int lineCount = 0;

            if (checkFileExistence)
            {
                lineCount = File.ReadLines(filePath).Count();
            }

            if (EmailHelper.IsDuplicateEmail(Email, filePath))
            {
                output.Text = "Email address already exists.";
                return;
            }

            // Write the data to the CSV file
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                if (!checkFileExistence)
                {
                    string csvHeaders = "Name,Email,Contact";
                    writer.WriteLine(csvHeaders);
                    lineCount += 1;
                }

                string csvLine = $"{Name},{Email},{ContactNumber}";
                writer.WriteLine(csvLine);
            }

            // check line added or not
            int lineCountNow = File.ReadLines(filePath).Count();
            if (lineCount < lineCountNow)
            {
                output.Text = "Data added successfully.";
            }
            else
            {
                output.Text = "Operation failed. Please try again.";
            }
        }
         


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            var userData = EmailHelper.isEmailAvailable(textBoxSearch.Text, filePath);
            if (userData.Item1)
            {
                output.Text = $"email found, user name is :{userData.Item2}";
            }
            else
            {
                output.Text = "email not found.";
            }
        }
    }
}