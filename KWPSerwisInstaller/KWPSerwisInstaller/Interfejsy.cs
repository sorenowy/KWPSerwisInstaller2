using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KWPSerwisInstaller
{
    interface IBaseInstaller
    {
        void BaseInstaller();
    }
    interface IInternetInstaller
    {
        void InternetInstaller();
        void CWIInstaller();
    }
    interface IPSTDInstaller
    {
        void PSTDInstaller();
    }
    interface IOfficeInstaller
    {
        void OfficeInstaller(int opcja);
    }
    interface IIPConfigLog
    {
        void GenerateIPConfigLog();
    }
    interface ICreateUser
    {
        void ShowUser();
        void CreateUser(string a, string b);
    }
    interface IChangeNetBIOS
    {
        void ChangeNetBIOS();
        void JoinDomain();
    }
    interface IAddCertificate
    {
        void InstallCWICert(string sciezkaCWI);
        void InstallInfrastrukturaCert(string sciezkaPSTD);
    }
    interface IDriverInstall
    {
        void InstallDriver();
    }
    interface ISecurityPolicy
    {
        void ApplySecurityPolicy();
    }
}
