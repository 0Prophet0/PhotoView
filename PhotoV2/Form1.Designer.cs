namespace PhotoV2
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.檔案ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFile = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveFile = new System.Windows.Forms.ToolStripMenuItem();
            this.效果ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Grayscale = new System.Windows.Forms.ToolStripMenuItem();
            this.Negative = new System.Windows.Forms.ToolStripMenuItem();
            this.transformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LogTransfrom = new System.Windows.Forms.ToolStripMenuItem();
            this.PowerLow = new System.Windows.Forms.ToolStripMenuItem();
            this.Histogram = new System.Windows.Forms.ToolStripMenuItem();
            this.BinaryThresholding = new System.Windows.Forms.ToolStripMenuItem();
            this.binaryThresholdingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OtsuMethod = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.FileName = new System.Windows.Forms.Label();
            this.SizeStr = new System.Windows.Forms.Label();
            this.SizeTx = new System.Windows.Forms.Label();
            this.NormalPhoto = new System.Windows.Forms.PictureBox();
            this.Change = new System.Windows.Forms.PictureBox();
            this.HistogramR = new System.Windows.Forms.PictureBox();
            this.HistogramG = new System.Windows.Forms.PictureBox();
            this.HistogramB = new System.Windows.Forms.PictureBox();
            this.HistogramR2 = new System.Windows.Forms.PictureBox();
            this.HistogramG2 = new System.Windows.Forms.PictureBox();
            this.HistogramB2 = new System.Windows.Forms.PictureBox();
            this.IterativeMethod = new System.Windows.Forms.ToolStripMenuItem();
            this.空間濾波ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MeanFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.MedianFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NormalPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Change)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HistogramR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HistogramG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HistogramB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HistogramR2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HistogramG2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HistogramB2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.檔案ToolStripMenuItem,
            this.效果ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1482, 38);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 檔案ToolStripMenuItem
            // 
            this.檔案ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFile,
            this.SaveFile});
            this.檔案ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft JhengHei UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.檔案ToolStripMenuItem.Name = "檔案ToolStripMenuItem";
            this.檔案ToolStripMenuItem.Size = new System.Drawing.Size(75, 34);
            this.檔案ToolStripMenuItem.Text = "檔案";
            // 
            // openFile
            // 
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(196, 34);
            this.openFile.Text = "開啟檔案";
            this.openFile.Click += new System.EventHandler(this.OpenFileClick);
            // 
            // SaveFile
            // 
            this.SaveFile.Name = "SaveFile";
            this.SaveFile.Size = new System.Drawing.Size(196, 34);
            this.SaveFile.Text = "另存新檔";
            this.SaveFile.Click += new System.EventHandler(this.SaveFileClick);
            // 
            // 效果ToolStripMenuItem
            // 
            this.效果ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Grayscale,
            this.Negative,
            this.transformationToolStripMenuItem,
            this.Histogram,
            this.BinaryThresholding,
            this.空間濾波ToolStripMenuItem});
            this.效果ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft JhengHei UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.效果ToolStripMenuItem.Name = "效果ToolStripMenuItem";
            this.效果ToolStripMenuItem.Size = new System.Drawing.Size(75, 34);
            this.效果ToolStripMenuItem.Text = "效果";
            // 
            // Grayscale
            // 
            this.Grayscale.Name = "Grayscale";
            this.Grayscale.Size = new System.Drawing.Size(363, 34);
            this.Grayscale.Text = "灰階";
            this.Grayscale.Click += new System.EventHandler(this.GrayscaleClick);
            // 
            // Negative
            // 
            this.Negative.Name = "Negative";
            this.Negative.Size = new System.Drawing.Size(363, 34);
            this.Negative.Text = "負片";
            this.Negative.Click += new System.EventHandler(this.NegativeClick);
            // 
            // transformationToolStripMenuItem
            // 
            this.transformationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LogTransfrom,
            this.PowerLow});
            this.transformationToolStripMenuItem.Name = "transformationToolStripMenuItem";
            this.transformationToolStripMenuItem.Size = new System.Drawing.Size(363, 34);
            this.transformationToolStripMenuItem.Text = "Transformation ";
            // 
            // LogTransfrom
            // 
            this.LogTransfrom.Name = "LogTransfrom";
            this.LogTransfrom.Size = new System.Drawing.Size(263, 34);
            this.LogTransfrom.Text = "Log Transform";
            this.LogTransfrom.Click += new System.EventHandler(this.LogTransfromClick);
            // 
            // PowerLow
            // 
            this.PowerLow.Name = "PowerLow";
            this.PowerLow.Size = new System.Drawing.Size(263, 34);
            this.PowerLow.Text = "Power - Low";
            this.PowerLow.Click += new System.EventHandler(this.PowerLowClick);
            // 
            // Histogram
            // 
            this.Histogram.Name = "Histogram";
            this.Histogram.Size = new System.Drawing.Size(363, 34);
            this.Histogram.Text = "Histogram equalization";
            this.Histogram.Click += new System.EventHandler(this.HistogramClick);
            // 
            // BinaryThresholding
            // 
            this.BinaryThresholding.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.binaryThresholdingToolStripMenuItem,
            this.OtsuMethod,
            this.IterativeMethod});
            this.BinaryThresholding.Name = "BinaryThresholding";
            this.BinaryThresholding.Size = new System.Drawing.Size(363, 34);
            this.BinaryThresholding.Text = "二值化";
            // 
            // binaryThresholdingToolStripMenuItem
            // 
            this.binaryThresholdingToolStripMenuItem.Name = "binaryThresholdingToolStripMenuItem";
            this.binaryThresholdingToolStripMenuItem.Size = new System.Drawing.Size(378, 34);
            this.binaryThresholdingToolStripMenuItem.Text = "Binary Thresholding";
            this.binaryThresholdingToolStripMenuItem.Click += new System.EventHandler(this.BinaryThresholdingClick);
            // 
            // OtsuMethod
            // 
            this.OtsuMethod.Name = "OtsuMethod";
            this.OtsuMethod.Size = new System.Drawing.Size(378, 34);
            this.OtsuMethod.Text = "Otsu Method";
            this.OtsuMethod.Click += new System.EventHandler(this.OtsuMethodClick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("標楷體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(5, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "圖檔 : ";
            // 
            // FileName
            // 
            this.FileName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileName.AutoSize = true;
            this.FileName.Font = new System.Drawing.Font("標楷體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FileName.Location = new System.Drawing.Point(134, 40);
            this.FileName.Name = "FileName";
            this.FileName.Size = new System.Drawing.Size(61, 30);
            this.FileName.TabIndex = 2;
            this.FileName.Text = "---";
            // 
            // SizeStr
            // 
            this.SizeStr.AutoSize = true;
            this.SizeStr.Font = new System.Drawing.Font("標楷體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.SizeStr.Location = new System.Drawing.Point(5, 70);
            this.SizeStr.Name = "SizeStr";
            this.SizeStr.Size = new System.Drawing.Size(123, 30);
            this.SizeStr.TabIndex = 6;
            this.SizeStr.Text = "長寬 : ";
            // 
            // SizeTx
            // 
            this.SizeTx.AutoSize = true;
            this.SizeTx.Font = new System.Drawing.Font("標楷體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.SizeTx.Location = new System.Drawing.Point(134, 70);
            this.SizeTx.Name = "SizeTx";
            this.SizeTx.Size = new System.Drawing.Size(61, 30);
            this.SizeTx.TabIndex = 7;
            this.SizeTx.Text = "---";
            // 
            // NormalPhoto
            // 
            this.NormalPhoto.BackColor = System.Drawing.Color.White;
            this.NormalPhoto.Location = new System.Drawing.Point(5, 100);
            this.NormalPhoto.Name = "NormalPhoto";
            this.NormalPhoto.Size = new System.Drawing.Size(500, 500);
            this.NormalPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.NormalPhoto.TabIndex = 8;
            this.NormalPhoto.TabStop = false;
            // 
            // Change
            // 
            this.Change.BackColor = System.Drawing.Color.White;
            this.Change.Location = new System.Drawing.Point(530, 100);
            this.Change.Name = "Change";
            this.Change.Size = new System.Drawing.Size(500, 500);
            this.Change.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Change.TabIndex = 9;
            this.Change.TabStop = false;
            // 
            // HistogramR
            // 
            this.HistogramR.BackColor = System.Drawing.Color.DarkGray;
            this.HistogramR.Location = new System.Drawing.Point(5, 606);
            this.HistogramR.Name = "HistogramR";
            this.HistogramR.Size = new System.Drawing.Size(160, 100);
            this.HistogramR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.HistogramR.TabIndex = 14;
            this.HistogramR.TabStop = false;
            // 
            // HistogramG
            // 
            this.HistogramG.BackColor = System.Drawing.Color.DarkGray;
            this.HistogramG.Location = new System.Drawing.Point(171, 606);
            this.HistogramG.Name = "HistogramG";
            this.HistogramG.Size = new System.Drawing.Size(160, 100);
            this.HistogramG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.HistogramG.TabIndex = 15;
            this.HistogramG.TabStop = false;
            // 
            // HistogramB
            // 
            this.HistogramB.BackColor = System.Drawing.Color.DarkGray;
            this.HistogramB.Location = new System.Drawing.Point(337, 606);
            this.HistogramB.Name = "HistogramB";
            this.HistogramB.Size = new System.Drawing.Size(160, 100);
            this.HistogramB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.HistogramB.TabIndex = 16;
            this.HistogramB.TabStop = false;
            // 
            // HistogramR2
            // 
            this.HistogramR2.BackColor = System.Drawing.Color.DarkGray;
            this.HistogramR2.Location = new System.Drawing.Point(530, 606);
            this.HistogramR2.Name = "HistogramR2";
            this.HistogramR2.Size = new System.Drawing.Size(160, 100);
            this.HistogramR2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.HistogramR2.TabIndex = 22;
            this.HistogramR2.TabStop = false;
            // 
            // HistogramG2
            // 
            this.HistogramG2.BackColor = System.Drawing.Color.DarkGray;
            this.HistogramG2.Location = new System.Drawing.Point(696, 606);
            this.HistogramG2.Name = "HistogramG2";
            this.HistogramG2.Size = new System.Drawing.Size(160, 100);
            this.HistogramG2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.HistogramG2.TabIndex = 23;
            this.HistogramG2.TabStop = false;
            // 
            // HistogramB2
            // 
            this.HistogramB2.BackColor = System.Drawing.Color.DarkGray;
            this.HistogramB2.Location = new System.Drawing.Point(862, 606);
            this.HistogramB2.Name = "HistogramB2";
            this.HistogramB2.Size = new System.Drawing.Size(160, 100);
            this.HistogramB2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.HistogramB2.TabIndex = 24;
            this.HistogramB2.TabStop = false;
            // 
            // IterativeMethod
            // 
            this.IterativeMethod.Name = "IterativeMethod";
            this.IterativeMethod.Size = new System.Drawing.Size(378, 34);
            this.IterativeMethod.Text = "跌代法(Iterative Method)";
            this.IterativeMethod.Click += new System.EventHandler(this.IterativeMethodClick);
            // 
            // 空間濾波ToolStripMenuItem
            // 
            this.空間濾波ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MeanFilter,
            this.MedianFilter});
            this.空間濾波ToolStripMenuItem.Name = "空間濾波ToolStripMenuItem";
            this.空間濾波ToolStripMenuItem.Size = new System.Drawing.Size(363, 34);
            this.空間濾波ToolStripMenuItem.Text = "空間濾波";
            // 
            // MeanFilter
            // 
            this.MeanFilter.Name = "MeanFilter";
            this.MeanFilter.Size = new System.Drawing.Size(224, 34);
            this.MeanFilter.Text = "均值濾波";
            this.MeanFilter.Click += new System.EventHandler(this.MeanFilterClick);
            // 
            // MedianFilter
            // 
            this.MedianFilter.Name = "MedianFilter";
            this.MedianFilter.Size = new System.Drawing.Size(224, 34);
            this.MedianFilter.Text = "中間濾波";
            this.MedianFilter.Click += new System.EventHandler(this.MedianFilterClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1482, 1055);
            this.Controls.Add(this.HistogramB2);
            this.Controls.Add(this.HistogramG2);
            this.Controls.Add(this.HistogramR2);
            this.Controls.Add(this.HistogramB);
            this.Controls.Add(this.HistogramG);
            this.Controls.Add(this.HistogramR);
            this.Controls.Add(this.Change);
            this.Controls.Add(this.NormalPhoto);
            this.Controls.Add(this.SizeTx);
            this.Controls.Add(this.SizeStr);
            this.Controls.Add(this.FileName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NormalPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Change)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HistogramR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HistogramG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HistogramB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HistogramR2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HistogramG2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HistogramB2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 檔案ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFile;
        private System.Windows.Forms.ToolStripMenuItem 效果ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Grayscale;
        private System.Windows.Forms.ToolStripMenuItem Negative;
        private System.Windows.Forms.ToolStripMenuItem transformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LogTransfrom;
        private System.Windows.Forms.ToolStripMenuItem PowerLow;
        private System.Windows.Forms.ToolStripMenuItem Histogram;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label FileName;
        private System.Windows.Forms.Label SizeStr;
        private System.Windows.Forms.Label SizeTx;
        private System.Windows.Forms.PictureBox NormalPhoto;
        private System.Windows.Forms.PictureBox Change;
        private System.Windows.Forms.PictureBox HistogramR;
        private System.Windows.Forms.PictureBox HistogramG;
        private System.Windows.Forms.PictureBox HistogramB;
        private System.Windows.Forms.PictureBox HistogramR2;
        private System.Windows.Forms.PictureBox HistogramG2;
        private System.Windows.Forms.PictureBox HistogramB2;
        private System.Windows.Forms.ToolStripMenuItem BinaryThresholding;
        private System.Windows.Forms.ToolStripMenuItem binaryThresholdingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OtsuMethod;
        private System.Windows.Forms.ToolStripMenuItem SaveFile;
        private System.Windows.Forms.ToolStripMenuItem IterativeMethod;
        private System.Windows.Forms.ToolStripMenuItem 空間濾波ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MeanFilter;
        private System.Windows.Forms.ToolStripMenuItem MedianFilter;
    }
}

