using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KWPSerwisInstaller
{
    class ConsoleMenu :Installer
    {
        public string[] tablicaMenuG = { "1. Internet", "2. PSTD", "3. CWI" };
        public string[] tablicaPoczty = { "1. Lotus Notes Basic 8.5.3", "2. Lotus Notes Standard 8.5.3", "3. Mozilla Thunderbird" };
        public string[] tablicaEKD = { "1. Encard 2.1.0 - stary Encard", "2. Encard 4.1.6 - 64bit", "3. CryptoTech Suite 2.11" };
        public string[] tablicaoffice = { "1. OpenOffice 4.1.6", "2. Microsoft Office 2007 Enterprise - Pirat", "3. Microsoft Office 2016 MOLP", "4. Microsoft Office 2019 MOLP" };
        public string[] tablicaCreateUser = { "1. Administrator", "2. Użytkownik" };
        public string[] tablicaNetbios = { "1. Zmień NetBIOS Komputera", "2. Zmień NetBIOS komputera i dołącz do istniejącej domeny" };
        public string[] tablicaIpconfig = { "1. Utwórz log polecenia ipconfig -all", "2. Nie twórz logu" };
        int aktywnaPozycjaMenu = 0;

        public static void StartMenu()
        {
            ConsoleMenu menu = new ConsoleMenu();
            Console.Title= "Instalator KWP Serwis v0.7";
            Console.CursorVisible = false;
            while (true)
            {

                Program.Prezentacja();
                menu.PokazMenu();
                menu.WybieranieOpcjiMenuGlownego();
                menu.MenuGlowne();
                
            }
        }
        public void WybieranieOpcjiMenuGlownego()
        {
            do
            {
                ConsoleKeyInfo klawisz = Console.ReadKey();
                if (klawisz.Key == ConsoleKey.UpArrow)
                {
                    aktywnaPozycjaMenu = (aktywnaPozycjaMenu > 0) ? aktywnaPozycjaMenu - 1 : tablicaMenuG.Length - 1;
                    PokazMenu();
                }
                else if (klawisz.Key == ConsoleKey.DownArrow)
                {
                    aktywnaPozycjaMenu = (aktywnaPozycjaMenu + 1) % tablicaMenuG.Length;
                    PokazMenu();
                }
                else if (klawisz.Key == ConsoleKey.Escape)
                {
                    aktywnaPozycjaMenu = tablicaMenuG.Length - 1;
                    break;
                }
                else if (klawisz.Key == ConsoleKey.Enter)
                {
                    break;
                }
            } while (true);
        }
        public void PokazMenu()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine();
            for (int i = 0; i < tablicaMenuG.Length; i++)
            {
                if (i == aktywnaPozycjaMenu)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("{0,-35}", tablicaMenuG[i]);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.WriteLine(tablicaMenuG[i]);
                }
            }
            

        } 
        public void MenuGlowne()
        {
            switch (aktywnaPozycjaMenu)
            {
                case 0: Console.Clear(); InstalacjaInternet(); break;
                case 1: Console.Clear(); InstalacjaPSTD(); break;
                case 2: Console.Clear(); InstalacjaCWI(); break;
            }
        }
        public void MenuPoczty()
        {

        }
        public void MenuEKD()
        {

        }
        public void MenuOffice()
        {

        }
        public void MenuCreateUser()
        {

        }
        public void MenuNetbios()
        {

        }
        public void MenuIpconfig()
        {

        }
    }
}
