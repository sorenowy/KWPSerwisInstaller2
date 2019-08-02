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
        public string name; // Pobrane w metodzie zawartej w konstruktorze WPF
        public string password; // Pobrane w metodzie zawartej w konstruktorze WPF
        public int option; // Pobrane w metodzie zawartej w konstruktorze WPF
        public ClassCreateUser()
        {
            this.StartInfo.Verb = "runas";
        }
        public void ShowUser()
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Windows Account creator");
            Console.WriteLine("---------------------------------");
            CreateUser(name, password); // Przekazuje dane do metody
        }
        public void CreateUser(string name, string pass)
        {
            try
            {

                DirectoryEntry AD = new DirectoryEntry("WinNT://" + Environment.MachineName); // Tworzy nowy zapis active directory o sciezce maszyny
                DirectoryEntry newUser = AD.Children.Add(name, "user"); // Dodaje potomka do active directory o nazwie name => name zwrocony z metody w WPF
                newUser.Invoke("SetPassword", new object[] { pass }); // wywołuje hasło i dodaje je do kontenera jako "(String = pass) => password zwrocony przez metode w WPF"
                newUser.CommitChanges(); // Wykonuje zmianę
                Console.WriteLine("Nazwa utworzonego konta:{0}",newUser.Name.ToString());
                DirectoryEntry group; // tworzy kolejną scieżkę zmienną AD
                if (option == 1)
                {
                    group = AD.Children.Find(@"\Użytkownicy", "group"); // sprawdza czy istnieje taka grupa w Systemie, jeżeli tak, to dodaje do grupy Uzytkownicy.
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
                newUser.Close(); // Zamyka strumień
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
