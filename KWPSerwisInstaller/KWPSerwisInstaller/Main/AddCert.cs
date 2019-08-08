using System;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using KWPSerwisInstaller.Configuration;

namespace KWPSerwisInstaller.Main
{
    public class AddCert : Installer
    {
        private string _certCWIPath;
        private string _certPSTDPath;
        public AddCert()
        {
            this._certCWIPath = LocalParameters.installationDataPath;
            this._certPSTDPath = LocalParameters.installationDataPath;
        }
        public void InstallCWICert(string filename)
        {
            try
            {
                X509Certificate2 certificateCWI = new X509Certificate2(_certCWIPath + filename); // tworzy lokalną zmienną dopisaną do obiektu X509Cert2
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
                X509Certificate2 certificatePSTD = new X509Certificate2(_certPSTDPath + filename);
                X509Store store = new X509Store(StoreName.TrustedPublisher, StoreLocation.LocalMachine);

                store.Open(OpenFlags.ReadWrite);
                store.Add(certificatePSTD);
                store.Close();
                Console.WriteLine("Certyfikat infrastruktura dodano pomyślnie!");
            }
            catch (Exception)
            {
                Console.WriteLine("Bład dogrania cert. Infrastruktura2019!");
            }
            finally
            {
                Console.WriteLine("---------------------------------");
            }
        }
    }
}
