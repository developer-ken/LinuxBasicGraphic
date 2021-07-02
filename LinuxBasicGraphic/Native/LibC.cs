using System;
using System.Runtime.InteropServices;

namespace LinuxBasicGraphic.Native
{
    internal class LibC
    {

        [DllImport("libc", EntryPoint = "ioctl", SetLastError = true)]
        internal extern static int ioctl(IntPtr fd, int request, ref fb_fix_screeninfo data);

        [DllImport("libc", EntryPoint = "ioctl", SetLastError = true)]
        internal extern static int ioctl(IntPtr fd, int request, ref fb_var_screeninfo data);

        [DllImport("libc", EntryPoint = "ioctl", SetLastError = true)]
        internal extern static int ioctl(IntPtr fd, int request, int data);

        [DllImport("libc", EntryPoint = "open", SetLastError = true, CharSet = CharSet.Unicode)]
        internal extern static IntPtr open(string path, int access, int mode);

        [DllImport("libc", EntryPoint = "close", SetLastError = true)]
        internal extern static IntPtr close(IntPtr handle);


        public const int
            O_RDONLY = 1,
            O_WRONLY = 2,
            O_RDWR = 4,
            O_CREATE = 0x0100,
            O_TRUNC = 0x0200,
            O_EXCL = 0x0400,
            O_APPEND = 0x0800,
            O_TEXT = 0x4000,
            O_BINARY = 0x8000;

        public const int KDSETMODE = 0x4B3A;
        public const int
            KD_GRAPHICS = 0x01,
            KD_TEXT = 0x00;

        public const int
            FBIOGET_VSCREENINFO = 0x4600,
            FBIOGET_FSCREENINFO = 0x4602;

    }
}
