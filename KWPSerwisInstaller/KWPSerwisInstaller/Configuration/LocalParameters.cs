using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KWPSerwisInstaller.Configuration
{
    internal class LocalParameters
    {
        internal static bool netconnection = false;

        internal static string netBIOSname = string.Empty;
        internal static string policyFinalDataPath = @"C:\Data\polityka";
        internal static string policyCertPath = Environment.CurrentDirectory + @"\Data\polityka";
        internal static string username = string.Empty;
        internal static string password = string.Empty;

        internal static string installationDataPath = Environment.CurrentDirectory + @"\Data\";
        internal static string driverPath = Environment.CurrentDirectory + @"\Data\64";
        internal static string driverFinalPath = @"C:\Data\64";
        internal static string logPath = Environment.CurrentDirectory + @"\IPConfigLogs\";
        internal static string inventoryNumber = string.Empty;
    }
}
