using System;
using System.Windows.Forms;

namespace KWPSerwisInstaller
{
    internal class Program
    {
        public static void Welcome()
        {
            // Powitanie ukazujące się na tle konsoli po uruchomieniu".
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("#######  ######  ##       ##  ######  ######  #######");
            Console.WriteLine("##   ##  ##  ##  ##       ##  ##          ##  ##   ##");
            Console.WriteLine("#######  ##  ##  ##       ##  ##          ##  #######");
            Console.WriteLine("##       ##  ##  ##       ##  ##          ##  ##   ##");
            Console.WriteLine("##       ##  ##  ##       ##  ##          ##  ##   ##");
            Console.WriteLine("##       ######  ######   ##  ######  ######  ##   ##");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Witaj w programie Instalacyjnym KWP Serwis Installer v0.9");
            Console.WriteLine("Upewnij się że komputer jest podłączony do sieci oraz posiada skonfigurowany \nSerwisowy adres IP, by zainstalować wymaganie oprogramowanie.");
            Console.WriteLine("W przypadku podłączenia komputera do domeny, miej ustawiony dynamiczny adres IP.");
        }
        public static string Copyright()
        {
            //Zwraca copyright :)
            return "Made by Hubert Kuszyński, Komenda Wojewódzka Policji w Gorzowie Wielkopolskim, tel. 11659.";
        }
        public static void Thanks()
        {
            //Podziekowania pod koniec programu
            MessageBox.Show("Dziękuję za skorzystanie z KWP Serwis Installer v0.9. Do zobaczenia next time ;). Naciśnij OK, by zamknąć okno.","Thank You");
        }
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Clear(); // Ustawia kolory konsoli i przeładowywuje ją :)
            Welcome();
            try
            {
                Application.Run(new MainMenu());
            }
            catch (Exception e)
            {
                Console.WriteLine("Oops, cos poszło nie tak :)");
                DialogResult dError = MessageBox.Show(e.Message+"\n------------\nUruchom program raz jeszcze!, lub jeżeli to nie pomogło, skontaktuj się z programistą - tel. 11659." +
                "\nNaciśnij dowolny klawisz, by zamknąć okno.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                if (dError == DialogResult.OK)
                {
                    return;
                }
                Console.ReadKey();
            }
        }
    }
}
