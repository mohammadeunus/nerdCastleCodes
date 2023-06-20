namespace csvFileSaver
{
    public static class EmailHelper
    {
        public static bool IsDuplicateEmail(string email, string filePath)
        {
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] values = line.Split(',');
                        if (values.Length >= 2 && values[1].Equals(email))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static (bool, string) isEmailAvailable(string searchEmail, string filePath)
        {
            var strLines = File.ReadLines(filePath);
            foreach (var line in strLines)
            {
                string[] values = line.Split(',');
                if (values.Length >= 2 && values[1].Equals(searchEmail))
                {
                    return (true, values[0]);
                }
            }
            return (false, null);
        }
    }

}