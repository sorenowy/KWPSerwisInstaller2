using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Windows;
using System.Runtime;
using System.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace KWPSerwisInstaller
{
    class DodajCertyfikat : Installer, IDodajCertyfikat
    {
        private string sciezkaCWI;
        private string sciezkaPSTD;
        public DodajCertyfikat()
        {
            this.sciezkaCWI = sciezkapliku;
            this.sciezkaPSTD = sciezkapliku;
        }
        public void InstalujCWI(string nazwapliku)
        {
            try
            {
                X509Certificate2 certyfikatCWI = new X509Certificate2(sciezkaCWI + nazwapliku);
                X509Store magazyn = new X509Store(StoreName.TrustedPublisher, StoreLocation.LocalMachine);

                magazyn.Open(OpenFlags.ReadWrite);
                magazyn.Add(certyfikatCWI);
                magazyn.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Błąd dogrywania certyfikatu CWI_CERT");
            }
            finally
            {
                Console.WriteLine("Dzieki!");
            }
        }
        public void InstalujInfrastruktura(string nazwapliku)
        {
            try
            {
                X509Certificate2 certyfikatPSTD = new X509Certificate2(sciezkaPSTD + nazwapliku);
                X509Store magazyn = new X509Store(StoreName.TrustedPublisher, StoreLocation.LocalMachine);

                magazyn.Open(OpenFlags.ReadWrite);
                magazyn.Add(certyfikatPSTD);
                magazyn.Close();
                Console.WriteLine("Certyfikat infrastruktura dodano pomyślnie!");
            }
            catch (Exception)
            {
                Console.WriteLine("Cos poszllo nie tak!");
            }
            finally
            {
                Console.WriteLine("Dzieki!");
            }
        }
    }
}
