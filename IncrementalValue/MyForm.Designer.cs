namespace IncrementalValue
{
    partial class MyForm
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
            this.comboBox1Layer = new System.Windows.Forms.ComboBox();
            this.label1Field = new System.Windows.Forms.Label();
            this.button1Go = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1StartVal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBox1Layer
            // 
            this.comboBox1Layer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1Layer.FormattingEnabled = true;
            this.comboBox1Layer.Location = new System.Drawing.Point(16, 49);
            this.comboBox1Layer.Name = "comboBox1Layer";
            this.comboBox1Layer.Size = new System.Drawing.Size(235, 21);
            this.comboBox1Layer.TabIndex = 0;
            // 
            // label1Field
            // 
            this.label1Field.AutoSize = true;
            this.label1Field.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1Field.Location = new System.Drawing.Point(22, 19);
            this.label1Field.Name = "label1Field";
            this.label1Field.Size = new System.Drawing.Size(109, 20);
            this.label1Field.TabIndex = 1;
            this.label1Field.Text = "Select Field:";
            // 
            // button1Go
            // 
            this.button1Go.Location = new System.Drawing.Point(173, 238);
            this.button1Go.Name = "button1Go";
            this.button1Go.Size = new System.Drawing.Size(75, 23);
            this.button1Go.TabIndex = 2;
            this.button1Go.Text = "Go";
            this.button1Go.UseVisualStyleBackColor = true;
            this.button1Go.Click += new System.EventHandler(this.button1Go_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 123);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(235, 20);
            this.textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(16, 195);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(235, 20);
            this.textBox2.TabIndex = 4;
            // 
            // label1StartVal
            // 
            this.label1StartVal.AutoSize = true;
            this.label1StartVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1StartVal.Location = new System.Drawing.Point(22, 91);
            this.label1StartVal.Name = "label1StartVal";
            this.label1StartVal.Size = new System.Drawing.Size(105, 20);
            this.label1StartVal.TabIndex = 5;
            this.label1StartVal.Text = "Start Value:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Increment:";
            // 
            // MyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 273);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1StartVal);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1Go);
            this.Controls.Add(this.label1Field);
            this.Controls.Add(this.comboBox1Layer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MyForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PlusIncremental";
            this.Load += new System.EventHandler(this.MyForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1Layer;
        private System.Windows.Forms.Label label1Field;
        private System.Windows.Forms.Button button1Go;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1StartVal;
        private System.Windows.Forms.Label label2;
    }
}