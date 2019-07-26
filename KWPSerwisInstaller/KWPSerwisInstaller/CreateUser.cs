using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Windows;
using System.DirectoryServices;

namespace KWPSerwisInstaller
{
    class ClassCreateUser : Installer, ICreateUser
    {
        public string name;
        public string password;
        public int kategoria;
        public ClassCreateUser()
        {
            this.StartInfo.Verb = "runas";
        }
        public void WyswietlUser()
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Windows Account creator");
            Console.WriteLine("Wprowadź nazwę użytkownika.");
            name = Console.ReadLine();
            Console.WriteLine("Wprowadź hasło użytkownika komputera.");
            password = Console.ReadLine();
            Console.WriteLine("Chcesz utworzyć konto \n1)Użytkownika czy \n2)Administratora?");
            Console.Write(" wybierz numer i zatwierdź enterem.");
            kategoria = int.Parse(Console.ReadLine());
            CreateUser(name, password);
        }
        public void WyborGrupy()
        {

        }
        public void CreateUser(string name, string pass)
        {
            try
            {

                DirectoryEntry AD = new DirectoryEntry("WinNT://" + Environment.MachineName);
                DirectoryEntry nowyUser = AD.Children.Add(name, "user");
                nowyUser.Invoke("SetPassword", new object[] { pass });
                nowyUser.CommitChanges();
                Console.WriteLine(nowyUser.Name.ToString());
                DirectoryEntry grupa;
                if (kategoria == 1)
                {
                    grupa = AD.Children.Find(@"\Użytkownicy", "group");
                    if (grupa != null)
                    {
                        grupa.Invoke("Add", new object[] { nowyUser.Path.ToString() });
                    }
                }
                else if (kategoria == 2)
                {
                    grupa = AD.Children.Find(@"\Administratorzy", "group");
                    if (grupa != null)
                    {
                        grupa.Invoke("Add", new object[] { nowyUser.Path.ToString() });
                    }
                }
                AD.Close();
                nowyUser.Close();
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
