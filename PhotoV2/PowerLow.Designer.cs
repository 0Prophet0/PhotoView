namespace PhotoV2
{
    partial class PowerLow
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
            this.label2 = new System.Windows.Forms.Label();
            this.Cvalue = new System.Windows.Forms.NumericUpDown();
            this.Gamma = new System.Windows.Forms.NumericUpDown();
            this.Submit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Cvalue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gamma)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("標楷體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "輸入亮度數值 : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("標楷體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(12, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "輸入Gamma數值 : ";
            // 
            // Cvalue
            // 
            this.Cvalue.Font = new System.Drawing.Font("標楷體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Cvalue.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.Cvalue.Location = new System.Drawing.Point(208, 28);
            this.Cvalue.Name = "Cvalue";
            this.Cvalue.Size = new System.Drawing.Size(120, 35);
            this.Cvalue.TabIndex = 4;
            // 
            // Gamma
            // 
            this.Gamma.DecimalPlaces = 1;
            this.Gamma.Font = new System.Drawing.Font("標楷體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Gamma.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.Gamma.Location = new System.Drawing.Point(208, 75);
            this.Gamma.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.Gamma.Name = "Gamma";
            this.Gamma.Size = new System.Drawing.Size(120, 35);
            this.Gamma.TabIndex = 5;
            // 
            // Submit
            // 
            this.Submit.Font = new System.Drawing.Font("標楷體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Submit.Location = new System.Drawing.Point(370, 68);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(100, 40);
            this.Submit.TabIndex = 6;
            this.Submit.Text = "確認";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.SubmitClick);
            // 
            // PowerLow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 153);
            this.Controls.Add(this.Submit);
            this.Controls.Add(this.Gamma);
            this.Controls.Add(this.Cvalue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PowerLow";
            this.Text = "PowerLow";
            ((System.ComponentModel.ISupportInitialize)(this.Cvalue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gamma)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown Cvalue;
        private System.Windows.Forms.NumericUpDown Gamma;
        private System.Windows.Forms.Button Submit;
    }
}