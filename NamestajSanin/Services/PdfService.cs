using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using System.IO;
using NamestajSanin.Models;
using System.Reflection;

namespace NamestajSanin.Services
{
    public class PdfService
    {
        public byte[] GenerateNarudzbaPdf(Narudzba narudzba)
        {
            var document = new PdfDocument();
            var page = document.AddPage();
            var gfx = XGraphics.FromPdfPage(page);

            var titleFont = new XFont("Times New Roman", 18, XFontStyle.Bold);
            var boldFont = new XFont("Times New Roman", 12, XFontStyle.Bold);
            var regularFont = new XFont("Times New Roman", 12, XFontStyle.Regular);
            var grayFont = new XFont("Times New Roman", 10, XFontStyle.Italic);

            int y = 40;

            // ✅ ZAGLAVLJE FIRME

            var logoPath = Path.Combine("/app", "logo.jpg");
            if (File.Exists(logoPath))
            {
                var image = XImage.FromFile(logoPath);

                int logoSize = 100;
                gfx.DrawImage(image, (page.Width - logoSize) / 2, y, logoSize, logoSize);
                y += logoSize + 20; 
            }
            else
            {
                y += 120; 
            }


            gfx.DrawString("Ravni bb, Prijepolje 31300", regularFont, XBrushes.Black, new XRect(0, y, page.Width, 20), XStringFormats.TopCenter);
            y += 20;

            gfx.DrawString("PIB: 102659399    Matični broj: 55720223    Šifra delatnosti: 9524", regularFont, XBrushes.Black, new XRect(0, y, page.Width, 20), XStringFormats.TopCenter);
            y += 20;

            gfx.DrawString("Telefon: +381 64 2067881", regularFont, XBrushes.Black, new XRect(0, y, page.Width, 20), XStringFormats.TopCenter);
            y += 40;

            // 🧾 Naslov dokumenta
            gfx.DrawString("POTVRDA O NARUDŽBI", boldFont, XBrushes.Black, new XRect(0, y, page.Width, 20), XStringFormats.TopCenter);
            y += 30;

            // 📄 Podaci o narudžbi
            gfx.DrawString($"Broj narudžbe: {narudzba.Id}", regularFont, XBrushes.Black, 40, y); y += 20;
            gfx.DrawString($"Vrsta namještaja: {narudzba.VrstaNamestaja}", regularFont, XBrushes.Black, 40, y); y += 20;
            gfx.DrawString($"Dimenzije: {narudzba.Dimenzije}", regularFont, XBrushes.Black, 40, y); y += 20;
            gfx.DrawString($"Materijal: {narudzba.Materijal}", regularFont, XBrushes.Black, 40, y); y += 20;
            gfx.DrawString($"Boja: {narudzba.Boja}", regularFont, XBrushes.Black, 40, y); y += 20;
            gfx.DrawString($"Klijent: {narudzba.KontaktIme}", regularFont, XBrushes.Black, 40, y); y += 20;
            gfx.DrawString($"Telefon: {narudzba.Telefon}", regularFont, XBrushes.Black, 40, y); y += 20;
            gfx.DrawString($"Email: {narudzba.Email}", regularFont, XBrushes.Black, 40, y); y += 20;
            gfx.DrawString($"Napomena: {narudzba.Napomena}", regularFont, XBrushes.Black, 40, y); y += 20;
            gfx.DrawString($"Status: {narudzba.Status}", regularFont, XBrushes.Black, 40, y); y += 30;

            // ✍️ Potpis
            gfx.DrawString("_______________________", regularFont, XBrushes.Black, new XRect(0, y, page.Width - 40, 20), XStringFormats.TopRight);
            y += 25;
            gfx.DrawString("Potpis klijenta", grayFont, XBrushes.Gray, new XRect(0, y, page.Width - 40, 20), XStringFormats.TopRight);


            using (var stream = new MemoryStream())
            {
                document.Save(stream, false);
                return stream.ToArray();
            }
        }
    }
}
