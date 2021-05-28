using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamSocXe
{
    class Ulti
    {
        private byte[] ImageToByteArray(Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                //    imageIn.Save(ms, ImageFormat.Png);  tuy chinh format
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }
        private Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);

            return returnImage;
        }
    }
}
