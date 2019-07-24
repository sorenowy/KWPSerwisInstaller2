using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;
using System.IO;
using System.Diagnostics;
using System.Windows;

namespace KWPSerwisInstaller
{
    class ZmienNetBIOS : Installer,IChangeNetBIOS
    {
        public string nowaNazwa;

        public ZmienNetBIOS()
        {
            
        }
        public void ChangeNetBIOS()
        {
            Console.WriteLine("Podaj nową nazwę komputera!");
            nowaNazwa = Console.ReadLine();
            this.StartInfo.FileName = "WMIC.exe";
            this.StartInfo.Arguments = "computersystem where caption='" + Environment.MachineName + "' rename" + nowaNazwa;
            this.Start();
            this.WaitForExit();
            Console.WriteLine(ExitCode);
        }
    }
}
