using System;
using System.IO;
using KWPSerwisInstaller.Configuration;

namespace KWPSerwisInstaller.Main
{
    public class DriverInstaller : Installer
    {
        private string _driverPath;
        private string _finalPath;
        public DriverInstaller()
        {
            _finalPath = LocalParameters.driverFinalPath;
            this.StartInfo.Verb = "runas";
            this.StartInfo.UseShellExecute = false;
            this.StartInfo.CreateNoWindow = false;
            this.StartInfo.RedirectStandardInput = true;
            this.StartInfo.RedirectStandardOutput = true;
            _driverPath = LocalParameters.driverPath;
        }
        public void InstallDriver()
        {
            try
            {
                DirectoryInfo filePath = new DirectoryInfo(_driverPath); // program tworzy zmienna i przypisuje obiekt DI, o sciezce sterownika z pendrive
                Directory.CreateDirectory(_finalPath); // tworzy sciezke docelowa na dysku C:
                FileInfo[] files = filePath.GetFiles(); // Pobiera pliki z pendrive
                foreach (FileInfo file in files) // Wykonuje utworzenie nowej sciezki dla kazdego pliku + kopiuje do sciezki z nadpisem :)
                {
                    string temppath = Path.Combine(_finalPath, file.Name);
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
