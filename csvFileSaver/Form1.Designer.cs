namespace csvFileSaver
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxEmail = new TextBox();
            textBoxName = new TextBox();
            textBoxContact = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            button1 = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            button2 = new Button();
            SuspendLayout();
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(141, 82);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(138, 23);
            textBoxEmail.TabIndex = 0;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(141, 53);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(138, 23);
            textBoxName.TabIndex = 0;
            // 
            // textBoxContact
            // 
            textBoxContact.Location = new Point(141, 111);
            textBoxContact.Name = "textBoxContact";
            textBoxContact.Size = new Size(138, 23);
            textBoxContact.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 56);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 1;
            label2.Text = "Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 85);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 1;
            label3.Text = "Email";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(27, 114);
            label4.Name = "label4";
            label4.Size = new Size(93, 15);
            label4.TabIndex = 1;
            label4.Text = "ContactNumber";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaption;
            button1.Location = new Point(27, 182);
            button1.Name = "button1";
            button1.Size = new Size(252, 23);
            button1.TabIndex = 2;
            button1.Text = "Enter";
            button1.UseVisualStyleBackColor = false;
            button1.Click += insertDataInCSV;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(456, 77);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(138, 23);
            textBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(473, 53);
            label1.Name = "label1";
            label1.Size = new Size(99, 15);
            label1.TabIndex = 1;
            label1.Text = "Search For Emails";
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ActiveCaption;
            button2.Location = new Point(401, 114);
            button2.Name = "button2";
            button2.Size = new Size(252, 23);
            button2.TabIndex = 2;
            button2.Text = "Search";
            button2.UseVisualStyleBackColor = false;
            button2.Click += insertDataInCSV;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(735, 302);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(textBoxName);
            Controls.Add(textBoxContact);
            Controls.Add(textBoxEmail);
            Name = "Form1";
            Text = "Enter";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxEmail;
        private TextBox textBoxName;
        private TextBox textBoxContact;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button button1;
        private TextBox textBox1;
        private Label label1;
        private Button button2;
    }
}