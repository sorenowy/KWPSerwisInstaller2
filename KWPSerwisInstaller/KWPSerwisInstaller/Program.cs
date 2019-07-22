using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KWPSerwisInstaller
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo klawisz1;
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("#######  ######  ##       ##  ######  ######  #######");
            Console.WriteLine("#    ##  ##  ##  ##       ##  ##          ##  ##   ##");
            Console.WriteLine("#######  ##  ##  ##       ##  ##          ##  #######");
            Console.WriteLine("##       ##  ##  ##       ##  ##          ##  ##   ##");
            Console.WriteLine("##       ##  ##  ##       ##  ##          ##  ##   ##");
            Console.WriteLine("##       ######  ######   ##  ######  ######  ##   ##");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Witaj w programie Instalacyjnym KWP Serwis Installer v0.1");
            Console.WriteLine("Upewnij się że komputer jest podłączony do sieci oraz posiada skonfigurowany \nSerwisowy adres IP, by zainstalować wymaganie oprogramowanie.");
            Console.WriteLine("Wciśnij klawisz ENTER aby kontynuować!");
            klawisz1 = Console.ReadKey();
            try
            {
                if (klawisz1.Key == ConsoleKey.Enter)
                {
                    Installer p = new Installer();
                    p.InstalacjaBazy();
                }
                else if (klawisz1.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("Dziękuję za skorzystanie z programu!");
                    Console.WriteLine("Aby zakończyć działanie programu, naciśnij dowolny klawisz.");
                    Console.ReadKey();
                } 
            }
            catch (Exception)
            {
                Console.WriteLine("Oops, cos poszło nie tak :)");
                Console.WriteLine("Uruchom program raz jeszcze!");
                Console.ReadKey();
            }
        }
    }
}
