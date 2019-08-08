using System;
using System.IO;
using KWPSerwisInstaller.Main;
using KWPSerwisInstaller.Configuration;

namespace KWPSerwisInstaller.Logs
{
    public class IPConfigLog : Installer
    {
        private string _logPath; // Pobrane w metodzie zawartej w konstruktorze WPF
        public int option; // Pobrane w metodzie zawartej w konstruktorze WPF
        public IPConfigLog()
        {
            this.StartInfo.Verb = "runas";
            this.StartInfo.CreateNoWindow = true;
            this.StartInfo.UseShellExecute = false; // Koniecznie musi byc false, zeby nie uruchamiało shella systemu! inaczej CMD nie przyjmie danych!
            this.StartInfo.RedirectStandardInput = true;
            this.StartInfo.RedirectStandardOutput = true;
            _logPath = LocalParameters.logPath;
        }
        public void GenerateIPConfigLog()
        {
            Console.WriteLine("Program wygeneruje teraz Log IPCONFIG -ALL");
            Console.WriteLine(@"Który zostanie zapisany w folderze /LOGI lokacji instalacyjnej programu");
            Console.WriteLine("---------------------------------------------------------------------------------");
            if (option == 1)
            {
                try
                {
                    this.StartInfo.FileName = "Cmd.exe";
                    this.StartInfo.Arguments = ($@"/c ipconfig -all > C:\{LocalParameters.inventoryNumber}.txt");
                    this.Start();
                    this.WaitForExit();
                    File.Move($@"C:\{LocalParameters.inventoryNumber}.txt", $@"{_logPath}{LocalParameters.inventoryNumber}.txt");
                    Console.WriteLine("Utworzono ipconfig Log o nazwie {0} w lokacji \n{1}",LocalParameters.inventoryNumber,_logPath);
                }
                catch (Exception e)
                {
                    Console.WriteLine("wystąpił błąd"+e.Message);
                }
                finally
                {
                    Console.WriteLine();
                    Console.WriteLine("-----------------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("Wybrałeś opcję nie generowania logu.");
                Console.ReadKey();
            }
        }
    }
}