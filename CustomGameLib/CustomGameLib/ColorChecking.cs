﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Drawing;

namespace Deltin.CustomGameAutomation
{
    partial class CustomGame
    {
        // Waits for a pixel to change its color to another color.
        internal bool WaitForColor(int x, int y, int[] color, int fade, int maxtime)
        {
            Stopwatch wait = new Stopwatch();
            wait.Start();
            while (wait.ElapsedMilliseconds <= maxtime)
            {
                UpdateScreen();
                if (Capture.CompareColor(x, y, color, fade))
                    return true;
                Thread.Sleep(10);
            }
            return false;
        }
        internal bool WaitForColor(Point point, int[] color, int fade, int maxtime)
        {
            return WaitForColor(point.X, point.Y, color, fade, maxtime);
        }

        // Waits for a pixel to change its color.
        internal bool WaitForUpdate(int x, int y, int fade, int maxtime)
        {
            Stopwatch wait = new Stopwatch();
            wait.Start();
            Color startcolor = Capture.GetPixel(x, y);

            while (wait.ElapsedMilliseconds <= maxtime)
            {
                UpdateScreen();
                Color newcolor = Capture.GetPixel(x, y);

                if (Math.Abs(newcolor.R - startcolor.R) > fade ||
                    Math.Abs(newcolor.G - startcolor.G) > fade ||
                    Math.Abs(newcolor.B - startcolor.B) > fade)
                    return true;

                Thread.Sleep(10);
            }

            return false;
        }
        internal bool WaitForUpdate(Point point, int fade, int maxtime)
        {
            return WaitForUpdate(point.X, point.Y, fade, maxtime);
        }
    }
}
