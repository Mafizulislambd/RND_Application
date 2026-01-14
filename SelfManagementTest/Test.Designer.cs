namespace SelfManagementTest
{
    partial class Test
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
            btnProcessFile = new Button();
            lblCount = new Label();
            SuspendLayout();
            // 
            // btnProcessFile
            // 
            btnProcessFile.Font = new Font("Segoe UI", 15F);
            btnProcessFile.Location = new Point(46, 73);
            btnProcessFile.Name = "btnProcessFile";
            btnProcessFile.Size = new Size(273, 60);
            btnProcessFile.TabIndex = 0;
            btnProcessFile.Text = "BtnProcessFile";
            btnProcessFile.UseVisualStyleBackColor = true;
            btnProcessFile.Click += btnProcessfile_click;
            // 
            // lblCount
            // 
            lblCount.AutoSize = true;
            lblCount.Location = new Point(151, 179);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(0, 20);
            lblCount.TabIndex = 1;
            lblCount.Click += label1_Click;
            // 
            // Test
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblCount);
            Controls.Add(btnProcessFile);
            Name = "Test";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnProcessFile;
        private Label lblCount;
    }
}
