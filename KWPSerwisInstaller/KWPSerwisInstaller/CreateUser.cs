using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Windows;
using System.DirectoryServices;
using System.Windows.Forms;

namespace KWPSerwisInstaller
{
    class ClassCreateUser : Installer, ICreateUser
    {
        public string name;
        public string password;
        public int option;
        public ClassCreateUser()
        {
            this.StartInfo.Verb = "runas";
        }
        public void ShowUser()
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Windows Account creator");
            Console.WriteLine("---------------------------------");
            CreateUser(name, password);
        }
        public void CreateUser(string name, string pass)
        {
            try
            {

                DirectoryEntry AD = new DirectoryEntry("WinNT://" + Environment.MachineName);
                DirectoryEntry newUser = AD.Children.Add(name, "user");
                newUser.Invoke("SetPassword", new object[] { pass });
                newUser.CommitChanges();
                Console.WriteLine("Nazwa utworzonego konta:{0}",newUser.Name.ToString());
                DirectoryEntry group;
                if (option == 1)
                {
                    group = AD.Children.Find(@"\Użytkownicy", "group");
                    if (group != null)
                    {
                        group.Invoke("Add", new object[] { newUser.Path.ToString() });
                    }
                }
                else if (option == 2)
                {
                    group = AD.Children.Find(@"\Administratorzy", "group");
                    if (group != null)
                    {
                        group.Invoke("Add", new object[] { newUser.Path.ToString() });
                    }
                }
                AD.Close();
                newUser.Close();
                Console.WriteLine("Konto utworzone prawidłowo.");
                Console.WriteLine("-----------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
            }
        }
    }
}
