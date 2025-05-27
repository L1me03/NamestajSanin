using PdfSharpCore.Fonts;
using System.IO;
using System.Reflection;

public class FontResolverSans : IFontResolver
{
    public byte[] GetFont(string faceName)
    {
        var fontPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "", "LiberationSans-Regular.ttf");
        return File.ReadAllBytes(fontPath);
    }

    public FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic)
    {
        return new FontResolverInfo("MyFont");
    }

    public string DefaultFontName => "MyFont";
}
