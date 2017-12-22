namespace Compensation
{
    partial class Form1
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.weaponBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.opticsBox = new System.Windows.Forms.ComboBox();
            this.sensBox = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sensBox)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(172, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Step 3: Press C";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Step 1: Select gun";
            // 
            // weaponBox
            // 
            this.weaponBox.FormattingEnabled = true;
            this.weaponBox.Location = new System.Drawing.Point(12, 25);
            this.weaponBox.Name = "weaponBox";
            this.weaponBox.Size = new System.Drawing.Size(121, 21);
            this.weaponBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Step 2: Select optics";
            // 
            // opticsBox
            // 
            this.opticsBox.FormattingEnabled = true;
            this.opticsBox.Location = new System.Drawing.Point(12, 65);
            this.opticsBox.Name = "opticsBox";
            this.opticsBox.Size = new System.Drawing.Size(121, 21);
            this.opticsBox.TabIndex = 6;
            // 
            // sensBox
            // 
            this.sensBox.Location = new System.Drawing.Point(192, 66);
            this.sensBox.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.sensBox.Name = "sensBox";
            this.sensBox.Size = new System.Drawing.Size(31, 20);
            this.sensBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(144, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Adjust sensitivity as needed";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(172, 92);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 142);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.sensBox);
            this.Controls.Add(this.opticsBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.weaponBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Cuz I\'m Bad";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.sensBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox weaponBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox opticsBox;
        private System.Windows.Forms.NumericUpDown sensBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
    }
}

