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
            Console.WriteLine("Witaj w programie Instalacyjnym KWP Serwis Installer v0.6");
            Console.WriteLine("Upewnij się że komputer jest podłączony do sieci oraz posiada skonfigurowany \nSerwisowy adres IP, by zainstalować wymaganie oprogramowanie.");
            Console.WriteLine("W przypadku podłączenia komputera do domeny, miej ustawiony dynamiczny adres IP.");
            Console.WriteLine("Wciśnij klawisz ENTER aby kontynuować!");
            Console.WriteLine("Lub Escape, aby zakończyć działanie programu.");
        }
        public static void Naglowek()
        {
            Console.WriteLine();
            Console.WriteLine("Naciśnij klawisz 1 aby dokonać instalacji oprogramowania na komputerze do Internetu.");
            Console.WriteLine("Naciśnij klawisz 2, by zainstalować oprogramowanie dla komputera PSTD.");
            Console.WriteLine("Naciśnij klawisz 3, by zainstalowac oprogramowanie dla komputera w sieci CWI.");
            Console.WriteLine("Możesz też nacisnąć Escape, by zamknąć program.");
        }
        public static void Copyright()
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Made by Hubert Kuszyński, Komenda Wojewódzka Policji w Gorzowie Wielkopolskim, tel. 11659.");
            Console.WriteLine("----------------------------------------------");
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
                        DodajCertyfikat cert = new DodajCertyfikat();
                        Naglowek();
                        klawisz1 = Console.ReadKey();
                        while (klawisz1.Key != ConsoleKey.Escape)
                        {
                            if (klawisz1.Key == ConsoleKey.D1)
                            {
                                Console.Clear();
                                Console.WriteLine("Trwa instalacja oprogramowania dla komputera w sieci Internet.\nPo zakończeniu instalacji, komputer uruchomi się ponownie!");
                                install.InstalacjaInternet();
                                install.InstalacjaOffice();
                                user.WyswietlUser();
                                log.GenerujIPConfigLog();
                                Console.WriteLine("Czy chcesz podłączyć komputer do domeny?\nWcisnij 1. by zmienić nazwę NetBIOS komputera i podłączyć komputer do domeny" +
                                    "\n2. Aby tylko zmienić nazwę NetBIOS.");
                                klawisz1 = Console.ReadKey();
                                if(klawisz1.Key == ConsoleKey.D1)
                                {
                                    zmiana.JoinDomain();
                                    Thanks();
                                    Process.Start("shutdown", "/r /f /t 0");
                                }
                                else
                                {
                                    zmiana.ChangeNetBIOS();
                                    Thanks();
                                    Process.Start("shutdown", "/r /f /t 0");
                                }
                            }
                            else if (klawisz1.Key == ConsoleKey.D2)
                            {
                                Console.Clear();
                                Console.WriteLine("Trwa instalacja oprogramowania dla komputera w sieci PSTD.\nPo zakończeniu instalacji, komputer uruchomi się ponownie!");
                                install.InstalacjaPSTD();
                                install.InstalacjaOffice();
                                cert.InstalujInfrastruktura("infrastruktura2019.der");
                                user.WyswietlUser();
                                log.GenerujIPConfigLog();
                                zmiana.ChangeNetBIOS();
                                Thanks();
                                Process.Start("shutdown", "/r /f /t 0");
                            }
                            else if (klawisz1.Key == ConsoleKey.D3)
                            {
                                Console.Clear();
                                Console.WriteLine("Trwa instalacja oprogramowania dla komputera w sieci CWI.\nPo zakończeniu instalacji, komputer uruchomi się ponownie!");
                                install.InstalacjaCWI();
                                cert.InstalujCWI("CWI_CERT.cer");
                                log.GenerujIPConfigLog();
                                user.WyswietlUser();
                                zmiana.ChangeNetBIOS();
                                Thanks();
                                Process.Start("shutdown", "/r /f /t 0");
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
                Console.WriteLine("Uruchom program raz jeszcze!, lub jeżeli to nie pomogło, skontaktuj się z programistą - tel. 11659." +
                "\nNaciśnij dowolny klawisz, by zamknąć okno.");
                Console.ReadKey();
            }
        }
    }
}
