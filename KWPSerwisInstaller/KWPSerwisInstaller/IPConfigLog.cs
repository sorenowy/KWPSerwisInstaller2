using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Windows;
using System.Runtime;

namespace KWPSerwisInstaller
{
    class IPConfigLog : Installer, IIPConfigLog
    {
        public string sciezkaLog;
        public IPConfigLog()
        {
            this.StartInfo.Verb = "runas";
            sciezkaLog = @"\Logi\";
            sciezkaLog = string.Concat(Environment.CurrentDirectory, sciezkaLog);
            this.StartInfo.CreateNoWindow = true;
            this.StartInfo.UseShellExecute = false;
            this.StartInfo.RedirectStandardInput = true;
            this.StartInfo.RedirectStandardOutput = true;
            this.StartInfo.WorkingDirectory = sciezkaLog;
        }
        public void GenerujIPConfigLog()
        {
            ConsoleKeyInfo generujLog;
            Console.WriteLine("Program wygeneruje teraz Log IPCONFIG -ALL");
            Console.WriteLine(@"Który zostanie zapisany w dysku C:\ instalacyjnym komputera");
            Console.WriteLine("Nacisnij Enter, aby dokonać generowania Loga, lub dowolny klawisz, by zakończyć.");
            Console.WriteLine("---------------------------------------------------------------------------------");
            generujLog = Console.ReadKey();
            if (generujLog.Key == ConsoleKey.Enter)
            {
                try
                {
                    Console.WriteLine("Podaj numer inwentarzowy komputera w celu nazwania pliku jego numerem.");
                    string nrInwentarzowy = Console.ReadLine();
                    this.StartInfo.FileName = "Cmd.exe";
                    this.StartInfo.Arguments = ($@"/c ipconfig -all > C:\{nrInwentarzowy}.txt");
                    this.Start();
                    this.WaitForExit();
                    Console.WriteLine("Utworzono ipconfig Log o nazwie {0}", nrInwentarzowy);
                }
                catch (Exception e)
                {
                    Console.WriteLine("wystąpił błąd"+e.Message);
                }
            }
            else
            {
                Console.WriteLine("Wybrałeś opcję nie generowania logu.");
                Console.ReadKey();
            }
        }
    }
}