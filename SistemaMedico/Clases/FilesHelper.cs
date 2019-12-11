using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace SistemaMedico.Clases
{
    public class FilesHelper
    {

        public static string UploadPhoto(HttpPostedFileBase file, string folder)
        {

            var path = string.Empty;
            var pic = string.Empty;

            if (file != null)
            {
                pic = Path.GetFileName(file.FileName);
                path = Path.Combine(HttpContext.Current.Server.MapPath("/"), folder, pic);
              
                file.SaveAs(path);

                using (MemoryStream ms = new MemoryStream())
                {
                    Image img = RedimensionarImagen(file.InputStream);
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }
            }
            return pic;
        }

        public static FileStream GetFile(string filePath)
        {
            string absoluteFilePath = HttpContext.Current.Server.MapPath("/") + filePath;

            if (!File.Exists(absoluteFilePath))
            {
                return null;
            }

            FileStream fileStream = File.Open(absoluteFilePath, FileMode.Open);
            return fileStream;
        }

        private static Image RedimensionarImagen(Stream stream)
        {
            // Se crea un objeto Image, que contiene las propiedades de la imagen
            Image img = Image.FromStream(stream);

            // Tamaño máximo de la imagen (altura o anchura)
            const int max = 200;

            int h = img.Height;
            int w = img.Width;
            int newH, newW;

            if (h > w && h > max)
            {
                // Si la imagen es vertical y la altura es mayor que max,
                // se redefinen las dimensiones.
                newH = max;
                newW = (w * max) / h;
            }
            else if (w > h && w > max)
            {
                // Si la imagen es horizontal y la anchura es mayor que max,
                // se redefinen las dimensiones.
                newW = max;
                newH = (h * max) / w;
            }
            else
            {
                newH = h;
                newW = w;
            }
            if (h != newH && w != newW)
            {
                // Si las dimensiones cambiaron, se modifica la imagen
                Bitmap newImg = new Bitmap(img, newW, newH);
                Graphics g = Graphics.FromImage(newImg);
                g.InterpolationMode =
                  System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
                g.DrawImage(img, 0, 0, newImg.Width, newImg.Height);
                return newImg;
            }
            else
                return img;
        }
    }
}