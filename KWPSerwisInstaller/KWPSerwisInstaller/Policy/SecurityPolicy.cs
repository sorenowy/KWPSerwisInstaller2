using System;
using System.IO;
using KWPSerwisInstaller.Main;

namespace KWPSerwisInstaller.Policy
{
    public class SecurityPolicy : DriverInstaller
    {
        private string finalPath; //Pobrane w metodzie zawartej w konstruktorze WPF
        private string policyPath; //Pobrane w metodzie zawartej w konstruktorze WPF
        public SecurityPolicy()
        {
            finalPath = @"C:\Data\polityka";
            this.StartInfo.Verb = "runas";
            this.StartInfo.UseShellExecute = false;
            this.StartInfo.CreateNoWindow = false;
            this.StartInfo.RedirectStandardInput = true;
            this.StartInfo.RedirectStandardOutput = true;
            policyPath = Environment.CurrentDirectory + @"\Data\polityka";
        }
        public void ApplySecurityPolicy()
        {
            try
            {
                DirectoryInfo dirPath = new DirectoryInfo(policyPath); // Tworzenie zmiennej ze sciezka polityki na pendrive
                Directory.CreateDirectory(finalPath); // Utworzenie sciezki polityki na dysku C
                FileInfo[] files = dirPath.GetFiles(); // Pobranie plikow
                foreach (FileInfo file in files) // Kopiowanie wszystkiego do nowej lokacji
                {
                    string temppath = Path.Combine(finalPath, file.Name);
                    file.CopyTo(temppath, true);
                }
                this.StartInfo.FileName = @"C:\Windows\System32\cmd.exe";
                this.StartInfo.Arguments = @"/c Secedit /configure /db secedit.sdb /cfg C:\Data\polityka\politykabezp.inf"; // Wywołanie komendy
                this.Start();
                Console.WriteLine(this.StandardOutput.ReadToEnd());
                this.StandardOutput.Close();
                this.WaitForExit();
                /* this.StartInfo.FileName = @"C:\Windows\System32\cmd.exe";
                this.StartInfo.Arguments = @"/c Secedit /refreshpolicy machine_policy /enforce /quiet"; */ // Można wykonać załadowanie automatyczne polityki bez restartowania komputera tym poleceniem!
                Console.WriteLine("Polityka bezpieczeństwa została dodana.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
    
}
