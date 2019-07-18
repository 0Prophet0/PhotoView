using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoV2
{
    public partial class Form1 : Form
    {
        PhotoChange PC;
        Image Photo;
        Image ChPh;
        int H;
        int W;
        private static int SIZE_RANGE = 255;

        Bitmap Normal = null;
        Bitmap[] RGB;//改變前的直方圖
        Bitmap[] RGBChange;//改變後的直方圖
        Pen pen = new Pen(Color.Red, 1);
        Graphics canvas = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void OpenFileClick(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Select File";
            dialog.InitialDirectory = ".\\";
            dialog.Filter = @"(*.bmp,*.jpg,*.tif)|*.bmp;*.jpg;*.png;*.tif";//篩選檔案格式
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                FileName.Text = dialog.FileName;
                Photo = Image.FromFile(FileName.Text);

                
                PC = new PhotoChange(Photo);
                if (Normal != null)
                {
                    Normal.Dispose();
                    Normal = new Bitmap(Photo);
                }
                else
                {
                    Normal = new Bitmap(Photo);
                }
               
                H = Photo.Height;
                W = Photo.Width;
                SizeTx.Text = W + " x " + H;
                NormalPhoto.Image = Photo; //顯示範例原始圖片

                
                int[,] color = PC.getHistogram(Normal);
                int[] MaxRGB = PC.getMixPixel(Normal);
                RGB = new Bitmap[3] { new Bitmap(SIZE_RANGE, MaxRGB[0]), new Bitmap(SIZE_RANGE, MaxRGB[1]), new Bitmap(SIZE_RANGE, MaxRGB[2]) };

                ColorPainter(canvas, RGB[2], HistogramR, pen, Color.Red, MaxRGB[2], color, 2);//畫原始直方圖
                ColorPainter(canvas, RGB[1], HistogramG, pen, Color.Green, MaxRGB[1], color, 1);
                ColorPainter(canvas, RGB[0], HistogramB, pen, Color.Blue, MaxRGB[0], color, 0);

                if(Change.Image != null)
                {
                    RGBChange[2].Dispose();
                    RGBChange[1].Dispose();
                    RGBChange[0].Dispose();
                }
            }

        }

        private void GrayscaleClick(object sender, EventArgs e) //灰階
        {
            if (NormalPhoto.Image != null)
            {
                ChPh = PC.getGray();
                HistogramDrow(ChPh);//畫改變直方圖
                Change.Image = ChPh;
            }
        }

        private void NegativeClick(object sender, EventArgs e) //負片
        {
            if (NormalPhoto.Image != null)
            {
                ChPh = PC.getNegative();
                HistogramDrow(ChPh);
                Change.Image = ChPh;
            }
        }

        private void LogTransfromClick(object sender, EventArgs e)//C * Log( x + 1)
        {
            if (NormalPhoto.Image != null)
            {
                LogTransfrom logTransfrom = new LogTransfrom(this);//產生Form2的物件，才可以使用它所提供的Method
                logTransfrom.ShowDialog(this);//設定Form2為Form1的上層，並開啟Form2視窗。由於在Form1的程式碼內使用this，所以this為Form1的物件本身
            }
        }
        //接收logTransfrom    C * Log( x + 1)的資料並回傳值
        public void Receive_LogTransfromDATA(int C)
        {
            ChPh = PC.getLogarithmic1(C);
            HistogramDrow(ChPh);
            Change.Image = ChPh;
        }

        private void PowerLowClick(object sender, EventArgs e)// power -Low
        {
            if (NormalPhoto.Image != null)
            {
                PowerLow powerLow = new PowerLow(this);//產生Form2的物件，才可以使用它所提供的Method
                powerLow.ShowDialog(this);//設定Form2為Form1的上層，並開啟Form2視窗。由於在Form1的程式碼內使用this，所以this為Form1的物件本身
            }
        }
        //接收powerLow   的資料並回傳值
        public void Receive_PowerLowDATA(int C, double Gamma)
        {
            ChPh = PC.getLogarithmic2(C, Gamma);
            HistogramDrow(ChPh);
            Change.Image = ChPh;
        }

        private void HistogramClick(object sender, EventArgs e)//直方圖均衡化
        {
            if (NormalPhoto.Image != null)
            {
                ChPh = PC.getHistogramEqualization();
                HistogramDrow(ChPh);
                Change.Image = ChPh;
            }
        }
        private void HistogramDrow(Image ph)//繪製轉換後值方圖
        {
            int[,] color = PC.getHistogram(ph);
            int[] MaxRGB = PC.getMixPixel(ph);

            RGBChange = new Bitmap[3] { new Bitmap(SIZE_RANGE, MaxRGB[0]), new Bitmap(SIZE_RANGE, MaxRGB[1]), new Bitmap(SIZE_RANGE, MaxRGB[2]) };

            ColorPainter(canvas, RGBChange[2], HistogramR2, pen, Color.Red, MaxRGB[2], color, 2);
            ColorPainter(canvas, RGBChange[1], HistogramG2, pen, Color.Green, MaxRGB[1], color, 1);
            ColorPainter(canvas, RGBChange[0], HistogramB2, pen, Color.Blue, MaxRGB[0], color, 0);
        }

        private void ColorPainter(Graphics canvas, Bitmap bitmap, PictureBox pictureBox, Pen pen, Color color, int MaxValue, int[,] data, int num)//繪製RGB直方圖
        {
            pen.Color = color;
            canvas = Graphics.FromImage(bitmap);
            for (int i = 0; i < 256; i++)
            {
                canvas.DrawLine(pen, i, MaxValue - data[num, i], i , MaxValue);
                pictureBox.Image = bitmap;
            }
        }
        private void BinaryThresholdingClick(object sender, EventArgs e)//二值化
        {
            if (NormalPhoto.Image != null)
            {
                BinaryThresholding binaryThresholding = new BinaryThresholding(this);//產生Form2的物件，才可以使用它所提供的Method
                binaryThresholding.ShowDialog(this);//設定Form2為Form1的上層，並開啟Form2視窗。由於在Form1的程式碼內使用this，所以this為Form1的物件本身
            }
        }
        //接收BinaryThresholding   的資料並回傳值
        public void Receive_BinaryThresholdingDATA(int C)
        {
            ChPh = PC.getBinaryThresholding(C);
            HistogramDrow(ChPh);
            Change.Image = ChPh;
        }

        private void OtsuMethodClick(object sender, EventArgs e)//歐蘇法
        {
            ChPh = PC.getOtsuMethod();
            HistogramDrow(ChPh);
            Change.Image = ChPh;
        }

        private void SaveFileClick(object sender, EventArgs e)
        {
            Bitmap bitmap = bitmapFromResource();//取得儲存影像

            SaveFileDialog sfd = new SaveFileDialog();//宣告讀檔物件
            sfd.Title = "Save File Dialog"; //視窗標題
            sfd.InitialDirectory = @"C:\"; //起始目錄位置
            sfd.Filter = "All files(*.jpg)| *.*| All files(*.*) | *.*"; //篩選檔案格式
            if (sfd.ShowDialog() == DialogResult.OK)
            { //檔案顯示視窗為正確讀檔
                ImageFormat format = ImageFormat.Jpeg;
                switch (Path.GetExtension(sfd.FileName).ToLower())
                {
                    case ".jpg":
                        format = ImageFormat.Jpeg;
                        break;
                    case ".bmp":
                        format = ImageFormat.Bmp;
                        break;
                    case ".png":
                        format = ImageFormat.Png;
                        break;
                    default:
                        MessageBox.Show(this, "Unsupported image format was specified", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }
                try
                {
                    bitmap.Save(sfd.FileName, format);
                }
                catch (Exception)
                {
                    MessageBox.Show(this, "Failed writing image file", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private Bitmap bitmapFromResource()//取得儲存影像
        {
            Image img = Change.Image;
            if (img == null) return null;
            Bitmap bitmap = new Bitmap(img);
            return bitmap;
        }

        private void IterativeMethodClick(object sender, EventArgs e) //跌代法
        {
            ChPh = PC.getIterativeMethod();
            HistogramDrow(ChPh);
            Change.Image = ChPh;
        }

        private void MeanFilterClick(object sender, EventArgs e)//均值濾波(Mean Filter)
        {
            ChPh = PC.getMeanFilter(3);
            HistogramDrow(ChPh);
            Change.Image = ChPh;
        }

        private void MedianFilterClick(object sender, EventArgs e)//中間濾波
        {
            ChPh = PC.getMedianFilter();
            HistogramDrow(ChPh);
            Change.Image = ChPh;
        }
    }
}
