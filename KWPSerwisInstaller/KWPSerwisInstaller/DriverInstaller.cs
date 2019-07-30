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
        private string sciezkaDocelowa;
        public DriverInstaller()
        {
            sciezkaDocelowa = @"C:\Data\64";
            this.StartInfo.Verb = "runas";
            this.StartInfo.UseShellExecute = false;
            this.StartInfo.CreateNoWindow = false;
            this.StartInfo.RedirectStandardInput = true;
            this.StartInfo.RedirectStandardOutput = true;
            sciezkaSterownika = Environment.CurrentDirectory +@"\Data\64";
        }
        public void ZainstalujSterownik()
        {
            try
            {
                DirectoryInfo sciezkaDoc = new DirectoryInfo(sciezkaSterownika);
                Directory.CreateDirectory(sciezkaDocelowa);
                FileInfo[] pliki = sciezkaDoc.GetFiles();
                foreach (FileInfo plik in pliki)
                {
                    string temppath = Path.Combine(sciezkaDocelowa, plik.Name);
                    plik.CopyTo(temppath, true);
                }
                this.StartInfo.FileName = @"C:\Windows\System32\cmd.exe";
                this.StartInfo.Arguments = @"/c C:\Windows\sysnative\pnputil.exe /i /a C:\Data\64\ezusb.inf";
                this.Start();
                Console.WriteLine(this.StandardOutput.ReadToEnd());
                this.StandardOutput.Close();
                this.WaitForExit();
                Console.WriteLine("Sterownik EZPU100 do czytnika kart został zainstalowany.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
