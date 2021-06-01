using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamSocXe
{
    class Ulti
    {
        public static string html = @"C:\Users\THANH\Desktop\New folder\ok.html";
        public static string filepath = @"C:\Users\THANH\Desktop\New folder\a.txt";
        public static string fileSave = @"C:\Users\THANH\Desktop\test.docx";
        public static byte[] ImageToByteArray(Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                   imageIn.Save(ms, ImageFormat.Png);  //neu chup and luu
            //    imageIn.Save(ms, imageIn.RawFormat); //neu load tu may tinh
                return ms.ToArray();
            }
        }
        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);

            return returnImage;
        }
    }
}
