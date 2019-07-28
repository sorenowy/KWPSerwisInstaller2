using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Windows;
using System.DirectoryServices;
using System.Windows.Forms;

namespace KWPSerwisInstaller
{
    class Program
    {
        public delegate void DelegatInformacyjny();
        public static void Prezentacja()
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("#######  ######  ##       ##  ######  ######  #######");
            Console.WriteLine("##   ##  ##  ##  ##       ##  ##          ##  ##   ##");
            Console.WriteLine("#######  ##  ##  ##       ##  ##          ##  #######");
            Console.WriteLine("##       ##  ##  ##       ##  ##          ##  ##   ##");
            Console.WriteLine("##       ##  ##  ##       ##  ##          ##  ##   ##");
            Console.WriteLine("##       ######  ######   ##  ######  ######  ##   ##");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Witaj w programie Instalacyjnym KWP Serwis Installer v0.7");
            Console.WriteLine("Upewnij się że komputer jest podłączony do sieci oraz posiada skonfigurowany \nSerwisowy adres IP, by zainstalować wymaganie oprogramowanie.");
            Console.WriteLine("W przypadku podłączenia komputera do domeny, miej ustawiony dynamiczny adres IP.");
        }
        public static void Naglowek()
        {
            Console.WriteLine();
            Console.WriteLine("Naciśnij klawisz 1 aby dokonać instalacji oprogramowania na komputerze do Internetu.");
            Console.WriteLine("Naciśnij klawisz 2, by zainstalować oprogramowanie dla komputera PSTD.");
            Console.WriteLine("Naciśnij klawisz 3, by zainstalowac oprogramowanie dla komputera w sieci CWI.");
            Console.WriteLine("Możesz też nacisnąć Escape, by zamknąć program.");
        }
        public static string Copyright()
        {

            return "Made by Hubert Kuszyński, Komenda Wojewódzka Policji w Gorzowie Wielkopolskim, tel. 11659.";

        }
        public static void Thanks()
        {
            Console.WriteLine("Dziękuję za skorzystanie z KWP Serwis Installer v0.6.");
            Console.WriteLine("Do zobaczenia next time ;). Naciśnij dowolny klawisz, by zamknąć okno.");
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Clear();
            Prezentacja();
            Copyright();
            try
            {
                Application.Run(new MenuGlowne());
            }
            catch (Exception e)
            {
                Console.WriteLine("Oops, cos poszło nie tak :)");
                Console.WriteLine(e.ToString());
                Console.WriteLine("Uruchom program raz jeszcze!, lub jeżeli to nie pomogło, skontaktuj się z programistą - tel. 11659." +
                "\nNaciśnij dowolny klawisz, by zamknąć okno.");
                Console.ReadKey();
            }
        }
    }
}
