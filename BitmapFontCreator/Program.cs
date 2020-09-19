using System;

namespace BitmapFontCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            string fontName = "Times";
            if (args.Length > 0) fontName = args[0];
            FontBuilder fontBuilder = new FontBuilder(fontName);

            if (args.Length > 1) fontBuilder.Size = int.Parse(args[1]);
            if (args.Length > 2) fontBuilder.LeftPadding = int.Parse(args[2]);
            if (args.Length > 3) fontBuilder.TopPadding = int.Parse(args[3]);

            fontBuilder.Build();
        }
    }
}
