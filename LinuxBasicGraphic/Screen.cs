using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinuxBasicGraphic
{
    public class Screen : IDisposable
    {
        private TTY TargetTerminal;
        private StreamWriter ScreenBuffer;

        public Screen(TTY terminal,string fb_device)
        {
            TargetTerminal = terminal;
            ScreenBuffer = new StreamWriter(fb_device);
        }

        public void Dispose()
        {
            TargetTerminal.SetMode(TTY.TTYMode.Text);
        }

        public bool Init()
        {
            return TargetTerminal.SetMode(TTY.TTYMode.Graphics);
        }

        public void DrawPixel()
        {

        }
    }
}
