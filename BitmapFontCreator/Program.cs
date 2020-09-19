using System;
using System.Drawing;
using CommandLine;

namespace BitmapFontCreator
{
    class Program
    {
        public class Options
        {
            [Value(0, MetaName = "font-family", Default = "Arial", HelpText = "Font family name, e.g. Arial")]
            public String FontFamily { get; set; }

            [Option('s', "size", Default = 16, HelpText = "The em-size in units specified by the font")]
            public int Size { get; set; }

            [Option('l', "left-padding", Default = 0, HelpText = "Left padding in pixels")]
            public int LeftPadding { get; set; }

            [Option('r', "right-padding", Default = 0, HelpText = "Right padding in pixels")]
            public int RightPadding { get; set; }

            [Option('t', "top-padding", Default = 0, HelpText = "Top padding in pixels")]
            public int TopPadding { get; set; }

            [Option('b', "bottom-padding", Default = 0, HelpText = "Bottom padding in pixels")]
            public int BottomPadding { get; set; }

            [Option("bold", HelpText = "Bold text")]
            public bool Bold { get; set; }

            [Option("italic", HelpText = "Italic text")]
            public bool Italic { get; set; }

            [Option("underline", HelpText = "Underlined text")]
            public bool Underline { get; set; }

            [Option("strikeout", HelpText = "Text with a line through the middle.")]
            public bool Strikeout { get; set; }
        }

        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args).WithParsed(OnParseSuccess);
        }

        private static void OnParseSuccess(Options opts)
        {
            FontStyle style = FontStyle.Regular;

            if (opts.Bold) style |= FontStyle.Bold;
            if (opts.Italic) style |= FontStyle.Italic;
            if (opts.Underline) style |= FontStyle.Underline;
            if (opts.Strikeout) style |= FontStyle.Strikeout;

            FontBuilder fontBuilder = new FontBuilder(opts.FontFamily, opts.Size, style)
            {
                TopPadding = opts.TopPadding,
                LeftPadding = opts.LeftPadding,
                RightPadding = opts.RightPadding,
                BottomPadding = opts.BottomPadding
            };
            fontBuilder.Build();
        }
    }
}
