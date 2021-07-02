using LinuxBasicGraphic.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinuxBasicGraphic
{
    public class TTY
    {
        string device;

        public TTY(string device = "/dev/tty0")
        {
            this.device = device;
        }

        public bool SetMode(TTYMode mode)
        {
            var f = LibC.open(device, LibC.O_RDONLY, 0);
            if (f == IntPtr.Zero) return false;
            bool succ = LibC.ioctl(f, LibC.KDSETMODE, (int)mode) >= 0;
            LibC.close(f);
            return succ;
        }

        public enum TTYMode
        {
            Text = LibC.KD_TEXT, Graphics = LibC.KD_GRAPHICS
        }
    }
}
