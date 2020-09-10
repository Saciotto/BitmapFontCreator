using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace BitmapFontCreator
{
    class Program
    {
        private static SizeF MesureTile(String text, Font font, StringFormat stringFormat, int horizontalPadding, int verticalPadding)
        {
            Image image = new Bitmap(1, 1, PixelFormat.Format24bppRgb);
            Graphics drawing = Graphics.FromImage(image);
            SizeF textSize = drawing.MeasureString(text, font, 100, stringFormat);
            image.Dispose();
            drawing.Dispose();
            textSize.Width += horizontalPadding * 2;
            textSize.Height += verticalPadding;
            return textSize;
        }

        private static Image CreateCharImage(char c, String fontName, int size, int horizontalPadding, int verticalPadding)
        {
            String text = c.ToString();
            StringFormat stringFormat = new StringFormat(StringFormat.GenericTypographic);
            Font font = new Font(fontName, size, FontStyle.Regular);
            SizeF textSize = MesureTile(text, font, stringFormat, horizontalPadding, verticalPadding);
            Image image = new Bitmap((int)textSize.Width, (int)textSize.Height, PixelFormat.Format24bppRgb);
            Graphics drawing = Graphics.FromImage(image);
            drawing.Clear(Color.White);
            Brush textBrush = new SolidBrush(Color.Black);
            stringFormat.Alignment = StringAlignment.Center;
            RectangleF rect = new RectangleF(0, 0, textSize.Width, textSize.Height);
            drawing.DrawString(text, font, Brushes.Black, rect, stringFormat);
            textBrush.Dispose();
            drawing.Dispose();
            return image;
        }

        private static Image CreateSpaceImage(String fontName, int size, int horizontalPadding, int verticalPadding)
        {
            String text = "i";
            StringFormat stringFormat = new StringFormat(StringFormat.GenericTypographic);
            Font font = new Font(fontName, size, FontStyle.Regular);
            SizeF textSize = MesureTile(text, font, stringFormat, horizontalPadding, verticalPadding);
            Image image = new Bitmap((int)textSize.Width, (int)textSize.Height, PixelFormat.Format24bppRgb);
            Graphics drawing = Graphics.FromImage(image);
            drawing.Clear(Color.White);
            drawing.Dispose();
            return image;
        }

        static void Main(string[] args)
        {
            string fontName = "Arial";
            int size = 16;
            int horizontalPadding = 1;
            int verticalPadding = 0;

            if (args.Length > 0) fontName = args[0];
            if (args.Length > 1) size = int.Parse(args[1]);
            if (args.Length > 2) horizontalPadding = int.Parse(args[2]);
            if (args.Length > 3) verticalPadding = int.Parse(args[3]);

            System.IO.Directory.CreateDirectory(fontName);

            String name = System.IO.Path.Combine(fontName, "C20.bmp");
            Image image = CreateSpaceImage(fontName, size, horizontalPadding, verticalPadding);
            image.Save(name, ImageFormat.Bmp);
            image.Dispose();

            String symbols = "!\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~€™¡¢£¥©ª«®²³¹º»¿ÀÁÂÃÄÇÈÉÊËÍÎÏÑÓÔÕÚÛÜàáâãçèéêëíîïñóôõ÷úûü";

            foreach (char c in symbols)
            {
                image = CreateCharImage((char)c, fontName, size, horizontalPadding, verticalPadding);
                name = String.Format("C{0:X}.bmp", (int)c);
                name = System.IO.Path.Combine(fontName, name);
                image.Save(name, ImageFormat.Bmp);
                image.Dispose();
            }
        }
    }
}
