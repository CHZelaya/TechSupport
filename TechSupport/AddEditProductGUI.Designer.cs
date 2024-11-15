
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textBox_ProductCode = new TextBox();
            textBox_ProductName = new TextBox();
            textBox_ProductVersion = new TextBox();
            button_OK = new Button();
            button_Cancel = new Button();
            dtp_ReleaseDate = new DateTimePicker();
            errorProvider1 = new ErrorProvider(components);
            errorProvider2 = new ErrorProvider(components);
            errorProvider3 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider3).BeginInit();
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
            textBox_ProductCode.Tag = "Product Code";
            // 
            // textBox_ProductName
            // 
            textBox_ProductName.Location = new Point(182, 95);
            textBox_ProductName.Name = "textBox_ProductName";
            textBox_ProductName.Size = new Size(231, 27);
            textBox_ProductName.TabIndex = 5;
            textBox_ProductName.Tag = "Product Name";
            // 
            // textBox_ProductVersion
            // 
            textBox_ProductVersion.Location = new Point(182, 147);
            textBox_ProductVersion.Name = "textBox_ProductVersion";
            textBox_ProductVersion.Size = new Size(125, 27);
            textBox_ProductVersion.TabIndex = 6;
            textBox_ProductVersion.Tag = "Version";
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
            button_OK.Click += button_OK_Click;
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
            button_Cancel.Click += button_Cancel_Click;
            // 
            // dtp_ReleaseDate
            // 
            dtp_ReleaseDate.Location = new Point(182, 200);
            dtp_ReleaseDate.Name = "dtp_ReleaseDate";
            dtp_ReleaseDate.Size = new Size(250, 27);
            dtp_ReleaseDate.TabIndex = 10;
            dtp_ReleaseDate.Tag = "Release Date";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            errorProvider2.ContainerControl = this;
            // 
            // errorProvider3
            // 
            errorProvider3.ContainerControl = this;
            // 
            // frm_Add_Edit
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(454, 373);
            Controls.Add(dtp_ReleaseDate);
            Controls.Add(button_Cancel);
            Controls.Add(button_OK);
            Controls.Add(textBox_ProductVersion);
            Controls.Add(textBox_ProductName);
            Controls.Add(textBox_ProductCode);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frm_Add_Edit";
            Text = "Add/Edit Product";
            Load += frm_Add_Edit_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider2).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider3).EndInit();
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
        private TextBox textBox_ProductVersion;
        private Button button_OK;
        private Button button_Cancel;
        private DateTimePicker dtp_ReleaseDate;
        private ErrorProvider errorProvider1;
        private ErrorProvider errorProvider2;
        private ErrorProvider errorProvider3;
    }
}