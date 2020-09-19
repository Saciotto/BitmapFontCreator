using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace BitmapFontCreator
{
    class FontBuilder
    {
        public int LeftPadding { get; set; }
        public int RightPadding { get; set; }
        public int TopPadding { get; set; }
        public int BottomPadding { get; set; }
        public int Size { get; set; }

        private readonly String fontFamily;
        private Font font;

        public FontBuilder(String fontFamily)
        {
            this.fontFamily = fontFamily;
            Size = 16;
        }

        public void Build()
        {
            font = new Font(fontFamily, Size, FontStyle.Regular);
            String symbols = " !\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~€™¡¢£¥©ª«®²³¹º»¿ÀÁÂÃÄÇÈÉÊËÍÎÏÑÓÔÕÚÛÜàáâãçèéêëíîïñóôõ÷úûü";
            System.IO.Directory.CreateDirectory(font.Name);
            foreach (char c in symbols)
            {
                Image image = CreateCharImage(c, font);
                String name = String.Format("C{0:X}.bmp", (int)c);
                name = System.IO.Path.Combine(font.Name, name);
                image.Save(name, ImageFormat.Bmp);
                image.Dispose();
            }
        }

        private SizeF MesureTile(String text, Font font, StringFormat stringFormat)
        {
            Image image = new Bitmap(1, 1, PixelFormat.Format24bppRgb);
            Graphics drawing = Graphics.FromImage(image);
            SizeF textSize = drawing.MeasureString(text, font, 100, stringFormat);
            image.Dispose();
            drawing.Dispose();
            textSize.Width += LeftPadding +  RightPadding;
            textSize.Height += TopPadding + BottomPadding;
            return textSize;
        }

        private Image CreateCharImage(char c, Font font)
        {
            String text = c.ToString();
            StringFormat stringFormat = new StringFormat(StringFormat.GenericTypographic);
            SizeF textSize;
            if (c == ' ') textSize = MesureTile("i", font, stringFormat);
            else textSize = MesureTile(text, font, stringFormat);
            Image image = new Bitmap((int)textSize.Width, (int)textSize.Height, PixelFormat.Format24bppRgb);
            Graphics drawing = Graphics.FromImage(image);
            drawing.Clear(Color.White);
            Brush textBrush = new SolidBrush(Color.Black);
            stringFormat.Alignment = StringAlignment.Near;
            RectangleF rect = new RectangleF(LeftPadding, TopPadding, textSize.Width, textSize.Height);
            drawing.DrawString(text, font, Brushes.Black, rect, stringFormat);
            textBrush.Dispose();
            drawing.Dispose();
            return image;
        }
    }
}
