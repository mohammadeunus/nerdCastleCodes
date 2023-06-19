namespace csvFileSaver
{
    public partial class Form1 : Form
    {
        public string Name { get; set; }
        public string Email { get; set; } 
        public string ContactNumber { get; set; }

        // Create a CSV file path in the desired directory
        string filePath = @"E:\project\nerdCastle\data.csv";
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


            bool checkFileExistence = File.Exists(filePath);
            int lineCount = 0;
            if (checkFileExistence)
            {
                lineCount = File.ReadLines(filePath).Count();
            }


            // Write the data to the CSV file
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                //// Check if the CSV file already exists
                if (!checkFileExistence)
                {
                    string csvHeaders = "Name,Email,Contact";
                    writer.WriteLine(csvHeaders);
                    lineCount += 1;
                }

                // Create a string with the property values separated by commas
                string csvLine = $"{Name},{Email},{ContactNumber}";

                // Write the line to the CSV file
                writer.WriteLine(csvLine);
            }

            //check line added or not
            int lineCountNow = File.ReadLines(filePath).Count(); ;
            if (lineCount < lineCountNow)
            {
                output.Text = "data added successfull.";
            }
            else
            {
                output.Text = "operation failed, try again.";
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public bool getEmail(String searchName)
        {
            var strLines = File.ReadLines(filePath);
            foreach (var line in strLines)
            {
                if (line.Split(',')[1].Equals(searchName))
                {
                    //(true,line.Split(',')[2]);
                    return true;
                }                            
            }
            return false;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        { 
            if (getEmail(textBoxSearch.Text))
            {
                output.Text = "email available in file";
            }
            else
            {
                output.Text = "email not found.";
            }
        }
    }
}