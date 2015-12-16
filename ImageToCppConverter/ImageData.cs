using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageToCppConverter
{
    public class ImageData
    {
        public int Height { get; set; }
        public int Width { get; set; }

        public string Name { get; set; }
        public int BitsPerColor { get; set; }
        public List<int> Pixels { get; protected set; } = new List<int>();

        internal static ImageData FromBitmap(Bitmap image)
        {
            var imgd = new ImageData()
            {
                Height = image.Height,
                Width = image.Width,
                //BitsPerColor = image.PixelFormat
            };

            for (int x = 0; x < imgd.Width; x++)
                for (int y = 0; y < imgd.Height; y++)
                    imgd.Pixels.Add(image.GetPixel(x, y).ToArgb());

            return imgd;
        }
    }
}
