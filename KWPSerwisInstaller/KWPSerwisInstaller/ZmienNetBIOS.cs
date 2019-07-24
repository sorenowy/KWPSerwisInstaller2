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

        public ZmienNetBIOS()
        {
            this.StartInfo.Verb = "runas";
        }
        public void ChangeNetBIOS()
        {
            Console.WriteLine("Podaj nową nazwę komputera!");
            nowaNazwa = Console.ReadLine();
            this.StartInfo.FileName = "cmd.exe";
            this.StartInfo.Arguments = "wmic computersystem where caption='" + Environment.MachineName + "' rename " + nowaNazwa;
            this.Start();
            this.WaitForExit();
        }
    }
}
