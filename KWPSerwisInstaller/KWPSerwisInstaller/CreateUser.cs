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
    class ClassCreateUser : ICreateUser
    {
        public string name;
        public string password;
        public string nazwaGrupy;
        public ClassCreateUser()
        {
           
        }
        public void WyswietlUser()
        {
            Console.WriteLine("Windows Account creator");
            Console.WriteLine("Wprowadź nazwę użytkownika.");
            name = Console.ReadLine();
            Console.WriteLine("Wprowadź hasło użytkownika komputera.");
            password = Console.ReadLine();
            CreateUser(name, password, nazwaGrupy);
        }
        public void WyborGrupy()
        {

        }
        public void CreateUser(string name, string pass, string nazwagrupy)
        {
            try
            {
                
                DirectoryEntry AD = new DirectoryEntry("WinNT://" + Environment.MachineName );
                DirectoryEntry nowyUser = AD.Children.Add(name, "user");
                nowyUser.Invoke("SetPassword", new object[] { pass });
                nowyUser.CommitChanges();
                Console.WriteLine(nowyUser.Guid.ToString());
                AD.Close();
                nowyUser.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
            }
        }
    }
}
