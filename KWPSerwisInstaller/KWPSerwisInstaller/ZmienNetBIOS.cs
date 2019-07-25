﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Windows;
using System.DirectoryServices;
using System.Security;

namespace KWPSerwisInstaller
{
    class ZmienNetBIOS : Installer, IChangeNetBIOS
    {
        public delegate void DelegacjaNetBios();
        public event DelegacjaNetBios ZdarzenieDelegacji;
        public string nowaNazwa;
        public ZmienNetBIOS()
        {
            this.StartInfo.CreateNoWindow = true;
            this.StartInfo.UseShellExecute = false;
            this.StartInfo.RedirectStandardInput = true;
            this.StartInfo.RedirectStandardOutput = true;
        }
        public void ChangeNetBIOS()
        {
            Console.WriteLine("Podaj nową nazwę komputera!");
            nowaNazwa = Console.ReadLine();
            this.StartInfo.FileName = "cmd.exe";
            this.StartInfo.Arguments = "/c wmic computersystem where caption='" + Environment.MachineName + "' rename " + nowaNazwa;
            this.Start();
            this.WaitForExit();
        }
        public void JoinDomain()
        {
            this.ChangeNetBIOS();
            this.StartInfo.FileName = "powershell.exe";
            this.StartInfo.Arguments = "add-computer -domainname kwp-gorzow.intranet";
            this.StartInfo.UserName = "test";
            this.StartInfo.PasswordInClearText = "12345678";
            this.Start();
            this.WaitForExit();
        }
    }
}
