using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace InvAddIn
{
    public static class PictureDispConverter
    {
        //IPictureDisp guid
        private static Guid iPictureDispGuid = typeof(stdole.IPictureDisp).GUID;

        /// <summary>
        /// Converts an Icon into a IPictureDisp
        /// </summary>
        /// <param name="icon"></param>
        /// <returns></returns>

        public static stdole.IPictureDisp ToIPictureDisp(Icon icon)
        {
            PICTDESC.Icon pictIcon = new PICTDESC.Icon(icon);
            return PictureDispConverter.OleCreatePictureIndirect(pictIcon, ref iPictureDispGuid, true);
        }

        /// <summary>
        /// Converts an image into a IPictureDisp
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static stdole.IPictureDisp ToIPictureDisp(Image image)
        {
            Bitmap bitmap = (image is Bitmap) ? (Bitmap)image : new Bitmap(image);
            PICTDESC.Bitmap pictBit = new PICTDESC.Bitmap(bitmap);
            return PictureDispConverter.OleCreatePictureIndirect(pictBit, ref iPictureDispGuid, true);
        }

        /// <summary>
        /// Converts IPictureDisp to Image if it is possible
        /// </summary>
        /// <param name="pictureDisp">Converted image</param>
        /// <returns>Returns Image if pictureDisp.Type=1. Otherwise returns null</returns>
        /// <remarks></remarks>
        public static Image PictureDispToImage(stdole.IPictureDisp pictureDisp)
        {
            Image image = null;
            if ((pictureDisp != null))
            {
                if (pictureDisp.Type == PICTDESC.PICTYPE_BITMAP)
                {
                    IntPtr paletteHandle = new IntPtr(pictureDisp.hPal);
                    IntPtr bitmapHandle = new IntPtr(pictureDisp.Handle);
                    image = Image.FromHbitmap(bitmapHandle, paletteHandle);
                }

                if (pictureDisp.Type == PICTDESC.PICTYPE_METAFILE)
                {
                    IntPtr handle = new IntPtr(pictureDisp.Handle);
                    image = new System.Drawing.Imaging.Metafile(handle, new System.Drawing.Imaging.WmfPlaceableFileHeader());
                }
            }
            return image;
        }

        /// <summary>
        /// Converts IPictureDisp to Icon if it is possible
        /// </summary>
        /// <param name="pictureDisp">Converted icon</param>
        /// <returns>Returns Image if pictureDisp.Type=3. Otherwise returns null</returns>
        /// <remarks></remarks>
        public static Icon PictureDispToIcon(stdole.IPictureDisp pictureDisp)
        {
            Icon ico = null;
            if (!(pictureDisp == null) && pictureDisp.Type == PICTDESC.PICTYPE_ICON)
            {
                IntPtr handle = new IntPtr(pictureDisp.Handle);
                ico = Icon.FromHandle(handle);
            }
            return ico;
        }

        [DllImport("OleAut32.dll", EntryPoint = "OleCreatePictureIndirect", ExactSpelling = true, PreserveSig = false)]
        private static extern stdole.IPictureDisp OleCreatePictureIndirect([MarshalAs(UnmanagedType.AsAny)] object picdesc, ref Guid iid, bool fOwn);

        private readonly static HandleCollector handleCollector = new HandleCollector("Icon handles", 1000);

        private static class PICTDESC
        {
            //Picture Types
            public const short PICTYPE_UNINITIALIZED = -1;

            public const short PICTYPE_NONE = 0;
            public const short PICTYPE_BITMAP = 1;
            public const short PICTYPE_METAFILE = 2;
            public const short PICTYPE_ICON = 3;
            public const short PICTYPE_ENHMETAFILE = 4;

            [StructLayout(LayoutKind.Sequential)]
            public class Icon
            {
                internal int cbSizeOfStruct = Marshal.SizeOf(typeof(PICTDESC.Icon));
                internal int picType = PICTDESC.PICTYPE_ICON;
                internal IntPtr hicon = IntPtr.Zero;
                internal int unused1 = 0;
                internal int unused2 = 0;

                internal Icon(System.Drawing.Icon icon)
                {
                    this.hicon = icon.ToBitmap().GetHicon();
                }
            }

            [StructLayout(LayoutKind.Sequential)]
            public class Bitmap
            {
                internal int cbSizeOfStruct = Marshal.SizeOf(typeof(PICTDESC.Bitmap));
                internal int picType = PICTDESC.PICTYPE_BITMAP;
                internal IntPtr hbitmap = IntPtr.Zero;
                internal IntPtr hpal = IntPtr.Zero;
                internal int unused = 0;

                internal Bitmap(System.Drawing.Bitmap bitmap)
                {
                    this.hbitmap = bitmap.GetHbitmap();
                }
            }
        }
    }
}