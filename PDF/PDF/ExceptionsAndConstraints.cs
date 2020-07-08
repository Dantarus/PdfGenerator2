using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDF
{
    public class ExceptionsAndConstraints
    {
        public static bool IsExceptionInParse(string x, out int y)
        {
            bool b = false;
            y = 0;
            try
            {
                y = Int32.Parse(x);
            }
            catch (FormatException e)
            {
                b = true;
                Console.WriteLine("{0} uniemożliwia poprawną konwersję: ", e);
            }
            catch (Exception e)
            {
                b = true;
                Console.WriteLine("{0} uniemożliwia poprawną konwersję: ", e);
            }
            return b;
        }
        public static bool IsInBoundaries(int x, int downBound, int topBound)
        {
            if (x < downBound || x > topBound)
            {
                Console.WriteLine("Dana znajduje się poza przedziałem ({0},{1})", downBound, topBound);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
