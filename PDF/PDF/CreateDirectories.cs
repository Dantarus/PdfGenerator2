using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDF
{
    public class CreateDirectories
    {
        public static void NewDirectory(string dirPath)
        {

            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            Console.WriteLine("Wygenerowane pliki pdf znajdują się w pod ścieżką: {0}", dirPath);
        }
    }
}
