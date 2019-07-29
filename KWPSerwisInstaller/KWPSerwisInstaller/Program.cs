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
        public static string Copyright()
        {

            return "Made by Hubert Kuszyński, Komenda Wojewódzka Policji w Gorzowie Wielkopolskim, tel. 11659.";

        }
        public static void Thanks()
        {
            MessageBox.Show("Dziękuję za skorzystanie z KWP Serwis Installer v0.7. Do zobaczenia next time ;). Naciśnij OK, by zamknąć okno.","Thank You");
        }
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Clear();
            Prezentacja();
            try
            {
                Application.Run(new MenuGlowne());
            }
            catch (Exception e)
            {
                Console.WriteLine("Oops, cos poszło nie tak :)");
                MessageBox.Show(e.Message,"Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult dError = MessageBox.Show("Uruchom program raz jeszcze!, lub jeżeli to nie pomogło, skontaktuj się z programistą - tel. 11659." +
                "\nNaciśnij dowolny klawisz, by zamknąć okno.","Error",MessageBoxButtons.OK,MessageBoxIcon.Information);
                if (dError == DialogResult.OK)
                {
                    return;
                }
                Console.ReadKey();
            }
        }
    }
}
