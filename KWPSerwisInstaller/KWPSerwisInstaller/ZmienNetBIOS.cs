using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Windows;
using System.DirectoryServices;
using System.Security;
using System.Windows.Forms;

namespace KWPSerwisInstaller
{
    class ZmienNetBIOS : Installer, IChangeNetBIOS
    {
        public string nowaNazwa;
        public ZmienNetBIOS()
        {
            this.StartInfo.CreateNoWindow = true;
            this.StartInfo.UseShellExecute = false;
            this.StartInfo.RedirectStandardInput = true;
            this.StartInfo.RedirectStandardOutput = true;
        }
        public void ChangeNetBIOS()
        {
            try
            {
                Console.WriteLine("Podaj nową nazwę komputera! Nazwę potwierdź enterem.");
                nowaNazwa = Console.ReadLine();
                this.StartInfo.FileName = "cmd.exe";
                this.StartInfo.Arguments = "/c wmic computersystem where caption='" + Environment.MachineName + "' rename " + nowaNazwa;
                this.Start();
                this.WaitForExit();
                Console.WriteLine("Zmiana nazwy NetBIOS wykonana pomyślnie!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("------------------------------");
            }
        }
        public void JoinDomain()
        {
            try
            {
                this.ChangeNetBIOS();
                this.StartInfo.FileName = "powershell.exe";
                this.StartInfo.Arguments = "add-computer -domainname kwp-gorzow.intranet";
                this.Start();
                this.WaitForExit();
                Console.WriteLine("Udało się podłączyć do domeny.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("------------------------------");
            }
        }
    }
}
