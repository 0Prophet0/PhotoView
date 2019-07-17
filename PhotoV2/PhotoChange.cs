using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoV2
{
    class PhotoChange
    {
        private Image photo;
        private static int COLOR_SIZE_RANGE = 256;

        public PhotoChange(Image photo)
        {
            this.photo = photo;
        }
        public Bitmap getGray( )//灰階
        {
            Bitmap bitmap = new Bitmap(photo);
            int W = bitmap.Width;
            int H = bitmap.Height;
            Rectangle rect = new Rectangle(0, 0, W, H);//放置圖片空間大小

            //將bitmap鎖定到系統內的記憶體
            BitmapData srcBmData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            //位元圖中第一個像素數據的地址。它也可以看成是位圖中的第一個掃描行
            //目的是設兩個起始旗標srcPtr 為srcBmData 的掃描行的開始位置
            System.IntPtr srcScan = srcBmData.Scan0;

            unsafe //啟動不安全代碼
            {
                byte* srcP = (byte*)(void*)srcScan;
                int srcOffset = srcBmData.Stride - W * 3;

                for (int i = 0; i < H; i++)
                {
                    for (int j = 0; j < W; j++, srcP += 3)
                    {//red, green, blue
                        byte avg = (byte)((srcP[2] + srcP[1] + srcP[0]) / 3);
                        srcP[2] = srcP[1] = srcP[0] = avg;
                    }
                    srcP += srcOffset;
                }
            }
            bitmap.UnlockBits(srcBmData);

            return bitmap;
        }
        public Bitmap getNegative()//負片
        {
            Bitmap bitmap = new Bitmap(photo);
            int W = bitmap.Width;
            int H = bitmap.Height;
            Rectangle rect = new Rectangle(0, 0, W, H);//放置圖片空間大小

            //將bitmap鎖定到系統內的記憶體
            BitmapData srcBmData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            //位元圖中第一個像素數據的地址。它也可以看成是位圖中的第一個掃描行
            //目的是設兩個起始旗標srcPtr 為srcBmData 的掃描行的開始位置
            System.IntPtr srcScan = srcBmData.Scan0;

            unsafe //啟動不安全代碼
            {
                byte* srcP = (byte*)(void*)srcScan;
                int srcOffset = srcBmData.Stride - W * 3;

                for (int i = 0; i < H; i++)
                {
                    for (int j = 0; j < W; j++, srcP += 3)
                    {//red, green, blue
                        byte red = (byte)(255 - srcP[2]);
                        byte green = (byte)(255 - srcP[1]);
                        byte blue = (byte)(255 - srcP[0]);
                        srcP[2] = red;
                        srcP[1] = green;
                        srcP[0] = blue;
                    }
                    srcP += srcOffset;
                }
            }
            bitmap.UnlockBits(srcBmData);

            return bitmap;
        }
        
        public Bitmap getLogarithmic1(int c)//C * Log( x + 1)
        {
            Bitmap bitmap = new Bitmap(photo);
            int W = bitmap.Width;
            int H = bitmap.Height;
            Rectangle rect = new Rectangle(0, 0, W, H);//放置圖片空間大小

            //將bitmap鎖定到系統內的記憶體
            BitmapData srcBmData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            //位元圖中第一個像素數據的地址。它也可以看成是位圖中的第一個掃描行
            //目的是設兩個起始旗標srcPtr 為srcBmData 的掃描行的開始位置
            System.IntPtr srcScan = srcBmData.Scan0;

            unsafe //啟動不安全代碼
            {
                byte* srcP = (byte*)(void*)srcScan;
                int srcOffset = srcBmData.Stride - W * 3;

                for (int i = 0; i < H; i++)
                {
                    for (int j = 0; j < W; j++, srcP += 3)
                    {//red, green, blue
                        byte red = (byte)(c * Math.Log((srcP[2] + 1), 10));
                        byte green = (byte)(c * Math.Log((srcP[1] + 1), 10));
                        byte blue = (byte)(c * Math.Log((srcP[0] + 1), 10));
                        srcP[2] = red;
                        srcP[1] = green;
                        srcP[0] = blue;
                    }
                    srcP += srcOffset;
                }
            }
            bitmap.UnlockBits(srcBmData);

            return bitmap;
        }

        public Bitmap getLogarithmic2( int c, double r) // C * R的gamma次方
        {
            Bitmap bitmap = new Bitmap(photo);
            int W = bitmap.Width;
            int H = bitmap.Height;
            Rectangle rect = new Rectangle(0, 0, W, H);//放置圖片空間大小

            //將bitmap鎖定到系統內的記憶體
            BitmapData srcBmData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            //位元圖中第一個像素數據的地址。它也可以看成是位圖中的第一個掃描行
            //目的是設兩個起始旗標srcPtr 為srcBmData、dstBmData的掃描行的開始位置
            System.IntPtr srcScan = srcBmData.Scan0;

            unsafe //啟動不安全代碼
            {
                byte* srcP = (byte*)(void*)srcScan;
                int srcOffset = srcBmData.Stride - W * 3;

                for (int i = 0; i < H; i++)
                {

                    for (int j = 0; j < W; j++, srcP += 3)
                    {//red, green, blue
                        double red = (c * Math.Pow(srcP[2], r));
                        double green = (c * Math.Pow(srcP[1], r));
                        double blue = (c * Math.Pow(srcP[0], r));
                        srcP[2] = (byte)((red > 255) ? 255 : red);
                        srcP[1] = (byte)((green > 255) ? 255 : green);
                        srcP[0] = (byte)((blue > 255) ? 255 : blue);
                    }
                    srcP += srcOffset;
                }
            }
            bitmap.UnlockBits(srcBmData);

            return bitmap;
        }
        //--------------------------------------------------
        public Bitmap getHistogramEqualization() // 直方圖均化
        {
            Bitmap bitmap = new Bitmap(photo);
            int W = bitmap.Width;
            int H = bitmap.Height;
            int total = W * H;

            Rectangle rect = new Rectangle(0, 0, W, H);//放置圖片空間大小

            //統計
            int[,] PhotoData = new int[3, COLOR_SIZE_RANGE];
            HistogramEqualizationStatistics(bitmap, ref PhotoData, rect); //統計出現次數

            for (int i = 0; i < COLOR_SIZE_RANGE; i++)//轉成cdf數值
            {//red, green, blue
                int rCount = 0, gCount = 0, bCount = 0;
                //零省略
                rCount = (int)(PhotoData[2, i] + ((i == 0) ? 0 : PhotoData[2, i - 1]));
                gCount = (int)(PhotoData[1, i] + ((i == 0) ? 0 : PhotoData[1, i - 1]));
                bCount = (int)(PhotoData[0, i] + ((i == 0) ? 0 : PhotoData[0, i - 1]));

                PhotoData[2, i] = rCount;
                PhotoData[1, i] = gCount;
                PhotoData[0, i] = bCount;
            }

            //填數
            Bitmap resBitmap = HistogramEqualizationFillIn(bitmap, total, PhotoData, rect);

            return resBitmap;
        }
        private static void HistogramEqualizationStatistics(Bitmap bitmap, ref int[,] PhotoData, Rectangle rect)//統計出現次數
        {
            int W = bitmap.Width;
            int H = bitmap.Height;
            int R = 2, G = 1, B = 0;

            //將bitmap鎖定到系統內的記憶體
            BitmapData srcBmData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            //位元圖中第一個像素數據的地址。它也可以看成是位圖中的第一個掃描行
            //目的是起始旗標srcPtr 為srcBmData的掃描行的開始位置
            System.IntPtr srcScan = srcBmData.Scan0;

            unsafe //啟動不安全代碼
            {
                byte* srcP = (byte*)(void*)srcScan;
                int srcOffset = srcBmData.Stride - W * 3;
                for (int i = 0; i < H; i++)
                {
                    for (int j = 0; j < W; j++, srcP += 3)
                    {//red, green, blue
                        PhotoData[R, srcP[2]]++;
                        PhotoData[G, srcP[1]]++;
                        PhotoData[B, srcP[0]]++;
                    }
                    srcP += srcOffset;
                }
            }
            bitmap.UnlockBits(srcBmData);

        }

        private static Bitmap HistogramEqualizationFillIn(Bitmap bitmap, int total, int[,] PhotoData, Rectangle rect) //值方圖轉換函式
        {
            int W = bitmap.Width;
            int H = bitmap.Height;
            int R = 2, G = 1, B = 0;

            //Copy
            Bitmap dstBitmap = new Bitmap(bitmap);
            //將bitmap鎖定到系統內的記憶體
            BitmapData srcBmData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            BitmapData dstBmData = dstBitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            //位元圖中第一個像素數據的地址。它也可以看成是位圖中的第一個掃描行
            //目的是設兩個起始旗標srcPtr、dstPtr，為srcBmData、dstBmData的掃描行的開始位置
            System.IntPtr srcScan = srcBmData.Scan0;
            System.IntPtr dstScan = dstBmData.Scan0;

            unsafe //啟動不安全代碼
            {
                byte* srcP = (byte*)(void*)srcScan;
                byte* dstP = (byte*)(void*)dstScan;
                int srcOffset = srcBmData.Stride - W * 3;
                int dstOffset = dstBmData.Stride - W * 3;

                for (int y = 0; y < H; y++)
                {
                    for (int x = 0; x < W; x++, srcP += 3, dstP += 3)
                    {//red, green, blue
                        dstP[2] = (byte)(((double)PhotoData[R, srcP[2]] / total) * (COLOR_SIZE_RANGE - 1));
                        dstP[1] = (byte)(((double)PhotoData[G, srcP[1]] / total) * (COLOR_SIZE_RANGE - 1));
                        dstP[0] = (byte)(((double)PhotoData[B, srcP[0]] / total) * (COLOR_SIZE_RANGE - 1));
                    }
                    srcP += srcOffset;
                    dstP += dstOffset;
                }
            }

            bitmap.UnlockBits(srcBmData);
            dstBitmap.UnlockBits(dstBmData);

            return dstBitmap;
        }
     
        public Bitmap getBinaryThresholding(int Value) //二值化
        {

            Bitmap bitmap = getGray();
            int W = bitmap.Width;
            int H = bitmap.Height;
            int Max = 255, Min = 0;

            Rectangle rect = new Rectangle(0, 0, W, H);//放置圖片空間大小

            //將bitmap鎖定到系統內的記憶體
            BitmapData srcBmData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            //位元圖中第一個像素數據的地址。它也可以看成是位圖中的第一個掃描行
            //目的是設兩個起始旗標srcPtr 為srcBmData 的掃描行的開始位置
            System.IntPtr srcScan = srcBmData.Scan0;

            unsafe //啟動不安全代碼
            {
                byte* srcP = (byte*)(void*)srcScan;
                int srcOffset = srcBmData.Stride - W * 3;

                for (int i = 0; i < H; i++)
                {
                    for (int j = 0; j < W; j++, srcP += 3)
                    {//red, green, blue
                        srcP[2] = (byte)((srcP[2] > Value) ? Max : Min);
                        srcP[1] = (byte)((srcP[1] > Value) ? Max : Min);
                        srcP[0] = (byte)((srcP[0] > Value) ? Max : Min);
                    }
                    srcP += srcOffset;
                }
            }
            bitmap.UnlockBits(srcBmData);

            return bitmap;
        }

        public Bitmap getOtsuMethod()//歐蘇法
        {
            Bitmap bitmap = getGray();
            int W = bitmap.Width;
            int H = bitmap.Height;
            double threshold;
            int Max = 255, Min = 0;

            Rectangle rect = new Rectangle(0, 0, W, H);//放置圖片空間大小

            //統計
            int[,] PhotoData = new int[3, COLOR_SIZE_RANGE];
            HistogramEqualizationStatistics(bitmap, ref PhotoData, rect); //統計

            threshold = Otsu(PhotoData);//取得閥值

            //將bitmap鎖定到系統內的記憶體
            BitmapData srcBmData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            //位元圖中第一個像素數據的地址。它也可以看成是位圖中的第一個掃描行
            //目的是設兩個起始旗標srcPtr 為srcBmData 的掃描行的開始位置
            System.IntPtr srcScan = srcBmData.Scan0;

            unsafe //啟動不安全代碼
            {
                byte* srcP = (byte*)(void*)srcScan;
                int srcOffset = srcBmData.Stride - W * 3;

                for (int i = 0; i < H; i++)
                {
                    for (int j = 0; j < W; j++, srcP += 3)
                    {//red, green, blue
                        srcP[2] = (byte)((srcP[2] > threshold) ? Max : Min);
                        srcP[1] = (byte)((srcP[1] > threshold) ? Max : Min);
                        srcP[0] = (byte)((srcP[0] > threshold) ? Max : Min);
                    }
                    srcP += srcOffset;
                }
            }
            bitmap.UnlockBits(srcBmData);


            return bitmap;
        }

        private int Otsu(int[,] Data)//計算自動閥值
        {
            double w0, u0, u0temp; //屬於前景的像素點數佔整幅圖像的比例記為ω0，其平均灰度μ0
            double w1, u1, u1temp; //背景像素點數佔整幅圖像的比例為ω1，其平均灰度為μ1。
            double g, MaxValue = 0;//類間方差記為g ， MaxValue為閥值下的最大值
            int threshold = 0;//目前閥值T 0-255

            for (int i = 0; i < COLOR_SIZE_RANGE; i++)//從0到255灰度级的閥值分割條件，測試哪個類間方差最大
            {
                w0 = w1 = u0temp = u1temp = u0 = u1 = g = 0;
                for (int j = 0; j < COLOR_SIZE_RANGE; j++)//分割影像取得目前影像的閥值     //計算前景背景平均灰度
                {
                    if (j <= i) //前景
                    {
                        w0 += Data[0, j];//影像像素出現個數
                        u0temp += j * Data[0, j]; //u = ∑ i * p（i）  灰度計算 詳看Otsu pdf 9.2.1
                    }
                    else//背景
                    {
                        w1 += Data[0, j];//影像像素出現個數
                        u1temp += j * Data[0, j]; //u = ∑ i * p（i）  灰度計算 詳看Otsu pdf 9.2.1
                    }
                }
                u0 = u0temp / w0; //圖像的總平均灰度記為μ0
                u1 = u1temp / w1; //圖像的總平均灰度記為μ1
                g = w0 * w1 * Math.Pow((u0 - u1), 2); //簡化公式 g = w0 * w1 * (u0 - u1) ^ 2
                if (g > MaxValue) //判斷目前閥值大小
                {
                    MaxValue = g;
                    threshold = i; //取得目前閥值T
                }
            }

            return threshold;
        }

        public Bitmap getIterativeMethod()//跌代法
        {
            Bitmap bitmap = getGray();
            int W = bitmap.Width;
            int H = bitmap.Height;
            double threshold;
            int Max = 255, Min = 0;

            Rectangle rect = new Rectangle(0, 0, W, H);//放置圖片空間大小

            //統計
            int[,] PhotoData = new int[3, COLOR_SIZE_RANGE];
            HistogramEqualizationStatistics(bitmap, ref PhotoData, rect); //統計

            threshold = IterativeMethod(PhotoData);//取得閥值

            //將bitmap鎖定到系統內的記憶體
            BitmapData srcBmData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            //位元圖中第一個像素數據的地址。它也可以看成是位圖中的第一個掃描行
            //目的是設兩個起始旗標srcPtr 為srcBmData 的掃描行的開始位置
            System.IntPtr srcScan = srcBmData.Scan0;

            unsafe //啟動不安全代碼
            {
                byte* srcP = (byte*)(void*)srcScan;
                int srcOffset = srcBmData.Stride - W * 3;

                for (int i = 0; i < H; i++)
                {
                    for (int j = 0; j < W; j++, srcP += 3)
                    {//red, green, blue
                        srcP[2] = (byte)((srcP[2] > threshold) ? Max : Min);
                        srcP[1] = (byte)((srcP[1] > threshold) ? Max : Min);
                        srcP[0] = (byte)((srcP[0] > threshold) ? Max : Min);
                    }
                    srcP += srcOffset;
                }
            }
            bitmap.UnlockBits(srcBmData);


            return bitmap;
        }

        private int IterativeMethod(int[,] Data)//計算自動閥值
        {
            double w0, u0, u0temp; //屬於前景的像素點數佔整幅圖像的比例記為ω0，其平均灰度μ0
            double w1, u1, u1temp; //背景像素點數佔整幅圖像的比例為ω1，其平均灰度為μ1。
            double g, MaxValue = 256;//類間方差記為g ， MaxValue為閥值下的最大值
            int threshold = 0;//目前閥值T 0-255
            int sum = 0, total = 0, i = 0;

            for (i = 0; i < COLOR_SIZE_RANGE; i++)//從0到255灰度级的閥值分割條件，測試哪個類間方差最大
            {
                sum += Data[0, i];
                total += i * Data[0, i];
            }
            threshold = total / sum;

            bool stop = true;
            while (stop)
            {
                w0 = w1 = u0temp = u1temp = u0 = u1 = g = 0;
                for (i = 0; i < COLOR_SIZE_RANGE; i++)//分割影像取得目前影像的閥值    //計算前景背景平均灰度
                {
                    if (i <= threshold) //前景
                    {
                        w0 += Data[0, i];//影像像素出現個數
                        u0temp += i * Data[0, i]; //u = ∑ i * p（i）  灰度計算 詳看Otsu pdf 9.2.1
                    }
                    else//背景
                    {
                        w1 += Data[0, i];//影像像素出現個數
                        u1temp += i * Data[0, i]; //u = ∑ i * p（i）  灰度計算 詳看Otsu pdf 9.2.1
                    }
                }
                u0 = u0temp / w0; //圖像的總平均灰度記為μ0
                u1 = u1temp / w1; //圖像的總平均灰度記為μ1
                g = (u0 + u1) / 2;
                if ((g - MaxValue) < 1) //判斷目前閥值大小
                {
                    stop = false;
                }
                else
                {
                    MaxValue = g;
                    threshold = i; //取得目前閥值T
                }
            }
            return threshold;
        }

        public Bitmap getMeanFilter()//均值濾波(Mean Filter)
        {
            Bitmap bitmap = new Bitmap(photo);
            int W = bitmap.Width;
            int H = bitmap.Height;
            int[,,] PhotoData = new int[3, H, W];

            Rectangle rect = new Rectangle(0, 0, W, H);//放置圖片空間大小

            PhotoData = MeanFilter(rect, bitmap);


            //將bitmap鎖定到系統內的記憶體
            BitmapData srcBmData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            //位元圖中第一個像素數據的地址。它也可以看成是位圖中的第一個掃描行
            //目的是設兩個起始旗標srcPtr 為srcBmData 的掃描行的開始位置
            System.IntPtr srcScan = srcBmData.Scan0;

            unsafe //啟動不安全代碼
            {
                byte* srcP = (byte*)(void*)srcScan;
                int srcOffset = srcBmData.Stride - W * 3;

                for (int i = 0; i < H; i++)
                {
                    for (int j = 0; j < W; j++, srcP += 3)
                    {//red, green, blue
                        srcP[2] = (byte)PhotoData[2, i, j];
                        srcP[1] = (byte)PhotoData[1, i, j];
                        srcP[0] = (byte)PhotoData[0, i, j];
                    }
                    srcP += srcOffset;
                }
            }
            bitmap.UnlockBits(srcBmData);
            return bitmap;
        }

        private int[,,] MeanFilter(Rectangle rect, Bitmap bitmap)//均值濾波(Mean Filter)
        {
            int W = bitmap.Width;
            int H = bitmap.Height;
            int[,,] PhotoData = new int[3, H, W];
            //將bitmap鎖定到系統內的記憶體
            BitmapData srcBmData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            //位元圖中第一個像素數據的地址。它也可以看成是位圖中的第一個掃描行
            //目的是設兩個起始旗標srcPtr 為srcBmData 的掃描行的開始位置
            System.IntPtr srcScan = srcBmData.Scan0;

            unsafe //啟動不安全代碼
            {
                byte* srcP = (byte*)(void*)srcScan;
                int srcOffset = srcBmData.Stride - W * 3;

                for (int i = 0; i < H; i++)
                {
                    for (int j = 0; j < W; j++, srcP += 3)
                    {//red, green, blue
                        PhotoData[2, i, j] = srcP[2];
                        PhotoData[1, i, j] = srcP[1];
                        PhotoData[0, i, j] = srcP[0];
                    }
                    srcP += srcOffset;
                }
            }
            bitmap.UnlockBits(srcBmData);

            int Ravg, Gavg, Bavg;

            for (int i = 1; i < (H - 1); i++)
            {
                for (int j = 1; j < (W - 1); j++)
                {//red, green, blue
                    Ravg = Gavg = Bavg = 0;
                    Ravg = (PhotoData[2, i - 1, j - 1] + PhotoData[2, i - 1, j] + PhotoData[2, i - 1, j + 1] + PhotoData[2, i, j - 1] + PhotoData[2, i, j] + PhotoData[2, i, j + 1] + PhotoData[2, i + 1, j - 1] + PhotoData[2, i + 1, j] + PhotoData[2, i + 1, j + 1]) / 9;
                    Gavg = (PhotoData[1, i - 1, j - 1] + PhotoData[1, i - 1, j] + PhotoData[1, i - 1, j + 1] + PhotoData[1, i, j - 1] + PhotoData[1, i, j] + PhotoData[1, i, j + 1] + PhotoData[1, i + 1, j - 1] + PhotoData[1, i + 1, j] + PhotoData[1, i + 1, j + 1]) / 9;
                    Bavg = (PhotoData[0, i - 1, j - 1] + PhotoData[0, i - 1, j] + PhotoData[0, i - 1, j + 1] + PhotoData[0, i, j - 1] + PhotoData[0, i, j] + PhotoData[0, i, j + 1] + PhotoData[0, i + 1, j - 1] + PhotoData[0, i + 1, j] + PhotoData[0, i + 1, j + 1]) / 9;
                    PhotoData[2, i, j] = Ravg;
                    PhotoData[1, i, j] = Gavg;
                    PhotoData[0, i, j] = Bavg;
                }
            }

            return PhotoData;
        }


        public Bitmap getMedianFilter()//中值濾波(MedianFilter)
        {
            Bitmap bitmap = new Bitmap(photo);
            int W = bitmap.Width;
            int H = bitmap.Height;
            int[,,] PhotoData = new int[3, H, W];

            Rectangle rect = new Rectangle(0, 0, W, H);//放置圖片空間大小

            PhotoData = MedianFilter(rect, bitmap);


            //將bitmap鎖定到系統內的記憶體
            BitmapData srcBmData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            //位元圖中第一個像素數據的地址。它也可以看成是位圖中的第一個掃描行
            //目的是設兩個起始旗標srcPtr 為srcBmData 的掃描行的開始位置
            System.IntPtr srcScan = srcBmData.Scan0;

            unsafe //啟動不安全代碼
            {
                byte* srcP = (byte*)(void*)srcScan;
                int srcOffset = srcBmData.Stride - W * 3;

                for (int i = 0; i < H; i++)
                {
                    for (int j = 0; j < W; j++, srcP += 3)
                    {//red, green, blue
                        srcP[2] = (byte)PhotoData[2, i, j];
                        srcP[1] = (byte)PhotoData[1, i, j];
                        srcP[0] = (byte)PhotoData[0, i, j];
                    }
                    srcP += srcOffset;
                }
            }
            bitmap.UnlockBits(srcBmData);
            return bitmap;
        }

        private int[,,] MedianFilter(Rectangle rect, Bitmap bitmap)//中值濾波
        {
            int W = bitmap.Width;
            int H = bitmap.Height;
            int[,,] PhotoData = new int[3, H, W];
            //將bitmap鎖定到系統內的記憶體
            BitmapData srcBmData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            //位元圖中第一個像素數據的地址。它也可以看成是位圖中的第一個掃描行
            //目的是設兩個起始旗標srcPtr 為srcBmData 的掃描行的開始位置
            System.IntPtr srcScan = srcBmData.Scan0;

            unsafe //啟動不安全代碼
            {
                byte* srcP = (byte*)(void*)srcScan;
                int srcOffset = srcBmData.Stride - W * 3;

                for (int i = 0; i < H; i++)
                {
                    for (int j = 0; j < W; j++, srcP += 3)
                    {//red, green, blue
                        PhotoData[2, i, j] = srcP[2];
                        PhotoData[1, i, j] = srcP[1];
                        PhotoData[0, i, j] = srcP[0];
                    }
                    srcP += srcOffset;
                }
            }
            bitmap.UnlockBits(srcBmData);

            for (int i = 1; i < (H - 1); i++)
            {
                for (int j = 1; j < (W - 1); j++)
                {//red, green, blue

                    PhotoData[2, i, j] = RGBMedianAdd(PhotoData, i, j, 2);
                    PhotoData[1, i, j] = RGBMedianAdd(PhotoData, i, j, 1);
                    PhotoData[0, i, j] = RGBMedianAdd(PhotoData, i, j, 0);
                }
            }

            return PhotoData;
        }

        private int RGBMedianAdd(int[,,] PhotoData, int i, int j, int color)
        {
            List<int> RGB = new List<int>();
            int Value;
            RGB.Add(PhotoData[color, i - 1, j - 1]);
            RGB.Add(PhotoData[color, i - 1, j]);
            RGB.Add(PhotoData[color, i - 1, j + 1]);
            RGB.Add(PhotoData[color, i, j - 1]);
            RGB.Add(PhotoData[color, i, j]);
            RGB.Add(PhotoData[color, i, j + 1]);
            RGB.Add(PhotoData[color, i + 1, j - 1]);
            RGB.Add(PhotoData[color, i + 1, j]);
            RGB.Add(PhotoData[color, i + 1, j + 1]);
            RGB.Sort();
            Value = RGB[4];
            RGB.Clear();
            return Value;
        }

        public int[,] getHistogram(Image p)//取得RGB出現次數
        {
            Bitmap picture = new Bitmap(p);
            int W = picture.Width;
            int H = picture.Height;

            Rectangle rect = new Rectangle(0, 0, W, H);//放置圖片空間大小

            //統計
            int[,] PhotoData = new int[3, COLOR_SIZE_RANGE];
            HistogramEqualizationStatistics(picture, ref PhotoData, rect); //統計

            return PhotoData;
        }

        public int[] getMixPixel(Image photo)//取得RGB的最大值
        {
            Bitmap picture = new Bitmap(photo);
            int W = picture.Width;
            int H = picture.Height;
            int MaxR = 0, MaxG = 0, MaxB = 0;
            Rectangle rect = new Rectangle(0, 0, W, H);//放置圖片空間大小

            //統計
            int[,] PhotoData = new int[3, COLOR_SIZE_RANGE];
            HistogramEqualizationStatistics(picture, ref PhotoData, rect); //統計

            for (int i = 0; i < 256; i++)
            {//red, green, blue
                if (PhotoData[2, i] > MaxR)
                    MaxR = PhotoData[2, i];
                if (PhotoData[1, i] > MaxG)
                    MaxG = PhotoData[1, i];
                if (PhotoData[0, i] > MaxB)
                    MaxB = PhotoData[0, i];
            }

            int[] Max = { MaxB, MaxG, MaxR };
            return Max;
        }

    }
}
