using System;
using KWPSerwisInstaller.Main;

namespace KWPSerwisInstaller
{
    public class NetBIOSChange : Installer
    {
        public string newNETBiosName;
        public NetBIOSChange()
        { 
            this.StartInfo.Verb = "runas";
        }
        public void ChangeNetBIOS()
        {
            try
            { /* Ustawienia wlasciwosci są w tej metodzie z racji braku przekazywania jej w konstruktorze WPF, 
                ktory automatycznie przyjmuje i nie wykonuje funkcji UseShellExecute, 
                kluczowej do wykonania w przypadku wywołania powershella! 
                Stąd przekazany został do metody ChangeNetBIOS zamiast do konstruktora klasy.*/
                this.StartInfo.CreateNoWindow = true;
                this.StartInfo.UseShellExecute = false;
                this.StartInfo.RedirectStandardInput = true;
                this.StartInfo.RedirectStandardOutput = true;
                this.StartInfo.FileName = "cmd.exe";
                this.StartInfo.Arguments = "/c wmic computersystem where caption='" + Environment.MachineName + "' rename " + newNETBiosName;
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
                this.StartInfo.FileName = "powershell.exe";
                this.StartInfo.Arguments = "add-computer -domainname kwp-gorzow.intranet";
                this.Start();
                this.WaitForExit();
                Console.WriteLine("Udało się podłączyć do domeny.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                Console.WriteLine("------------------------------");
            }
        }
    }
}
