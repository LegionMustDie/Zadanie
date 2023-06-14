using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Zadanie.FolderClass
{
    internal class ClassImage
    {
        public static byte[] ConvertImageToArray(string path)
        {
            Bitmap bitmap = new Bitmap(path);
            ImageFormat format = bitmap.RawFormat;
            var imageConvert = Image.FromFile(path);
            using (var ms = new MemoryStream())
            {
                imageConvert.Save(ms, format);
                return ms.ToArray();
            }
        }

        public static BitmapImage ConvertArrayToImage(byte[] bytes)
        {
            if (bytes != null)
            {
                using (var ms = new MemoryStream())
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.StreamSource = ms;
                    return bitmapImage;
                }
            }
            return null;
        }
    }
}
