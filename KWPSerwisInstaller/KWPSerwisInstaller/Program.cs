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
                    Console.WriteLine("Naciśnij klawisz 1 aby dokonać instalacji oprogramowania na komputerze do Internetu.");
                    Console.WriteLine("Lub naciśnij klawisz 2, by zainstalować oprogramowanie dla komputera PSTD.");
                    klawisz1 = Console.ReadKey();
                    if (klawisz1.Key == ConsoleKey.D1)
                    {
                        p.InstalacjaInternet();
                        Console.WriteLine("Dziękuję za skorzystanie z KWP Serwis Installer v0.2.");
                        Console.WriteLine("Do zobaczenia next time ;).");
                        Console.ReadKey();
                    }
                    else if (klawisz1.Key == ConsoleKey.D2)
                    {
                        p.instalacjaPSTD();
                        Console.WriteLine("Dziękuję za skorzystanie z KWP Serwis Installer v0.2.");
                        Console.WriteLine("Do zobaczenia next time ;).");
                        Console.ReadKey();
                    }
                    else if (klawisz1.Key == ConsoleKey.Escape)
                    {
                        Console.WriteLine("Dziękuję za skorzystanie z KWP Serwis Installer v0.2.");
                        Console.WriteLine("Do zobaczenia next time ;).");
                        Console.ReadKey();
                    }
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
