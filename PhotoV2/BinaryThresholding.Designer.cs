namespace PhotoV2
{
    partial class BinaryThresholding
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
            this.label1 = new System.Windows.Forms.Label();
            this.Cvalue = new System.Windows.Forms.NumericUpDown();
            this.Submit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Cvalue)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("標楷體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "輸入門檻值 : ";
            // 
            // Cvalue
            // 
            this.Cvalue.Font = new System.Drawing.Font("標楷體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Cvalue.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.Cvalue.Location = new System.Drawing.Point(16, 65);
            this.Cvalue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Cvalue.Name = "Cvalue";
            this.Cvalue.Size = new System.Drawing.Size(120, 35);
            this.Cvalue.TabIndex = 4;
            // 
            // Submit
            // 
            this.Submit.Font = new System.Drawing.Font("標楷體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Submit.Location = new System.Drawing.Point(170, 60);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(100, 40);
            this.Submit.TabIndex = 5;
            this.Submit.Text = "確認";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.SubmitClick);
            // 
            // BinaryThresholding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 153);
            this.Controls.Add(this.Submit);
            this.Controls.Add(this.Cvalue);
            this.Controls.Add(this.label1);
            this.Name = "BinaryThresholding";
            this.Text = "BinaryThresholding";
            ((System.ComponentModel.ISupportInitialize)(this.Cvalue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown Cvalue;
        private System.Windows.Forms.Button Submit;
    }
}