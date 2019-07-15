﻿using System;
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
        private static Bitmap bitmap;
        private static int COLOR_SIZE_RANGE = 256;

        public Bitmap getGray(Image photo)//灰階
        {
            bitmap = new Bitmap(photo);
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
        public Bitmap getNegative(Image photo)//負片
        {
            bitmap = new Bitmap(photo);
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

        public Bitmap getLogarithmic1(Image photo ,int c)//C * Log( x + 1)
        {
            bitmap = new Bitmap(photo);
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

        public Bitmap getLogarithmic2(Image photo , int c, double r) // C * R的gamma次方
        {
            bitmap = new Bitmap(photo);
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
        public Bitmap getHistogramEqualization(Image photo) // 值方圖
        {
            bitmap = new Bitmap(photo);
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


        public int[,] getHistogram(Image photo)//取得RGB出現次數
        {
            bitmap = new Bitmap(photo);
            int W = bitmap.Width;
            int H = bitmap.Height;
            int total = W * H;

            Rectangle rect = new Rectangle(0, 0, W, H);//放置圖片空間大小

            //統計
            int[,] PhotoData = new int[3, COLOR_SIZE_RANGE];
            HistogramEqualizationStatistics(bitmap, ref PhotoData, rect); //統計

            return PhotoData;
        }

        public int[] getMixPixel(Image photo)//取得RGB的最大值
        {
            bitmap = new Bitmap(photo);
            int W = bitmap.Width;
            int H = bitmap.Height;
            int total = W * H;
            int MaxR = 0, MaxG = 0, MaxB = 0;
            Rectangle rect = new Rectangle(0, 0, W, H);//放置圖片空間大小

            //統計
            int[,] PhotoData = new int[3, COLOR_SIZE_RANGE];
            HistogramEqualizationStatistics(bitmap, ref PhotoData, rect); //統計

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

        public Bitmap getBinaryThresholding(Image photo , int Value) //二值化
        {
            bitmap = getGray(photo);
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

        public Bitmap getOtsuMethod(Image photo)//歐蘇法
        {
            bitmap = getGray(photo);
            int W = bitmap.Width;
            int H = bitmap.Height;
            int total = W * H;
            double threshold = 0;
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
            double w1, w2, u1temp, u2temp, u1, u2, deltaTmp, deltaMax = 0;
            int threshold = 0;

            for (int i = 0; i < COLOR_SIZE_RANGE; i++)//遍历所有从0到255灰度级的阈值分割条件，测试哪一个的类间方差最大
            {
                w1 = w2 = u1temp = u2temp = u1 = u2 = deltaTmp = 0;
                for (int j = 0; j < COLOR_SIZE_RANGE; j++)
                {
                    if (j <= i)//背景
                    {
                        w1 += Data[0, j];
                        u1temp += j * Data[0, j];
                    }
                    else//前景
                    {
                        w2 += Data[0, j];
                        u2temp += j * Data[0, j];
                    }
                }
                u1 = u1temp / w1;
                u2 = u2temp / w2;
                deltaTmp = w1 * w2 * Math.Pow((u1 - u2), 2); //簡化公式 g = w1 * w2 * (u1 - u2) ^ 2
                if (deltaTmp > deltaMax)
                {
                    deltaMax = deltaTmp;
                    threshold = i;
                }
            }

            return threshold;
        }

    }
}