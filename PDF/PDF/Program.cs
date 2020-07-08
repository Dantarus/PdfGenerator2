using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDF
{
    public class Program
    {
        static void Main(string[] args)
        {
            InputOutput Input = new InputOutput();
            Input.SetFileNumber();
            Input.SetMinSize();
            Input.SetMaxSize();
            Console.WriteLine("ILOSC PLIKOW " + Input.ReturnfileNumber() + " MINIMALNA " + Input.ReturnMinSize() + " MAKSYMALNA " + Input.ReturnMaxSize());
            CreateDirectories.NewDirectory(@"C:\GeneratedPdf");

            PdfGen pdf = new PdfGen(Input.ReturnMinSize(), Input.ReturnMaxSize(), Input.ReturnfileNumber(), "C:\\GeneratedPdf\\");
            pdf.LoopPdfGenerator();
            


        }
    }
}
