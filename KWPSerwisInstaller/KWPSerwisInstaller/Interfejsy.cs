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
    interface IIPConfigLog
    {
        void GenerujIPConfigLog();
    }
}
