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
    class DodajCertyfikat : Installer, IAddCertificate
    {
        private string certCWIPath;
        private string certPSTDPath;
        public DodajCertyfikat()
        {
            this.certCWIPath = filePath;
            this.certPSTDPath = filePath;
        }
        public void InstallCWICert(string filename)
        {
            try
            {
                X509Certificate2 certificateCWI = new X509Certificate2(certCWIPath + filename); // tworzy lokalną zmienną dopisaną do obiektu X509Cert2
                X509Store store = new X509Store(StoreName.TrustedPublisher, StoreLocation.LocalMachine); // tworzy zmienną obiektu X509Store czyli wskazuje na konkretny magazyn w konkretnym miejscu (zaufane gl. urz. certyfikacji)

                store.Open(OpenFlags.ReadWrite); //Otwiera magazyn i zezwala na zapis/odczyt
                store.Add(certificateCWI); // dodaje ceryfikat
                store.Close();
                Console.WriteLine("Certyfikat CWI_CERT dograny pomyślnie!");
            }
            catch (Exception)
            {
                Console.WriteLine("Błąd dogrywania certyfikatu CWI_CERT");
            }
            finally
            {
                Console.WriteLine("-------------------------------");
            }
        }
        public void InstallInfrastrukturaCert(string filename)
        {
            try
            {
                X509Certificate2 certificatePSTD = new X509Certificate2(certPSTDPath + filename);
                X509Store store = new X509Store(StoreName.TrustedPublisher, StoreLocation.LocalMachine);

                store.Open(OpenFlags.ReadWrite);
                store.Add(certificatePSTD);
                store.Close();
                Console.WriteLine("Certyfikat infrastruktura dodano pomyślnie!");
            }
            catch (Exception)
            {
                Console.WriteLine("Cos poszllo nie tak!");
            }
            finally
            {
                Console.WriteLine("---------------------------------");
            }
        }
    }
}
