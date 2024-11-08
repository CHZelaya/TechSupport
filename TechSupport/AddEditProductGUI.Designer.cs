namespace TechSupport.Views
{
    partial class frm_Add_Edit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textBox_ProductCode = new TextBox();
            textBox_ProductName = new TextBox();
            textBox_ProductReleaseDate = new TextBox();
            textBox_ProductVersion = new TextBox();
            button_OK = new Button();
            button_Cancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 43);
            label1.Name = "label1";
            label1.Size = new Size(102, 20);
            label1.TabIndex = 0;
            label1.Text = "Product Code:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(86, 102);
            label2.Name = "label2";
            label2.Size = new Size(52, 20);
            label2.TabIndex = 1;
            label2.Text = "Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(78, 154);
            label3.Name = "label3";
            label3.Size = new Size(60, 20);
            label3.TabIndex = 2;
            label3.Text = "Version:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(39, 205);
            label4.Name = "label4";
            label4.Size = new Size(99, 20);
            label4.TabIndex = 3;
            label4.Text = "Release Date:";
            // 
            // textBox_ProductCode
            // 
            textBox_ProductCode.Location = new Point(182, 43);
            textBox_ProductCode.Name = "textBox_ProductCode";
            textBox_ProductCode.Size = new Size(125, 27);
            textBox_ProductCode.TabIndex = 4;
            // 
            // textBox_ProductName
            // 
            textBox_ProductName.Location = new Point(182, 95);
            textBox_ProductName.Name = "textBox_ProductName";
            textBox_ProductName.Size = new Size(231, 27);
            textBox_ProductName.TabIndex = 5;
            // 
            // textBox_ProductReleaseDate
            // 
            textBox_ProductReleaseDate.Location = new Point(182, 198);
            textBox_ProductReleaseDate.Name = "textBox_ProductReleaseDate";
            textBox_ProductReleaseDate.Size = new Size(125, 27);
            textBox_ProductReleaseDate.TabIndex = 6;
            // 
            // textBox_ProductVersion
            // 
            textBox_ProductVersion.Location = new Point(182, 147);
            textBox_ProductVersion.Name = "textBox_ProductVersion";
            textBox_ProductVersion.Size = new Size(125, 27);
            textBox_ProductVersion.TabIndex = 7;
            // 
            // button_OK
            // 
            button_OK.Font = new Font("Showcard Gothic", 9F);
            button_OK.Location = new Point(99, 278);
            button_OK.Name = "button_OK";
            button_OK.Size = new Size(101, 47);
            button_OK.TabIndex = 8;
            button_OK.Text = "&OK";
            button_OK.UseVisualStyleBackColor = true;
            // 
            // button_Cancel
            // 
            button_Cancel.Font = new Font("Showcard Gothic", 9F);
            button_Cancel.Location = new Point(239, 278);
            button_Cancel.Name = "button_Cancel";
            button_Cancel.Size = new Size(109, 47);
            button_Cancel.TabIndex = 9;
            button_Cancel.Text = "&Cancel";
            button_Cancel.UseVisualStyleBackColor = true;
            // 
            // frm_Add_Edit
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(454, 373);
            Controls.Add(button_Cancel);
            Controls.Add(button_OK);
            Controls.Add(textBox_ProductVersion);
            Controls.Add(textBox_ProductReleaseDate);
            Controls.Add(textBox_ProductName);
            Controls.Add(textBox_ProductCode);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frm_Add_Edit";
            Text = "Add/Edit Product";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBox_ProductCode;
        private TextBox textBox_ProductName;
        private TextBox textBox_ProductReleaseDate;
        private TextBox textBox_ProductVersion;
        private Button button_OK;
        private Button button_Cancel;
    }
}