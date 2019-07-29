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
    class DriverInstaller : Installer, IDriverInstall
    {
        public string sciezkaSterownika;
        public DriverInstaller()
        {
            this.StartInfo.Verb = "runas";
            this.StartInfo.UseShellExecute = false;
            this.StartInfo.CreateNoWindow = true;
            this.StartInfo.RedirectStandardInput = true;
            this.StartInfo.RedirectStandardOutput = true;
            sciezkaSterownika = Environment.CurrentDirectory +@"\Data\64\ezusb.inf";
        }
        public void ZainstalujSterownik()
        {
            this.StartInfo.FileName = "cmd.exe";
            this.StartInfo.Arguments = @"C/ pnputil.exe -i -a C:\64\ezusb.inf";
            Console.WriteLine("Instaluje sterownik czytnika kart EZPU100...");
            this.Start();
            this.WaitForExit();
            Console.WriteLine("Sterownik EZPU100 do czytnika kart został zainstalowany.");
            this.Dispose();
        }
    }
}
