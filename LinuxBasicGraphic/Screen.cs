using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LinuxBasicGraphic
{
    public class Screen : IDisposable
    {
        private TTY TargetTerminal;
        private FileStream ScreenBuffer;
        private ScreenInfo info;
        public readonly Native.fb_fix_screeninfo fix;
        public readonly Native.fb_var_screeninfo vari;

        public Screen(TTY terminal, string fb_device)
        {
            TargetTerminal = terminal;
            info = new ScreenInfo(fb_device);
            fix = info.FixedInfo;
            vari = info.VariableInfo;
            ScreenBuffer = File.OpenWrite(fb_device);
        }

        public void Dispose()
        {
            ScreenBuffer.Close();
            TargetTerminal.SetMode(TTY.TTYMode.Text);
        }

        public bool Init()
        {
            return TargetTerminal.SetMode(TTY.TTYMode.Graphics);
        }

        public void DrawPixel(Point location, Color color)
        {
            DrawPixel(location.X, location.Y, color.A, color.R, color.G, color.B);
        }

        public void DrawLine(Point p1, Point p2, Color color)
        {
            if (p1.X != p2.X)
            {
                if (p1.X > p2.X)
                {
                    Point p = p2;
                    p2 = p1;
                    p1 = p;
                }
                double k = (p1.Y - p2.Y) / (p1.X - p2.X);
                for (int x = p1.X; x <= p2.X; x++)
                {
                    int y = (int)((x - p1.X) * k + p1.Y);
                    DrawPixel(x, y, color.A, color.R, color.G, color.B);
                }
            }
            else
            {
                if (p1.Y > p2.Y)
                {
                    Point p = p2;
                    p2 = p1;
                    p1 = p;
                }
                for (int y = p1.Y; y <= p2.Y; y++)
                {
                    DrawPixel(p1.X, y, color.A, color.R, color.G, color.B);
                }
            }
        }

        public void DrawBitmap(Bitmap bitmap)
        {
            for(int x = 0; x < vari.xres; x++)
            {
                for (int y= 0; y < vari.xres; y++)
                {
                    var color = bitmap.GetPixel(x, y);
                    DrawPixel(x, y, color.A, color.R, color.G, color.B);
                }
            }
        }

        public void DrawPixel(int x, int y, byte a, byte r, byte g, byte b)
        {
            var offset = y * fix.line_length + 4 * x;
            ScreenBuffer.Seek(offset, SeekOrigin.Begin);
            ScreenBuffer.WriteByte(b);
            ScreenBuffer.WriteByte(g);
            ScreenBuffer.WriteByte(r);
            ScreenBuffer.WriteByte(a);
        }

        public void Flush()
        {
            ScreenBuffer.Flush();
        }
    }
}
