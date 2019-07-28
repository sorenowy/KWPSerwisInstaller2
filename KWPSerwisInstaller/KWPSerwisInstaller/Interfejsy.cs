using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KWPSerwisInstaller
{
    interface IInstalacjaBazy
    {
        void InstalacjaBazy();
    }
    interface IInstalacjaInternet
    {
        void InstalacjaInternet();
        void InstalacjaCWI();
    }
    interface IInstalacjaPSTD
    {
        void InstalacjaPSTD();
    }
    interface IInstalacjaOffice
    {
        void InstalacjaOffice(int opcja);
    }
    interface IIPConfigLog
    {
        void GenerujIPConfigLog();
    }
    interface ICreateUser
    {
        void WyswietlUser();
        void CreateUser(string a, string b);
    }
    interface IChangeNetBIOS
    {
        void ChangeNetBIOS();
        void JoinDomain();
    }
    interface IDodajCertyfikat
    {
        void InstalujCWI(string sciezkaCWI);
        void InstalujInfrastruktura(string sciezkaPSTD);
    }

}
