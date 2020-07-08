using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;


namespace PDF
{
    public class PdfGen : TextGenerators
    {
        static Random rand = new Random();
        enum ConstansValue
        {
            LETTER_NUMBER = 100,
            ROW_NUMBER = 100,
            MB = 75,
        }
        static int maxMb;
        static int minMb;
        static int fileNumber;
        static string savingPdfPath;
        public PdfGen()
        {

        }
        public PdfGen(int min,int max, int fileNum, string pdfPath)
        {
            maxMb = max;
            minMb = min;
            fileNumber = fileNum;
            savingPdfPath = pdfPath;
        }

    public static void Create1mbTable()
    {

    }
    public static void PdfGenerator(int i)
        {

            int pageNumber = (rand.Next() % maxMb + minMb) * (int)ConstansValue.MB;
            Console.WriteLine(rand.Next()+ " "+ minMb + " " + " " + maxMb + " " + (int)ConstansValue.MB + " " + pageNumber);
            string pdfname = FileNameGenerator(i) + ".pdf";

            //System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            PdfDocument pdfdocument = new PdfDocument();
            pdfdocument.Info.Title = "randomtitle";
            PdfPage[] pdfpage = new PdfPage[pageNumber];
            for (int x = 0; x < pageNumber; x++)
            {
                pdfpage[x] = pdfdocument.AddPage();
                XGraphics graph = XGraphics.FromPdfPage(pdfpage[x]);
                XFont font = new XFont("Arial", 12, XFontStyle.Bold);
                for (int j = 0; j < (int)ConstansValue.ROW_NUMBER; j++)
                {
                    graph.DrawString(RandomTextGenerator((int)ConstansValue.LETTER_NUMBER), font, XBrushes.Black,
                       new XRect(0, j * 10, pdfpage[x].Width, pdfpage[x].Height),
                       XStringFormats.TopCenter);

                }

            }

            string pdffilename = savingPdfPath + pdfname;
            pdfdocument.Save(pdffilename);
            Console.WriteLine(pdfname + " wygenerowany prawidłowo");


        }

        public void LoopPdfGenerator()
        {
            for (int i = 0; i < fileNumber; i++)
            {
                PdfGenerator(i);
            }
        }
    }
}
