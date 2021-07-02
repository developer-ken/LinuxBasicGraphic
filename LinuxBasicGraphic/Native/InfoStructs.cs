using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinuxBasicGraphic.Native
{
    struct fb_fix_screeninfo
    {
        string id;                    /* identification string eg "TT Builtin" */
        ulong smem_start;       /* Start of frame buffer mem */
        /* (physical address) */
        UInt32 smem_len;                 /* Length of frame buffer mem */
        UInt32 type;                     /* see FB_TYPE_*                */
        UInt32 type_aux;                 /* Interleave for interleaved Planes */
        UInt32 visual;                   /* see FB_VISUAL_*              */
        UInt16 xpanstep;                 /* zero if no hardware panning  */
        UInt16 ypanstep;                 /* zero if no hardware panning  */
        UInt16 ywrapstep;                /* zero if no hardware ywrap    */
        UInt32 line_length;              /* length of a line in bytes    */
        ulong mmio_start;       /* Start of Memory Mapped I/O   */
        /* (physical address) */
        UInt32 mmio_len;                 /* Length of Memory Mapped I/O  */
        UInt32 accel;                    /* Indicate to driver which     */
        /*  specific chip/card we have  */
        UInt16 capabilities;             /* see FB_CAP_*                 */
        UInt16[] reserved;//[2]              /* Reserved for future compatibility */
    };

    struct fb_var_screeninfo
    {
        UInt32 xres;                     /* visible resolution           */
        UInt32 yres;
        UInt32 xres_virtual;             /* virtual resolution           */
        UInt32 yres_virtual;
        UInt32 xoffset;                  /* offset from virtual to visible */
        UInt32 yoffset;                  /* resolution                   */

        UInt32 bits_per_pixel;           /* guess what                   */
        UInt32 grayscale;                /* 0 = color, 1 = grayscale,    */
        /* >1 = FOURCC                  */
        fb_bitfield red;         /* bitfield in fb mem if true color, */
        fb_bitfield green;       /* else only length is significant */
        fb_bitfield blue;
        fb_bitfield transp;      /* transparency                 */

        UInt32 nonstd;                   /* != 0 Non standard pixel format */

        UInt32 activate;                 /* see FB_ACTIVATE_*            */

        UInt32 height;                   /* height of picture in mm    */
        UInt32 width;                    /* width of picture in mm     */

        UInt32 accel_flags;              /* (OBSOLETE) see fb_info.flags */

        /* Timing: All values in pixclocks, except pixclock (of course) */
        UInt32 pixclock;                 /* pixel clock in ps (pico seconds) */
        UInt32 left_margin;              /* time from sync to picture    */
        UInt32 right_margin;             /* time from picture to sync    */
        UInt32 upper_margin;             /* time from sync to picture    */
        UInt32 lower_margin;
        UInt32 hsync_len;                /* length of horizontal sync    */
        UInt32 vsync_len;                /* length of vertical sync      */
        UInt32 sync;                     /* see FB_SYNC_*                */
        UInt32 vmode;                    /* see FB_VMODE_*               */
        UInt32 rotate;                   /* angle we rotate counter clockwise */
        UInt32 colorspace;               /* colorspace for FOURCC-based modes */
        UInt32[] reserved;//[4];              /* Reserved for future compatibility */
    };

    struct fb_bitfield
    {
        UInt32 offset;                   /* beginning of bitfield        */
        UInt32 length;                   /* length of bitfield           */
        UInt32 msb_right;                /* != 0 : Most significant bit is */
        /* right */
    };
}
