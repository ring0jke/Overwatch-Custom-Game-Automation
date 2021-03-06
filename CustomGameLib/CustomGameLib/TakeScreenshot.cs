﻿using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Deltin.CustomGameAutomation
{
    partial class CustomGame
    {
        private readonly ScreenshotMethod ScreenshotMethod;
        internal readonly object ScreenshotLock = new object();

        // This grabs a screenshot of the Overwatch handle
        internal void UpdateScreen()
        {
            if (Disposed)
                throw new ObjectDisposedException("This CustomGame object has already been disposed.");

            // This will take a screenshot of the Overwatch window.
            if (Monitor.TryEnter(ScreenshotLock)) // (1) If another thread is already updating the screen...
            {
                try
                {
                    Validate();
                    SetupWindow();

                    switch (ScreenshotMethod)
                    {
                        case ScreenshotMethod.BitBlt:
                            ScreenshotBitBlt();
                            break;

                        case ScreenshotMethod.ScreenCopy:
                            ScreenshotScreenCopy();
                            break;

                        default:
                            throw new NotImplementedException();
                    }
                }
                finally
                {
                    Monitor.Exit(ScreenshotLock);
                }
            }
            else
            {
                // (1) ...Just wait for the thread to finish updating it then continue.
                while (!Monitor.TryEnter(ScreenshotLock)) Thread.Sleep(10);
                Monitor.Exit(ScreenshotLock);
            }
        }

        private void ScreenshotBitBlt()
        {
            try
            {
                // get the hDC of the target window
                IntPtr hdcSrc = User32.GetDC(OverwatchHandle);
                // get the size
                int width = Rectangles.ENTIRE_SCREEN.Width + Points.BITBLT_WINDOW_LOCATION.X;
                int height = Rectangles.ENTIRE_SCREEN.Height + Points.BITBLT_WINDOW_LOCATION.Y;
                // create a device context we can copy to
                IntPtr hdcDest = Gdi32.CreateCompatibleDC(hdcSrc);
                // create a bitmap we can copy it to,
                // using GetDeviceCaps to get the width/height
                IntPtr hBitmap = Gdi32.CreateCompatibleBitmap(hdcSrc, width, height);
                // select the bitmap object
                IntPtr hOld = Gdi32.SelectObject(hdcDest, hBitmap);
                // bitblt over
                Gdi32.BitBlt(hdcDest, Points.BITBLT_WINDOW_LOCATION.X, Points.BITBLT_WINDOW_LOCATION.Y, width, height, hdcSrc, 0, 0, (uint)Gdi32.TernaryRasterOperations.SRCCOPY | (uint)Gdi32.TernaryRasterOperations.CAPTUREBLT);
                // restore selection
                Gdi32.SelectObject(hdcDest, hOld);

                if (Capture != null)
                    Capture.Dispose();
                Capture = new DirectBitmap(hdcSrc, hBitmap);

                // clean up 
                Gdi32.DeleteDC(hdcDest);
                User32.ReleaseDC(OverwatchHandle, hdcSrc);
                // free up the Bitmap object
                Gdi32.DeleteObject(hBitmap);
            }
            catch (ExternalException)
            {
                // Failed to capture window, usually because it was closed.
#if DEBUG
                CustomGameDebug.WriteLine("Failed to capture window. Is it closed?");
#endif
            }
        }

        private void ScreenshotScreenCopy()
        {
            int width = Rectangles.ENTIRE_SCREEN.Width + Points.BITBLT_WINDOW_LOCATION.X;
            int height = Rectangles.ENTIRE_SCREEN.Height + Points.BITBLT_WINDOW_LOCATION.Y;

            if (Capture != null)
                Capture.Dispose();
            Bitmap bmp = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(0, 0, 0, 0, new Size(width, height), CopyPixelOperation.SourceCopy);
            g.Dispose();
            Capture = new DirectBitmap(bmp);
            bmp.Dispose();
        }

        /// <summary>
        /// Takes a screenshot of the Overwatch window and saves it as an image to the specified path.
        /// </summary>
        /// <param name="path">Path to save screenshot to.</param>
        public void SaveScreenshot(string path)
        {
            UpdateScreen();

            Capture.Save(path);
        }

        /// <summary>
        /// Positions the Overwatch window to be usable by the CustomGame class.
        /// </summary>
        public void SetupWindow()
        {
            Validate();

            switch (ScreenshotMethod)
            {
                case ScreenshotMethod.ScreenCopy:
                    User32.SetForegroundWindow(OverwatchHandle);
                    break;

                case ScreenshotMethod.BitBlt:
                    User32.ShowWindow(OverwatchHandle, User32.nCmdShow.SW_SHOWNOACTIVATE);
                    break;
            }

            User32.MoveWindow(OverwatchHandle, Points.BITBLT_WINDOW_LOCATION.X, Points.BITBLT_WINDOW_LOCATION.Y, Rectangles.ENTIRE_SCREEN.Width, Rectangles.ENTIRE_SCREEN.Height, false);
        }
    }

#pragma warning disable CS1591
    /// <summary>
    /// Stores Overwatch's capture data.
    /// </summary>
    [Serializable]
    public class DirectBitmap : IDisposable
    {
#region Public Fields
        public int Width { get; private set; }
        public int Height { get; private set; }
#endregion

#region Private Fields
        private readonly byte[] Bytes;
        private readonly int BytesPerLine;
        private readonly bool Inverted = false;
#endregion

#region Constructors
        // From bytes.
        internal DirectBitmap(byte[] bytes, int width, int height, bool inverted = false)
        {
            Bytes = bytes;
            Width = width;
            Height = height;
            Inverted = inverted;
            BytesPerLine = width * 4;

        }
        // From hBitmap.
        internal DirectBitmap(IntPtr hdcSrc, IntPtr hBitmap)
        {
            Gdi32.BITMAPINFO bmi = new Gdi32.BITMAPINFO();
            bmi.bmiHeader.biSize = (uint)Marshal.SizeOf(bmi.bmiHeader);
            Gdi32.GetDIBits(hdcSrc, hBitmap, 0, 0, null, ref bmi, Gdi32.DIB_Color_Mode.DIB_RGB_COLORS);

            Bytes = new byte[bmi.bmiHeader.biSizeImage];

            bmi.bmiHeader.biBitCount = 32;
            bmi.bmiHeader.biCompression = Gdi32.BitmapCompressionMode.BI_RGB;
            bmi.bmiHeader.biHeight = Math.Abs(bmi.bmiHeader.biHeight);
            Gdi32.GetDIBits(hdcSrc, hBitmap, 0, (uint)bmi.bmiHeader.biHeight,
                Bytes, ref bmi, Gdi32.DIB_Color_Mode.DIB_RGB_COLORS);

            Width = bmi.bmiHeader.biWidth;
            Height = bmi.bmiHeader.biHeight;
            BytesPerLine = Width * 4;

            Inverted = true;
        }
        // From another db
        public DirectBitmap(DirectBitmap other)
        {
            //Msvcrt.memcpy(Bytes, other.Bytes, other.Bytes.Length);
            Bytes = other.Bytes;
            Width = other.Width;
            Height = other.Height;
            BytesPerLine = Width * 4;
        }
        // From a bitmap
        public DirectBitmap(Bitmap bitmap, bool disposeBitmap = false)
        {
            var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.WriteOnly, bitmap.PixelFormat);

            int size = bitmap.Width * bitmap.Height * 4;
            Bytes = new byte[size];
            Marshal.Copy(bitmapData.Scan0, Bytes, 0, size);
            bitmap.UnlockBits(bitmapData);

            Width = bitmap.Width;
            Height = bitmap.Height;
            BytesPerLine = Width * 4;

            if (disposeBitmap)
                bitmap.Dispose();
        }
        // From a file
        public DirectBitmap(string file) : this(new Bitmap(file), true)
        {
        }
#endregion

#region Public Methods
        public Color GetPixel(int x, int y)
        {
            GetInternalLocation(x, y, out x, out y);
            var offset = GetByteIndexLocation(x, y);

            int a = Bytes[offset + 3],
                r = Bytes[offset + 2],
                g = Bytes[offset + 1],
                b = Bytes[offset + 0];

            return Color.FromArgb(a, r, g, b);
        }

        public void SetPixel(int x, int y, Color color)
        {
            GetInternalLocation(x, y, out x, out y);
            var offset = GetByteIndexLocation(x, y);

            Bytes[offset + 3] = color.A;
            Bytes[offset + 2] = color.R;
            Bytes[offset + 1] = color.G;
            Bytes[offset + 0] = color.B;
        }

        public bool CompareColor(int x, int y, int[] color, int fade)
        {
            Color pixelColor = GetPixel(x, y);
            return Math.Abs(pixelColor.R - color[0]) < fade
                && Math.Abs(pixelColor.G - color[1]) < fade
                && Math.Abs(pixelColor.B - color[2]) < fade;
        }
        public bool CompareColor(Point point, int[] color, int fade)
        {
            return CompareColor(point.X, point.Y, color, fade);
        }

        public bool CompareColor(int x1, int y1, int x2, int y2, int fade)
        {
            Color pixelColor1 = GetPixel(x1, y1);
            Color pixelColor2 = GetPixel(x2, y2);
            return Math.Abs(pixelColor1.R - pixelColor2.R) < fade
                && Math.Abs(pixelColor1.G - pixelColor2.G) < fade
                && Math.Abs(pixelColor1.B - pixelColor2.B) < fade;
        }
        public bool CompareColor(Point point1, Point point2, int fade)
        {
            return CompareColor(point1.X, point1.Y, point2.X, point2.Y, fade);
        }

        public bool CompareColor(int x, int y, int[] min, int[] max)
        {
            Color pixelColor = GetPixel(x, y);
            return min[0] < pixelColor.R && pixelColor.R < max[0]
                && min[1] < pixelColor.G && pixelColor.G < max[1]
                && min[2] < pixelColor.B && pixelColor.B < max[2];
        }
        public bool CompareColor(Point point, int[] min, int[] max)
        {
            return CompareColor(point.X, point.Y, min, max);
        }

        internal bool CompareTo(Point scanAt, DirectBitmap other, int fade, double min, DBCompareFlags flags)
        {
            int maxFail = (int)((double)other.Width * other.Height * ((100 - min) / 100));
            int pixelsFailed = 0;
            bool failed = false;

            Action<int, ParallelLoopState> check = new Action<int, ParallelLoopState>((x, loopState) =>
            {
                for (int y = 0; y < other.Height && !failed; y++)
                {
                    Color pixelColor = other.GetPixel(x, y);
                    if ((flags.HasFlag(DBCompareFlags.IgnoreBlack) && pixelColor == Color.FromArgb(255, 0, 0, 0))
                    || (flags.HasFlag(DBCompareFlags.IgnoreWhite) && pixelColor == Color.FromArgb(255, 255, 255, 255)))
                        continue;
                    else if (!CompareColor(x + scanAt.X, y + scanAt.Y, pixelColor.ToInt(), fade))
                        pixelsFailed++;

                    failed = pixelsFailed >= maxFail;

                    if (loopState != null && failed)
                        loopState.Break();
                }
            });

            if (!flags.HasFlag(DBCompareFlags.Multithread))
                for (int x = 0; x < other.Width && !failed; x++)
                    check.Invoke(x, null);
            else
                Parallel.For(0, other.Width, check);

            return !failed;
        }
        internal bool CompareTo(DirectBitmap other, int fade, double min, DBCompareFlags flags)
        {
            return CompareTo(new Point(0, 0), other, fade, min, flags);
        }

        internal bool CompareTo(Point scanAt, DirectBitmap markup, int[] blackColor, int fade, double min)
        {

            int maxFail = (int)((double)markup.Width * markup.Height * ((100 - min) / 100));
            int pixelsFailed = 0;
            bool failed = false;

            for (int x = 0; x < markup.Width && !failed; x++)
                for (int y = 0; y < markup.Height && !failed; y++)
                {
                    if (markup.GetPixel(x, y) == Color.FromArgb(0, 0, 0) == CompareColor(scanAt.X + x, scanAt.Y + y, blackColor, fade) == false)
                        pixelsFailed++;

                    failed = pixelsFailed >= maxFail;
                }

            return !failed;
        }

        /*
        internal bool CompareTo(Point scanAt, DirectBitmap other, int fade, float min, DBCompareFlags flags = DBCompareFlags.None, int[] blackColor = null)
        {
            bool ignoreBlack = flags.HasFlag(DBCompareFlags.IgnoreBlack),
                ignoreWhite = flags.HasFlag(DBCompareFlags.IgnoreWhite),
                multithread = flags.HasFlag(DBCompareFlags.Multithread);

            if (other == null)
                throw new ArgumentNullException(nameof(other));

            if (ignoreBlack && blackColor != null)
                throw new Exception($"{nameof(flags)} has the flag {DBCompareFlags.IgnoreBlack} and {nameof(blackColor)} isn't null.");

            float maxFail = (other.Width * other.Height) * min;
            int pixelsFailed = 0;
            bool failed = false;

            Action<int, ParallelLoopState> check = new Action<int, ParallelLoopState>((x, loopState) =>
            {
                for (int y = 0; y < other.Height && !failed; y++)
                {
                    Color pixelColor = other.GetPixel(x, y);

                    bool pixelIsBlack = pixelColor == Color.FromArgb(255, 0, 0, 0);
                    bool pixelIsWhite = pixelColor == Color.FromArgb(255, 255, 255, 255);

                    if ((ignoreBlack && pixelIsBlack) || (ignoreWhite && pixelIsWhite))
                        continue;

                    if (pixelIsBlack && blackColor != null)
                    {
                        if (!CompareColor(x + scanAt.X, y + scanAt.Y, blackColor, fade))
                            pixelsFailed++;
                    }
                    else if (!CompareColor(x + scanAt.X, y + scanAt.Y, pixelColor.ToInt(), fade))
                        pixelsFailed++;

                    failed = pixelsFailed >= maxFail;

                    if (loopState != null && failed)
                        loopState.Break();
                }
            });

            if (!flags.HasFlag(DBCompareFlags.Multithread))
                for (int x = 0; x < other.Width && !failed; x++)
                    check.Invoke(x, null);
            else
                Parallel.For(0, other.Width, check);

            return !failed;
        }
        internal bool CompareToMarkup(Point scanAt, DirectBitmap markup, int[] blackColor, int fade, float min) => CompareTo(scanAt, markup, fade, min, DBCompareFlags.IgnoreWhite, blackColor);
        */

        public DirectBitmap Clone()
        {
            return new DirectBitmap(this);
        }
        public DirectBitmap Clone(int x, int y, int width, int height)
        {
            if (Inverted)
            {
                GetInternalLocation(x, y, out x, out y);
                y -= height - 1;
            }

            int byteCount = width * height * 4;
            byte[] newBytes = new byte[byteCount];

            int index = 0;
            for (int yi = y; yi < y + height; yi++)
                for (int xi = x; xi < x + width; xi++)
                {
                    int i = GetByteIndexLocation(xi, yi);
                    newBytes[index + 3] = Bytes[i + 3]; // A
                    newBytes[index + 2] = Bytes[i + 2]; // R
                    newBytes[index + 1] = Bytes[i + 1]; // G
                    newBytes[index + 0] = Bytes[i + 0]; // B

                    index += 4;
                }

            return new DirectBitmap(newBytes, width, height, Inverted);
        }
        public DirectBitmap Clone(Rectangle rectangle)
        {
            return Clone(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
        }

        public Bitmap CloneAsBitmap()
        {
            return ToBitmap();
        }
        public Bitmap CloneAsBitmap(int x, int y, int width, int height)
        {
            DirectBitmap dbClone = Clone(x, y, width, height);
            Bitmap bmp = dbClone.ToBitmap();
            dbClone.Dispose();
            return bmp;
        }
        public Bitmap CloneAsBitmap(Rectangle rectangle)
        {
            return CloneAsBitmap(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
        }

        public void Save(string location)
        {
            Bitmap bmp = ToBitmap();
            bmp.Save(location);
            bmp.Dispose();
        }

        public Bitmap ToBitmap()
        {
            Bitmap bmp = new Bitmap(Width, Height, PixelFormat.Format32bppArgb);
            var bitmapData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, bmp.PixelFormat);

            byte[] saveBytes;
            if (Inverted)
                saveBytes = InvertYAxisNew();
            else
                saveBytes = Bytes;

            Marshal.Copy(saveBytes, 0, bitmapData.Scan0, saveBytes.Length);
            bmp.UnlockBits(bitmapData);

            return bmp;
        }

        public bool IsIdenticle(DirectBitmap other)
        {
            return Bytes.Length == other.Bytes.Length && 
                Width == other.Width && Height == other.Height && 
                Msvcrt.memcmp(Bytes, other.Bytes, Bytes.Length) == 0;
        }

        public void Dispose()
        {
        }
#endregion

#region Private Methods
        // Returns the internal location of the specified pixel as it is stored in the Bytes[] array.
        private void GetInternalLocation(int x, int y, out int resultX, out int resultY)
        {
            if (Inverted)
            {
                resultX = x;
                resultY = Height - 1 - y;
            }
            else
            {
                resultX = x;
                resultY = y;
            }
        }

        // Gets the index of the bytes of the specified pixel in the Bytes[] array.
        // the returned value is the B value. +1 is the G value, +2 is the R value, and +3 is the Alpha value.
        private int GetByteIndexLocation(int x, int y)
        {
            return ((y * Width) + x) * 4;
        }

        // Flips the Bytes[] array vertically so the image is flipped.
        internal void InvertYAxis()
        {
            for (int i = 0; i < Width * Height * 4 / 2; i += BytesPerLine)
                for (int j = 0; j < BytesPerLine; j += 4)
                    for (int b = 0; b < 4; b++)
                    {
                        int findex = i + j + b,
                            lindex = Bytes.Length - (i + BytesPerLine) + j + b;
                        byte hold = Bytes[findex];
                        Bytes[findex] = Bytes[lindex];
                        Bytes[lindex] = hold;
                    }
        }

        // Flips the Bytes[] array vertically so the image is flipped.
        private byte[] InvertYAxisNew()
        {
            byte[] inverted = new byte[Bytes.Length];
            for (int i = 0; i < (Width * Height * 4); i += BytesPerLine)
                for (int j = 0; j < BytesPerLine; j += 4)
                {
                    inverted[i + j + 0] = Bytes[Bytes.Length - (i + BytesPerLine) + j + 0];
                    inverted[i + j + 1] = Bytes[Bytes.Length - (i + BytesPerLine) + j + 1];
                    inverted[i + j + 2] = Bytes[Bytes.Length - (i + BytesPerLine) + j + 2];
                    inverted[i + j + 3] = Bytes[Bytes.Length - (i + BytesPerLine) + j + 3];
                }
            return inverted;
        }
#endregion
    }
#pragma warning restore CS1591
}
