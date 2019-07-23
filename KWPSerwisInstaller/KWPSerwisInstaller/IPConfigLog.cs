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
    class IPConfigLog : Installer,IIPConfigLog
    {
        public IPConfigLog()
        {
            this.StartInfo.CreateNoWindow = true;
            this.StartInfo.UseShellExecute = false;
            this.StartInfo.RedirectStandardInput = true;
            this.StartInfo.RedirectStandardOutput = true;
        }
        public void GenerujIPConfigLog()
        {
            ConsoleKeyInfo generujLog;
            generujLog = Console.ReadKey();
            Console.WriteLine(@"Program wygeneruje teraz Log IPCONFIG -ALL, który zostanie zapisany w folderze instalacyjnym komputera C:\KWPSerwisInstaller");
            Console.WriteLine("Nacisnij Enter, aby dokonać generowania Loga, lub dowolny klawisz, by zakończyć.");
            if (generujLog.Key == ConsoleKey.Enter)
            {
                Console.WriteLine("Podaj numer inwentarzowy komputera w celu nazwania pliku jego numerem.");
                string nrInwentarzowy = Console.ReadLine();
                this.StartInfo.FileName = "Cmd.exe";
                this.StartInfo.Arguments = ( $@"/c ipconfig -all > C:\KWPSerwisInstaller\{nrInwentarzowy}.txt");
                this.Start();
                this.WaitForExit();
            }
           else
            {
                Console.WriteLine("Wybrałeś opcję nie generowania logu.");
                Console.ReadKey();
            }

        }
    }
}
