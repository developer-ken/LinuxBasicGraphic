using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinuxBasicGraphic.Native
{
    public struct fb_fix_screeninfo
    {
        public string id;                    /* identification string eg "TT Builtin" */
        public ulong smem_start;       /* Start of frame buffer mem */
        /* (physical address) */
        public UInt32 smem_len;                 /* Length of frame buffer mem */
        public UInt32 type;                     /* see FB_TYPE_*                */
        public UInt32 type_aux;                 /* Interleave for interleaved Planes */
        public UInt32 visual;                   /* see FB_VISUAL_*              */
        public UInt16 xpanstep;                 /* zero if no hardware panning  */
        public UInt16 ypanstep;                 /* zero if no hardware panning  */
        public UInt16 ywrapstep;                /* zero if no hardware ywrap    */
        public UInt32 line_length;              /* length of a line in bytes    */
        public ulong mmio_start;       /* Start of Memory Mapped I/O   */
        /* (physical address) */
        public UInt32 mmio_len;                 /* Length of Memory Mapped I/O  */
        public UInt32 accel;                    /* Indicate to driver which     */
        /*  specific chip/card we have  */
        public UInt16 capabilities;             /* see FB_CAP_*                 */
        public UInt16[] reserved;//[2]              /* Reserved for future compatibility */
    };

    public struct fb_var_screeninfo
    {
        public UInt32 xres;                     /* visible resolution           */
        public UInt32 yres;
        public UInt32 xres_virtual;             /* virtual resolution           */
        public UInt32 yres_virtual;
        public UInt32 xoffset;                  /* offset from virtual to visible */
        public UInt32 yoffset;                  /* resolution                   */

        public UInt32 bits_per_pixel;           /* guess what                   */
        public UInt32 grayscale;                /* 0 = color, 1 = grayscale,    */
        /* >1 = FOURCC                  */
        public fb_bitfield red;         /* bitfield in fb mem if true color, */
        public fb_bitfield green;       /* else only length is significant */
        public fb_bitfield blue;
        public fb_bitfield transp;      /* transparency                 */

        public UInt32 nonstd;                   /* != 0 Non standard pixel format */

        public UInt32 activate;                 /* see FB_ACTIVATE_*            */

        public UInt32 height;                   /* height of picture in mm    */
        public UInt32 width;                    /* width of picture in mm     */

        public UInt32 accel_flags;              /* (OBSOLETE) see fb_info.flags */

        /* Timing: All values in pixclocks, except pixclock (of course) */
        public UInt32 pixclock;                 /* pixel clock in ps (pico seconds) */
        public UInt32 left_margin;              /* time from sync to picture    */
        public UInt32 right_margin;             /* time from picture to sync    */
        public UInt32 upper_margin;             /* time from sync to picture    */
        public UInt32 lower_margin;
        public UInt32 hsync_len;                /* length of horizontal sync    */
        public UInt32 vsync_len;                /* length of vertical sync      */
        public UInt32 sync;                     /* see FB_SYNC_*                */
        public UInt32 vmode;                    /* see FB_VMODE_*               */
        public UInt32 rotate;                   /* angle we rotate counter clockwise */
        public UInt32 colorspace;               /* colorspace for FOURCC-based modes */
        public UInt32[] reserved;//[4];              /* Reserved for future compatibility */
    };

    public struct fb_bitfield
    {
        public UInt32 offset;                   /* beginning of bitfield        */
        public UInt32 length;                   /* length of bitfield           */
        public UInt32 msb_right;                /* != 0 : Most significant bit is */
        /* right */
    };
}
