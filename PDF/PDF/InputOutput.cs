using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDF
{
    public class InputOutput
    {
        int minMb;
        int maxMb;
        int fileNumber;
        enum borderValues
        {
            MAXMB = 100,
            MINMB = 1,
            MIN_FILENUMBER = 1,
            MAX_FILENUMBER = 1000000,
        }
        public void SetMinSize()
        {

            bool a = false;
            bool b = false;
            do
            {

                Console.WriteLine("Podaj minimalną wielkość pliku: ");
                string min = Console.ReadLine();
                a = ExceptionsAndConstraints.IsExceptionInParse(min, out minMb);
                if (!a)
                {
                    b = ExceptionsAndConstraints.IsInBoundaries(minMb, (int)borderValues.MINMB, (int)borderValues.MAXMB);
                }
            } while (b || a);
        }
        public void SetMaxSize()
        {
            bool a = false;
            bool b = false;
            do
            {
                Console.WriteLine("Podaj maksymalną wielkość pliku: ");
                string max = Console.ReadLine();
                a = ExceptionsAndConstraints.IsExceptionInParse(max, out maxMb);
                if (!a)
                {
                    b = ExceptionsAndConstraints.IsInBoundaries(maxMb, (int)borderValues.MINMB, (int)borderValues.MAXMB);
                }
            } while (b || a);
        }
        //fragment odpowiada za sprawdzanie poprawności wpisanej liczby
        public void SetFileNumber()
        {
            bool a = false;
            bool b = false;
            do
            {
                Console.WriteLine("Podaj liczbę plików do wygenerowania: ");
                string fileNum = Console.ReadLine();
                a = ExceptionsAndConstraints.IsExceptionInParse(fileNum, out fileNumber);
                if (!a)
                {
                    b = ExceptionsAndConstraints.IsInBoundaries(fileNumber, (int)borderValues.MIN_FILENUMBER, (int)borderValues.MAX_FILENUMBER);
                }
            } while (b || a);
        }
        public int ReturnMinSize()
        {
            return minMb;
        }
        public int ReturnMaxSize()
        {
            return maxMb;
        }
        public int ReturnfileNumber()
        {
            return fileNumber;
        }
    }
}
