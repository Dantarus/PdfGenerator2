using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using Microsoft.Win32;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace PDF
{
    public class PdfGen : TextGenerators
    {
        static Random rand = new Random();
        //poniższy enum przechowuje wartości odpowiadające
        //jaka musi być zawartość pdf, aby osiągnął rozmiar 1Mb
        enum ConstansValue
        {
            LETTER_NUMBER = 102,
            ROW_NUMBER = 100,
            MB = 75,
        }
        //poniższe zmienne zawierają wartości podane przez użytkownika
        //maksymalny rozmiar generowanego pdf
        static int maxMb;
        //minimalny rozmiar generowanego pdf
        static int minMb;
        //liczba wszystkich plików do wygenerowania
        static int fileNumber;
        //ścieżka dostępu do katalogu na dysku do zapisu pdf
        static string savingPdfPath;
        static string savingTemplatePath;
        //nazwa pdf bazowego, będącego wzorem do powielania przy generowaniu
        //plików o większym rozmiarze
        static string pdftemplatename = "template.pdf";
        //konstruktor zawiera podstawowy zestaw wartości inicjujących zmiennne
        public PdfGen(int fileNum, string pdfPath, string templatePath)
        {
            maxMb = 10;
            minMb = 1;
            fileNumber = fileNum;
            savingPdfPath = pdfPath;
            savingTemplatePath = templatePath;
        }
        //konstuktor przyjmuje dane z metody main w klasie program
        public PdfGen(int min, int max, int fileNum, string pdfPath, string templatePath)
        {
            maxMb = max;
            minMb = min;
            fileNumber = fileNum;
            savingPdfPath = pdfPath;
            savingTemplatePath = templatePath;
        }

        //metoda tworzy plik bazowy template.pdf który jest powielany w metodzie PdfGenerator
        public void Create1mbFile()
        {

            int pageNumber = maxMb * (int)ConstansValue.MB;
            PdfDocument pdfdocument = new PdfDocument();
            pdfdocument.Info.Title = "title";
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

            string pdfFullPath = savingTemplatePath + pdftemplatename;
            pdfdocument.Save(pdfFullPath);

            if (File.Exists(pdfFullPath))
            {
                FileInfo info = new FileInfo(savingTemplatePath + pdftemplatename);
                double size = info.Length;
                double sizeMb = size / (1024 * 1024);
                Console.WriteLine(pdftemplatename + " pdf bazowy wygenerowany prawidłowo. Rozmiar pliku: " + sizeMb + "Mb.");

            }
            else
            {
                Console.WriteLine(pdftemplatename + " nie został wygenerowany.");
            }

        }

        //Metoda korzysta z gotowego pliku w celu generowania nowych pdfów o różnej wielkości
        //i zapisuje je pod ścieżką templatedpdfPath
        public static void PdfGenerator(int i)
        {
            //odczyt stworzonego pliku pdf template
            string templatepdfPath = savingTemplatePath + pdftemplatename;
            PdfDocument inputPDF = PdfReader.Open(templatepdfPath, PdfDocumentOpenMode.Import);

            //stworznie pliku do docelowego zapisu strony
            PdfDocument outputPdf = new PdfDocument();

            for (int k = 0; k < minMb * (int)ConstansValue.MB; k++)
            {

                PdfPage page = inputPDF.Pages[k];
                outputPdf.AddPage(page);

            }
            int addional = ((rand.Next()) % (maxMb - minMb + 1)) * (int)ConstansValue.MB;

            for (int k = 0; k < addional; k++)
            {

                PdfPage page = inputPDF.Pages[k];
                outputPdf.AddPage(page);

            }
            string pdfname = FileNameGenerator(i + 1) + ".pdf";
            string pdfFilePath = savingPdfPath + pdfname;
            outputPdf.Save(pdfFilePath);

            if (File.Exists(pdfFilePath))
            {
                FileInfo info = new FileInfo(pdfFilePath);
                double size = info.Length;
                double sizeMb = size / (1024 * 1024);
                Console.WriteLine((i + 1) + ". " + pdfname + " wygenerowany prawidłowo. Rozmiar pliku: " + sizeMb + "Mb.");
            }
            else
            {
                Console.WriteLine((i + 1) + ". " + pdfname + " nie został wygenerowany.");
            }
        }

        //Metoda odpowiada za wywołanie metody PdfGenerator w celu utworzenia
        //zadanej liczby plików
        public void LoopPdfGenerator()
        {
            for (int i = 0; i < fileNumber; i++)
            {
                PdfGenerator(i);
            }
        }
    }
}
