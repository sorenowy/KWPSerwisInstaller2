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
    class IPConfigLog : Installer, IIPConfigLog
    {
        public string logPath;
        public int option;
        public string inventoryNumber;
        public IPConfigLog()
        {
            this.StartInfo.Verb = "runas";
            this.StartInfo.CreateNoWindow = true;
            this.StartInfo.UseShellExecute = false;
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