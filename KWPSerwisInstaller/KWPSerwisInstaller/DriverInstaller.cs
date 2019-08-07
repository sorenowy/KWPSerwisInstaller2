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
    internal class DriverInstaller : Installer
    {
        public string driverPath;
        private string finalPath;
        public DriverInstaller()
        {
            finalPath = @"C:\Data\64";
            this.StartInfo.Verb = "runas";
            this.StartInfo.UseShellExecute = false;
            this.StartInfo.CreateNoWindow = false;
            this.StartInfo.RedirectStandardInput = true;
            this.StartInfo.RedirectStandardOutput = true;
            driverPath = Environment.CurrentDirectory +@"\Data\64";
        }
        public void InstallDriver()
        {
            try
            {
                DirectoryInfo filePath = new DirectoryInfo(driverPath); // program tworzy zmienna i przypisuje obiekt DI, o sciezce sterownika z pendrive
                Directory.CreateDirectory(finalPath); // tworzy sciezke docelowa na dysku C:
                FileInfo[] files = filePath.GetFiles(); // Pobiera pliki z pendrive
                foreach (FileInfo file in files) // Wykonuje utworzenie nowej sciezki dla kazdego pliku + kopiuje do sciezki z nadpisem :)
                {
                    string temppath = Path.Combine(finalPath, file.Name);
                    file.CopyTo(temppath, true);
                }
                this.StartInfo.FileName = @"C:\Windows\System32\cmd.exe"; 
                this.StartInfo.Arguments = @"/c C:\Windows\sysnative\pnputil.exe /i /a C:\Data\64\ezusb.inf"; // wywołanie metody z argumentem w CMD
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
