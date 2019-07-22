using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Runtime;

namespace KWPSerwisInstaller
{
    class Installer : Process, IInstalacjaBazy
    {
        public Installer()
        {
            this.StartInfo.UseShellExecute = true;
            this.StartInfo.CreateNoWindow = false;
            this.StartInfo.WorkingDirectory = @"C:\KWPSerwisInstaller\Data\";
        }
        public void InstalacjaBazy()
        {
            this.StartInfo.FileName = "7z1900.exe";
            this.Start();
            Console.WriteLine("Instaluję 7-zip..");
            this.WaitForExit();
            Console.WriteLine("Zainstalowano 7-zip.");
            this.StartInfo.FileName = "Adobe11.exe";
            this.StartInfo.Arguments = string.Format($"/qn /i ALLUSERS=1 {this.StartInfo.WorkingDirectory}");
            this.Start();
            Console.WriteLine("Instaluję Adobe Reader XI...");
            this.WaitForExit();
            Console.WriteLine("Zainstalowano Adobe Reader XI.");
            this.StartInfo.FileName = "LotusNotesBasic.exe";
            this.Start();
            Console.WriteLine("Trwa instalacja Klienta Lotus Notes 8.5.2 Basic...");
            this.WaitForExit();
            this.StartInfo.FileName = "KLite1504.exe";
            this.Start();
            this.WaitForExit();
            this.StartInfo.FileName = "OpenOffice.exe";
            this.Start();
            this.WaitForExit();
        }
    }
}
