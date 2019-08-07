using System;
using System.IO;
using KWPSerwisInstaller.Main;

namespace KWPSerwisInstaller.Logs
{
    public class IPConfigLog : Installer
    {
        public string logPath; // Pobrane w metodzie zawartej w konstruktorze WPF
        public int option; // Pobrane w metodzie zawartej w konstruktorze WPF
        public string inventoryNumber; // Pobrane w metodzie zawartej w konstruktorze WPF
        public IPConfigLog()
        {
            this.StartInfo.Verb = "runas";
            this.StartInfo.CreateNoWindow = true;
            this.StartInfo.UseShellExecute = false; // Koniecznie musi byc false, zeby nie uruchamiało shella systemu! inaczej CMD nie przyjmie danych!
            this.StartInfo.RedirectStandardInput = true;
            this.StartInfo.RedirectStandardOutput = true;
            logPath = Environment.CurrentDirectory + @"\Logi\";
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
                    this.StartInfo.Arguments = ($@"/c ipconfig -all > C:\{inventoryNumber}.txt");
                    this.Start();
                    this.WaitForExit();
                    File.Move($@"C:\{inventoryNumber}.txt", $@"{logPath}{inventoryNumber}.txt");
                    Console.WriteLine("Utworzono ipconfig Log o nazwie {0} w lokacji \n{1}",inventoryNumber,logPath);
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