﻿namespace PhotoV2
{
    partial class LogTransfrom
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
            this.Submit = new System.Windows.Forms.Button();
            this.Cvalue = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.Cvalue)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("標楷體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "輸入亮度數值 : ";
            // 
            // Submit
            // 
            this.Submit.Font = new System.Drawing.Font("標楷體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Submit.Location = new System.Drawing.Point(159, 70);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(100, 40);
            this.Submit.TabIndex = 2;
            this.Submit.Text = "確認";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.SubmitClick);
            // 
            // Cvalue
            // 
            this.Cvalue.Font = new System.Drawing.Font("標楷體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Cvalue.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.Cvalue.Location = new System.Drawing.Point(12, 70);
            this.Cvalue.Name = "Cvalue";
            this.Cvalue.Size = new System.Drawing.Size(120, 35);
            this.Cvalue.TabIndex = 3;
            // 
            // LogTransfrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 153);
            this.Controls.Add(this.Cvalue);
            this.Controls.Add(this.Submit);
            this.Controls.Add(this.label1);
            this.Name = "LogTransfrom";
            this.Text = "LogTransfrom";
            ((System.ComponentModel.ISupportInitialize)(this.Cvalue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Submit;
        private System.Windows.Forms.NumericUpDown Cvalue;
    }
}