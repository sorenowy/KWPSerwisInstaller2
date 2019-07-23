﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Runtime;
using System.Windows;

namespace KWPSerwisInstaller
{
    class Installer : Process, IInstalacjaBazy, IInstalacjaInternet,IInstalacjaPSTD,IInstalacjaOffice
    {
        public Installer()
        {
            this.StartInfo.UseShellExecute = true;
            this.StartInfo.CreateNoWindow = true;
            this.StartInfo.WorkingDirectory = @"C:\KWPSerwisInstaller\Data\";
        }
        public void InstalacjaBazy()
        {
            ConsoleKeyInfo klawiszLotus;
            Console.WriteLine("Wybierz którego lotusa chcesz zainstalować najpierw?");
            Console.WriteLine("1)Lotus Notes Basic 8.5.3\n2)Lotus Notes Standard 8.5.3.");
            Console.WriteLine("Lub wcisnij inny dowolny klawisz, aby pominąć.");
            klawiszLotus = Console.ReadKey();
            if (klawiszLotus.Key == ConsoleKey.D1)
            {
                this.StartInfo.FileName = "LotusNotesBasic853.exe";
                this.Start();
                Console.WriteLine("Trwa instalacja Klienta Lotus Notes 8.5.3 Basic...");
                this.WaitForExit();
                Console.WriteLine("Zainstalowano klienta Lotus Notes 8.5.3 Basic.");
            }
            else if (klawiszLotus.Key == ConsoleKey.D2)
            {
                this.StartInfo.FileName = "LotusNotesStd853.exe";
                this.Start();
                Console.WriteLine("Trwa instalacja Klienta Lotus Notes 8.5.3 Standard...");
                this.WaitForExit();
                Console.WriteLine("Zainstalowano klienta Lotus Notes 8.5.3 Standard.");
            }
            else
            {
                Console.WriteLine("Nie wybrano żadnego lotusa.");
            }
            this.StartInfo.FileName = "Firefox.exe";
            this.Start();
            Console.WriteLine("Instaluję Firefox 66.0...");
            this.WaitForExit();
            Console.WriteLine("Zainstalowano Firefox 66.0.");
            this.StartInfo.FileName = "7z1900.exe";
            this.Start();
            Console.WriteLine("Instaluję 7-zip...");
            this.WaitForExit();
            Console.WriteLine("Zainstalowano 7-zip.");
            this.StartInfo.FileName = "Adobe11.exe";
            this.StartInfo.Arguments = string.Format($"/qn /i ALLUSERS=1 {this.StartInfo.WorkingDirectory}");
            this.Start();
            Console.WriteLine("Instaluję Adobe Reader XI...");
            this.WaitForExit();
            Console.WriteLine("Zainstalowano Adobe Reader XI.");
            this.StartInfo.FileName = "KLite1504.exe";
            this.Start();
            Console.WriteLine("Trwa instalacja K-Lite Codec 15.04 Standard...");
            this.WaitForExit();
            Console.WriteLine("Zainstalowano K-Lite Codec 15.04 Standard.");
        }
        public void InstalacjaInternet()
        {
            this.InstalacjaBazy();
            this.StartInfo.FileName = "Spotify.exe";
            this.Start();
            Console.WriteLine("Trwa instalowanie Spotify...");
            this.WaitForExit();
            Console.WriteLine("Zainstalowano Spotify.");
        }
        public void InstalacjaPSTD()
        {
            this.InstalacjaBazy();
            this.StartInfo.FileName = "java765.exe";
            this.Start();
            Console.WriteLine("Trwa instalacja Java Runtime Enviroment 7u65 dla UKSP...");
            this.WaitForExit();
            Console.WriteLine("Zainstalowano JRE 7u65.");
            this.StartInfo.FileName = @"KlientSWOP_CD\setup.exe";
            this.Start();
            Console.WriteLine("Trwa instalacja SWOP, bądź czujny i klikaj odpowiednio, to długa instalacja...");
            this.WaitForExit();
            Console.WriteLine("Instalacja SWOP ukończona.");
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("Wybierz jaką wersję oprogramowania do kart EKD chcesz zainstalować.Wybór potwierdź Enterem.\n1) Encard 2.1.0 (uniwersalny)\n2) Encard 64bit\n3) CryptoTech 2.1.4");
            ConsoleKeyInfo klawiszEncard = Console.ReadKey(); 
            if (klawiszEncard.Key == ConsoleKey.D1)
            {
                this.StartInfo.FileName = "msiexec.exe";
                this.StartInfo.Arguments = string.Format("/i {0}", $@"{this.StartInfo.WorkingDirectory}Encard\setup.msi");
                this.Start();
                Console.WriteLine("Instaluję Encard 2.1.0...");
                this.WaitForExit();
            }
            else if (klawiszEncard.Key == ConsoleKey.D2)
            {
                this.StartInfo.FileName = "msiexec.exe";
                this.StartInfo.Arguments = string.Format("/i {0}", $@"{this.StartInfo.WorkingDirectory}encard64bit\encard.msi");
                this.Start();
                Console.WriteLine("Instaluję Encard 4.1.5...");
                this.WaitForExit();
            }
            else if (klawiszEncard.Key == ConsoleKey.D3)
            {
                this.StartInfo.FileName = "CCSuite.exe";
                this.Start();
                Console.WriteLine("Instaluję CCSuite...");
                this.WaitForExit();
            }
            else
            {
                Console.WriteLine("Nie wybrano żadnego klienta EKD..Aplikacja przejdzie dalej.");
            }
        }
        public void InstalacjaOffice()
        {
            Console.WriteLine("Czy chcesz zainstalować Oprogramowanie biurowe? Wybierz jedną z opcji.\n1) OpenOffice 4.1.6\n2) Office  2007 Enterprise\n3) Office 2016 MOLP\n Dowolny inny klawisz aby zakończyć!");
            ConsoleKeyInfo klawiszOffice = Console.ReadKey();
            if (klawiszOffice.Key == ConsoleKey.D1)
            {
                this.StartInfo.FileName = "OpenOffice.exe";
                this.Start();
                Console.WriteLine("Instaluję OpenOffice 4.1.6...");
                this.WaitForExit();
            }
            else if (klawiszOffice.Key == ConsoleKey.D2)
            {
                this.StartInfo.FileName = @"office2007\setup.exe";
                this.StartInfo.Arguments = string.Format("/adminfile {0}", $@"{this.StartInfo.WorkingDirectory}office2007\config.msp");
                this.Start();
                Console.WriteLine("Instaluję Office 2007 Enterprise...");
                this.WaitForExit();
            }
            else if (klawiszOffice.Key == ConsoleKey.D3)
            {
                this.StartInfo.FileName = @"office2016\setup.exe";
                this.StartInfo.Arguments = string.Format("/adminfile {0}", $@"{this.StartInfo.WorkingDirectory}office2016\config.msp");
                this.Start();
                Console.WriteLine("Instaluję Office 2016 MOLP...");
                this.WaitForExit();
            }
            else
            {
                Console.WriteLine("Nie wybrano żadnego oprogramowania biurowego..Aplikacja przejdzie dalej.");
            }
            
        }
    }
}
