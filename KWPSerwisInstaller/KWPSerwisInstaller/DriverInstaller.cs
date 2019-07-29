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
            this.StartInfo.FileName = @"C:\Windows\System32\cmd.exe";
            this.StartInfo.Arguments = @"/c C:\Windows\sysnative\pnputil.exe /i /a C:\x64\ezusb.inf";
            this.Start();
            Console.WriteLine(this.StandardOutput.ReadToEnd());
            this.StandardOutput.Close();
            this.WaitForExit();
            Console.WriteLine("Sterownik EZPU100 do czytnika kart został zainstalowany.");
            this.Dispose();
        }
    }
}
