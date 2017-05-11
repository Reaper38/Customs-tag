using iText.Forms.Fields;
using iText.IO.Font;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Layout;
using iText.Layout.Element;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfGen
{
    public static class Pdf
    {
        private static string[] text = new string[] {"FROM\n","PET IT PAQUET RECOMMANDE","T.P","CUSTOMS DECLARATION","May be opened officially","CN 22","Designated Operator",
                "Gift","Commercial sample","Documents","Other","Quantity and detailed description of contents (1)",
                "Weight\n(kg)(2)","Value (3)","Electronic components","For Commercial items only","HS tariff no (4)",
                "Country of origin (5)","RU","Total weight\n(kg)(6)","Total value (7)",
                "I certify that the particulars given in this customs declaration are " +
                "correct and than this item does not contain any " +
                "dangerous article prohibited by legislation or by postal or customs regulations.","Date and signature of sender (8):","To",
                "Recepient","Weight, g"};
        private static string[] from = new string[] { "Pavel Kovalenko\nAbelmanovskaya 11, 124\nMoscow, Russia\n", "109147" };

        private static PdfFont font = PdfFontFactory.CreateFont(FontConstants.TIMES_ROMAN);
        private static PdfFont bold = PdfFontFactory.CreateFont(FontConstants.TIMES_BOLD);

        public static void GeneratePdf(string path)
        {
            if (File.Exists(path))
                File.Delete(path);
            File.Create(path).Close();

            PdfDocument pdf = new PdfDocument(new PdfWriter(path));
            pdf.SetDefaultPageSize(PageSize.A4.Rotate());
            
            PdfPage page = pdf.AddNewPage();

            Document document = new Document(pdf);
            document.SetMargins(5f, 5f, 5f, 5f);
            Paragraph p = new Paragraph();
            p.Add(new Text(text[0]).SetFont(bold));
            p.Add(new Text(from[0]).SetFont(font));
            p.Add(new Text(from[1]).SetFont(bold));

            PdfCanvas pdfCanvas = new PdfCanvas(page);
            Rectangle rectangle = new Rectangle(1, 350, 100, 100);
            pdfCanvas.Rectangle(rectangle);
            pdfCanvas.Stroke();
            Canvas canvas = new Canvas(pdfCanvas, pdf, rectangle);
            //canvas.Add(p);
            document.Add(p);
            document.Close();
            pdf.Close();
        }
    }
}
