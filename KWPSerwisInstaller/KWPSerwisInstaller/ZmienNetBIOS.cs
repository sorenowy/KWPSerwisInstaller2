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
    class ZmienNetBIOS : Installer, IChangeNetBIOS
    {
        public string nowaNazwa;
        public string nazwaAdmina;

        public ZmienNetBIOS()
        {
            this.StartInfo.CreateNoWindow = true;
            this.StartInfo.UseShellExecute = false;
            this.StartInfo.RedirectStandardInput = true;
            this.StartInfo.RedirectStandardOutput = true;
            this.StartInfo.Verb = $"runas /user:{nazwaAdmina}";
        }
        public void ChangeNetBIOS()
        {
            Console.WriteLine("Podaj nową nazwę komputera!");
            nowaNazwa = Console.ReadLine();
            this.StartInfo.FileName = "cmd.exe";
            this.StartInfo.Arguments = "/c wmic computersystem where caption='" + Environment.MachineName + "' rename " + nowaNazwa;
            this.Start();
            this.WaitForExit();
        }
    }
}
