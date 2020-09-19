# Bitmap Font Creator

Creates a tile for each letter of the selected font.

## Build

```
dotnet build .
```

## Usage

```
BitmapFontCreator [font-family] [options...]

Positional:

  font-family             (Default: Arial) Font family name, e.g. Arial

Options:

  -s, --size              (Default: 16) The em-size in units specified by the font

  -l, --left-padding      (Default: 0) Left padding in pixels

  -r, --right-padding     (Default: 0) Right padding in pixels

  -t, --top-padding       (Default: 0) Top padding in pixels

  -b, --bottom-padding    (Default: 0) Bottom padding in pixels

  -o, --output            Output directory

  --bold                  Bold text

  --italic                Italic text

  --underline             Underlined text

  --strikeout             Text with a line through the middle.

  --help                  Display this help screen.

  --version               Display version information.
```
