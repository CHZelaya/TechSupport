namespace TechSupport
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
            listBox_Data = new ListBox();
            btn_Add = new Button();
            btn_Modify = new Button();
            btn_Remove = new Button();
            btn_Exit = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // listBox_Data
            // 
            listBox_Data.FormattingEnabled = true;
            listBox_Data.Location = new Point(46, 37);
            listBox_Data.Name = "listBox_Data";
            listBox_Data.Size = new Size(717, 344);
            listBox_Data.TabIndex = 0;
            // 
            // btn_Add
            // 
            btn_Add.Location = new Point(46, 402);
            btn_Add.Name = "btn_Add";
            btn_Add.Size = new Size(94, 42);
            btn_Add.TabIndex = 1;
            btn_Add.Text = "&Add";
            btn_Add.UseVisualStyleBackColor = true;
            // 
            // btn_Modify
            // 
            btn_Modify.Location = new Point(166, 402);
            btn_Modify.Name = "btn_Modify";
            btn_Modify.Size = new Size(94, 42);
            btn_Modify.TabIndex = 2;
            btn_Modify.Text = "&Modify";
            btn_Modify.UseVisualStyleBackColor = true;
            // 
            // btn_Remove
            // 
            btn_Remove.Location = new Point(285, 402);
            btn_Remove.Name = "btn_Remove";
            btn_Remove.Size = new Size(94, 42);
            btn_Remove.TabIndex = 3;
            btn_Remove.Text = "&Remove";
            btn_Remove.UseVisualStyleBackColor = true;
            // 
            // btn_Exit
            // 
            btn_Exit.Location = new Point(669, 402);
            btn_Exit.Name = "btn_Exit";
            btn_Exit.Size = new Size(94, 42);
            btn_Exit.TabIndex = 4;
            btn_Exit.Text = "&Exit";
            btn_Exit.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(45, 13);
            label1.Name = "label1";
            label1.Size = new Size(99, 20);
            label1.TabIndex = 5;
            label1.Text = "Product Code";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(189, 13);
            label2.Name = "label2";
            label2.Size = new Size(49, 20);
            label2.TabIndex = 6;
            label2.Text = "Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(549, 14);
            label3.Name = "label3";
            label3.Size = new Size(57, 20);
            label3.TabIndex = 7;
            label3.Text = "Version";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(667, 13);
            label4.Name = "label4";
            label4.Size = new Size(96, 20);
            label4.TabIndex = 8;
            label4.Text = "Release Date";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(820, 470);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btn_Exit);
            Controls.Add(btn_Remove);
            Controls.Add(btn_Modify);
            Controls.Add(btn_Add);
            Controls.Add(listBox_Data);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox_Data;
        private Button btn_Add;
        private Button btn_Modify;
        private Button btn_Remove;
        private Button btn_Exit;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}
