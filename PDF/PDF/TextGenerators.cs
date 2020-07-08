using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDF
{
    public class TextGenerators
    {
        private static Random rand = new Random();
        static int RandomNumberGenerator(int downBound, int topBound)
        {
            int number;
            number = (rand.Next() % topBound) + downBound;
            return number;
        }
        public static string RandomTextGenerator(int letterNumber)
        {
            string text = "";
            for (int i = 0; i < letterNumber; i++) text += (char)RandomNumberGenerator(1, 127);
            return text;
        }
        //generowanie nazwy faktury wg. zadananego formatu
        public static string FileNameGenerator(int i)//do ukończenia
        {
            char c = '0';
            string[] type = new string[4];
            type[0] = "FV";
            type[1] = "KF";
            type[2] = "FZ";
            type[3] = "KZ";
            string number = i.ToString();
            string year = RandomNumberGenerator(1, 99).ToString();
            string month = RandomNumberGenerator(1, 12).ToString();
            int period = RandomNumberGenerator(1, 4);
            string clientNumber = RandomNumberGenerator(1, 999999).ToString();

            number = number.PadLeft(6, c);
            year = year.PadLeft(2, c);
            month = month.PadLeft(2, c);
            clientNumber = clientNumber.PadLeft(6, c);

            string invoiceName = type[RandomNumberGenerator(1, 4) - 1] + '-' + number + '-' + year + '-' + month + '-' + period + '-' + clientNumber;
            return invoiceName;
        }

    }
}
