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
    }
    interface IInstalacjaPSTD
    {
        void InstalacjaPSTD();
    }
    interface IInstalacjaOffice
    {
        void InstalacjaOffice();
    }
    interface IIPConfigLog
    {
        void GenerujIPConfigLog();
    }
    interface ICreateUser
    {
        void WyswietlUser();
        void CreateUser(string a, string b, string c);
    }
    interface IChangeNetBIOS
    {
        void ChangeNetBIOS();
    }
}
