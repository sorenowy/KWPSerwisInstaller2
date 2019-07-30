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
    class PolitykaBezpieczenstwa : DriverInstaller, IPolitykaBezp
    {
        private string sciezkaDocelowa;
        private string sciezkaPolityki;
        public PolitykaBezpieczenstwa()
        {
            sciezkaDocelowa = @"C:\Data\polityka";
            this.StartInfo.Verb = "runas";
            this.StartInfo.UseShellExecute = false;
            this.StartInfo.CreateNoWindow = false;
            this.StartInfo.RedirectStandardInput = true;
            this.StartInfo.RedirectStandardOutput = true;
            sciezkaSterownika = Environment.CurrentDirectory + @"\Data\polityka";
        }
        public void ZainstalujPolitykeBezpieczenstwa()
        {
            try
            {
                DirectoryInfo sciezkaDoc = new DirectoryInfo(sciezkaPolityki);
                Directory.CreateDirectory(sciezkaDocelowa);
                FileInfo[] pliki = sciezkaDoc.GetFiles();
                foreach (FileInfo plik in pliki)
                {
                    string temppath = Path.Combine(sciezkaDocelowa, plik.Name);
                    plik.CopyTo(temppath, true);
                }
                this.StartInfo.FileName = @"C:\Windows\System32\cmd.exe";
                this.StartInfo.Arguments = @"/c Secedit /configure /db secedit.sdb /cfg C:\Data\polityka\politykabezp.inf";
                this.Start();
                Console.WriteLine(this.StandardOutput.ReadToEnd());
                this.StandardOutput.Close();
                this.WaitForExit();
                Console.WriteLine("Polityka bezpieczeństwa została dodana.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
    
}
