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
        private static string[] outterText = new string[] {"FROM\n","PET IT PAQUET RECOMMANDE","T.P","To",
                "Recepient","Weight, g"};

        private static string[] boxedText = new string[] {"CUSTOMS DECLARATION",
            "May be opened\nofficially",
            "CN 22",
            "Designated\nOperator",
            "Gift",
            "Commercial sample",
            "Documents",
            "Other",
            "Quantity and detailed description\nof contents (1)",
            "Weight\n(kg)(2)",
            "Value (3)",
            "Electronic components",
            "For Commercial items only",
            "HS tariff no (4)",
            "Country of origin (5)",
            "RU",
            "Total weight\n(kg)(6)",
            "Total\nvalue (7)",
            "I certify that the particulars given in this customs declaration are " +
                "correct and that\nthis item does not contain any " +
                "dangerous article prohibited by\nlegislation or by postal or customs regulations.",
            "Date and signature of sender (8):"};

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
            document.SetMargins(0f, 0f, 0f, 0f);
            Paragraph p = new Paragraph();
            p.Add(new Text(outterText[0]).SetFont(bold));
            p.Add(new Text(from[0]).SetFont(font));
            p.Add(new Text(from[1]).SetFont(bold));

            PdfCanvas pdfCanvas = new PdfCanvas(page);
            pdfCanvas.Rectangle(0, 300, 215, 150);//border
            pdfCanvas.Rectangle(0, 300, 215, 10);//date
            pdfCanvas.Rectangle(0, 310, 215, 20);//i certyfy

            //pdfCanvas.Rectangle(0, 330, 60, 10);//origin
            //pdfCanvas.Rectangle(60, 330, 60, 10);
            //pdfCanvas.Rectangle(120, 330, 50, 10);
            pdfCanvas.Rectangle(170, 330, 25, 10);

            //pdfCanvas.Rectangle(0, 340, 200, 10);//hs
            //pdfCanvas.Rectangle(60, 340, 60, 10);
            //pdfCanvas.Rectangle(120, 340, 50, 10);
            pdfCanvas.Rectangle(190, 340, 25, 10);

            pdfCanvas.Rectangle(0, 350, 215, 10);//for
            pdfCanvas.Rectangle(0, 360, 215, 10);//electronic
            pdfCanvas.Rectangle(0, 370, 215, 20);//quantity
            pdfCanvas.Rectangle(0, 390, 215, 20);//gift
            pdfCanvas.Rectangle(0, 410, 215, 20);//designated
            pdfCanvas.Rectangle(0, 430, 215, 20);//customs
            pdfCanvas.Stroke();
            //Canvas canvas = new Canvas(pdfCanvas, pdf, rectangle);

           // var pa = new Paragraph(new Text(boxedText[19]).SetFont(font).SetFontSize(6));

            document.Add(p);
           // document.Add(pa);
            document.Close();
            pdf.Close();
        }
    }
}
