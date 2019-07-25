using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Windows;
using System.DirectoryServices;

namespace KWPSerwisInstaller
{
    class Program
    {
        public delegate void DelegatInformacyjny();
        static void Prezentacja()
        {
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("#######  ######  ##       ##  ######  ######  #######");
            Console.WriteLine("#    ##  ##  ##  ##       ##  ##          ##  ##   ##");
            Console.WriteLine("#######  ##  ##  ##       ##  ##          ##  #######");
            Console.WriteLine("##       ##  ##  ##       ##  ##          ##  ##   ##");
            Console.WriteLine("##       ##  ##  ##       ##  ##          ##  ##   ##");
            Console.WriteLine("##       ######  ######   ##  ######  ######  ##   ##");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Witaj w programie Instalacyjnym KWP Serwis Installer v0.2");
            Console.WriteLine("Upewnij się że komputer jest podłączony do sieci oraz posiada skonfigurowany \nSerwisowy adres IP, by zainstalować wymaganie oprogramowanie.");
            Console.WriteLine("Wciśnij klawisz ENTER aby kontynuować!");
            Console.WriteLine("Lub Escape, aby zakończyć działanie programu.");
        }
        static void Naglowek()
        {
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Naciśnij klawisz 1 aby dokonać instalacji oprogramowania na komputerze do Internetu.");
            Console.WriteLine("Lub naciśnij klawisz 2, by zainstalować oprogramowanie dla komputera PSTD.");
            Console.WriteLine("Możesz też nacisnąć Escape, by zamknąć program.");
        }
        static void Copyright()
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Made by Hubert Kuszyński, tel. 11659.");
        }
        static void Thanks()
        {
            Console.WriteLine("Dziękuję za skorzystanie z KWP Serwis Installer v0.2.");
            Console.WriteLine("Do zobaczenia next time ;). Naciśnij dowolny klawisz, by zamknąć okno.");
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            ZmienNetBIOS test = new ZmienNetBIOS();
            test.JoinDomain();
            ConsoleKeyInfo klawisz1;
            Prezentacja();
            Copyright();
            klawisz1 = Console.ReadKey();
            try
            {
                while (klawisz1.Key != ConsoleKey.Escape)
                {
                    if (klawisz1.Key == ConsoleKey.Enter)
                    {
                        Installer install = new Installer();
                        IPConfigLog log = new IPConfigLog();
                        ClassCreateUser user = new ClassCreateUser();
                        ZmienNetBIOS zmiana = new ZmienNetBIOS();
                        Naglowek();
                        klawisz1 = Console.ReadKey();
                        Console.Clear();
                        while (klawisz1.Key != ConsoleKey.Escape)
                        {
                            if (klawisz1.Key == ConsoleKey.D1)
                            {
                                Console.WriteLine("Trwa instalacja oprogramowania dla komputera w sieci Internet.");
                                install.InstalacjaInternet();
                                install.InstalacjaOffice();
                                log.GenerujIPConfigLog();
                                user.WyswietlUser();
                                zmiana.ChangeNetBIOS();
                                Thanks();
                                return;

                            }
                            else if (klawisz1.Key == ConsoleKey.D2)
                            {
                                Console.WriteLine("Trwa instalacja oprogramowania dla komputera w sieci PSTD.");
                                install.InstalacjaPSTD();
                                install.InstalacjaOffice();
                                log.GenerujIPConfigLog();
                                user.WyswietlUser();
                                zmiana.ChangeNetBIOS();
                                Thanks();
                                return;
                            }
                            else
                            {
                                Console.WriteLine("Wcisnąłęś zły klawisz, spróbój ponownie!");
                                klawisz1 = Console.ReadKey();
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Wcisnąłęś zły klawisz, spróbój ponownie!");
                        klawisz1 = Console.ReadKey();
                    }
                }

                Console.WriteLine("Przykro mi że już kończysz...:(, naciśnij dowolny klawisz, aby zamknąć okno.");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("Oops, cos poszło nie tak :)");
                Console.WriteLine(e.ToString());
                Console.WriteLine("Uruchom program raz jeszcze!, naciśnij dowolny klawisz, by zamknąć okno.");
                Console.ReadKey();
            }
        }
    }
}
