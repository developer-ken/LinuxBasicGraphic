using LinuxBasicGraphic.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinuxBasicGraphic
{
    public class ScreenInfo
    {
        string dev;
        public ScreenInfo(string fb_device)
        {
            dev = fb_device;
        }
        Native.fb_fix_screeninfo FixedInfo
        {
            get
            {
                var f = LibC.open(dev, LibC.O_RDONLY, 0);
                Native.fb_fix_screeninfo finfo = new fb_fix_screeninfo();
                LibC.ioctl(f, LibC.FBIOGET_FSCREENINFO, ref finfo);
                return finfo;
            }
        }
        Native.fb_var_screeninfo VariableInfo
        {
            get
            {
                var f = LibC.open(dev, LibC.O_RDONLY, 0);
                Native.fb_var_screeninfo finfo = new fb_var_screeninfo();
                LibC.ioctl(f, LibC.FBIOGET_FSCREENINFO, ref finfo);
                return finfo;
            }
        }
    }
}
