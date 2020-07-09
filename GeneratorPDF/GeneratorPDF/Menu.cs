using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDF
{
    class Menu
    {
        static string pdfPath = @"C:\GeneratedPdf\", templatePath = @"C:\GeneratedPdf\TemplateFolder\";
        static InputOutput Input = new InputOutput();
        static PdfGen pdf;
        public static void ListaOpcji()
        {
            bool backToStart = false;

            do
            {
                Console.WriteLine("Wybierz potrzebną ci opcję: ");
                Console.WriteLine("1. Podaje tylko ilość plików do wygenerowania.(Ich wielkość <1Mb,10Mb>)");
                Console.WriteLine("2. Podaje ilość plików do wygenerowania i wielkość minimalną i maksymalną tych plików.");
                Console.WriteLine("3. Chcę zakończyć program.");
                string choseOption = Console.ReadLine();
                Console.Clear();
                switch (choseOption)
                {
                    case "1":
                        Input.SetFileNumber();
                        pdf = new PdfGen(Input.ReturnfileNumber(), pdfPath, templatePath);
                        break;
                    case "2":
                        Input.SetFileNumber();
                        Input.SetMinSize();
                        Input.SetMaxSize();
                        pdf = new PdfGen(Input.ReturnMinSize(), Input.ReturnMaxSize(), Input.ReturnfileNumber(), pdfPath, templatePath);
                        break;
                    case "3":
                        System.Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Błąd! Źle podany numer opcji.");

                        backToStart = true;
                        break;
                }
            } while (backToStart);

            {
                CreateDirectories.NewDirectory(@"C:\GeneratedPdf");
                CreateDirectories.NewDirectory(@"C:\GeneratedPdf\TemplateFolder");
                Console.WriteLine("\nProszę czekać trwa generowanie pliku wzorcowego...");

                pdf.Create1mbFile();
                Console.WriteLine("\nProszę czekać trwa generowanie plików pdf...");

                pdf.LoopPdfGenerator();
                Console.WriteLine("\nGenerowanie {0} plików pdf zostało zakończone.\n" +
                    "Znajdują się one pod ścieżką: {1}", Input.ReturnfileNumber(), pdfPath);

            }
            Console.WriteLine("\nAby zakończyć klinknij dowolny przycisk na klawiaturze");
            Console.ReadLine();
        }

    }
}
