using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Runtime;
using System.Windows;
using System.Windows.Forms;

namespace KWPSerwisInstaller
{
    public partial class MenuGlowne : Form
    {
        //Deklarowanie i inicjalizacja wszystkich elementów menu graficznego.
        private Form instalatorLotus = new Form();
        private Form instalatorEKD = new Form();
        private Form instalatorOffice = new Form();
        private Label stronaGlowna = new Label();
        private ListBox listaLotus = new ListBox();
        private ListBox listaEKD = new ListBox();
        private ListBox listaOffice = new ListBox();
        private Button przyciskZakoncz = new Button();
        private Button przyciskInternet = new Button();
        private Button przyciskPSTD = new Button();
        private Button przyciskCWI = new Button();
        private Button przyciskAnuluj = new Button();
        public MenuGlowne()
        {
            MessageBox.Show("Witaj w programie Instalacyjnym KWP Serwis Installer v0.7\nUpewnij się że komputer " +
            "jest podłączony do sieci oraz posiada skonfigurowany \nSerwisowy adres IP, by zainstalować wymaganie oprogramowanie. " +
            "W przypadku podłączenia komputera do domeny, miej ustawiony dynamiczny adres IP", "Powitanie");
            // Nazwa tytułu aplikacji
            Text = "KWP Serwis Installer v0.7";
            // Załadowanie i wyskalowanie obrazka na stronę tytułową
            Image obrazekTytułowy = Image.FromFile(Environment.CurrentDirectory);
            stronaGlowna.Size = new Size(stronaGlowna.Height, stronaGlowna.Width);
            stronaGlowna.Image = obrazekTytułowy;
            // Opis przycisku zakończ, ustawienie jego pozycji
            przyciskZakoncz.Text = "Zakończ";
            przyciskZakoncz.Top = 600;
            przyciskZakoncz.Left = 800;
            // Opis pozostałych przycisków, ustawienie ich pozycji
            przyciskInternet.Text = "Instaluj Internet";
            przyciskInternet.BackColor = Color.LightBlue;
            przyciskInternet.Top = 400;
            przyciskInternet.Left = 200;
            przyciskPSTD.Text = "Instaluj PSTD";
            przyciskPSTD.BackColor = Color.Red;
            przyciskPSTD.Top = 400;
            przyciskPSTD.Left = 500;
            przyciskCWI.Text = "Instaluj CWI.";
            przyciskCWI.BackColor = Color.LightGreen;
            przyciskCWI.Top = 400;
            przyciskCWI.Left = 700;
            przyciskAnuluj.Text = "Anuluj";
            przyciskAnuluj.ForeColor = Color.Red;
            przyciskAnuluj.Top = 600;
            przyciskAnuluj.Left = 500;
            //Ustawienia okien wyboru z listy
            instalatorLotus.Text = "Wybierz klienta poczty w celu instalacji.";
            instalatorLotus.Size = new Size(1200, 700);
            instalatorEKD.Text = "Wybierz klienta EKD w celu instalacji";
            instalatorEKD.Size = instalatorLotus.Size;
            instalatorOffice.Text = "Wybierz Oprogramowanie Biurowe w celu instalacji.";
            instalatorOffice.Size = instalatorLotus.Size;
            //Inicjalizacja tablic wyboru instalacji
            listaLotus.Items.AddRange
                (new object[]
                {
                "1. Lotus Notes Basic 8.5.3",
                "2. Lotus Notes Standard 8.5.3",
                "3. Mozilla Thunderbird"
                }
                );
            listaEKD.Items.AddRange
                (new object[]
                {
                "1. Encard 32bit 2.1.0",
                "2. Encard 64bit 4.1.6",
                "3. CryptoCard Suite 2.1.1"
                }
                );
            listaOffice.Items.AddRange
                (new object[]
                {
                    "1. OpenOffice 4.1.6",
                    "2. Microsoft Office 2007 Enterprise (cs)",
                    "3. Microsoft Office 2016 MOLP",
                    "4. Microsoft Office 2019 MOLP (KGP)"
                });
            void PrzyciskInternetClick(object sender, EventArgs ea)
            {
                Installer install = new Installer();
                IPConfigLog log = new IPConfigLog();
                ClassCreateUser user = new ClassCreateUser();
                ZmienNetBIOS zmiana = new ZmienNetBIOS();
                instalatorLotus.ShowDialog();
                instalatorOffice.ShowDialog();
                install.InstalacjaInternet();
                MessageBox.Show("Czy chcesz utworzyć nowe konto lokalne na komputerze?","Kreator Konta Użytkownika");
                MessageBoxButtons przyciskiUsera = MessageBoxButtons.YesNo;
                user.WyswietlUser();
                MessageBox.Show("Czy chcesz wygenerować loga funkcji ipconfig, Który zostanie zapisany w folderze /LOGI lokacji instalacyjnej programu?",
                    "Ipconfig Log Generator");
                MessageBoxButtons przyciskiLoga = MessageBoxButtons.YesNo;
                log.GenerujIPConfigLog();
                MessageBox.Show("Czy chcesz dołączyć do domeny? Wybierz Tak, aby dołączyć. Nie aby zmienić tylko nazwę NetBIOS. Anuluj aby pominąć.", 
                    "Domain&NetBIOS connector");
                MessageBoxButtons przyciskiDomeny = MessageBoxButtons.YesNoCancel;
                MessageBox.Show("Czy chcesz uruchomić komputer ponownie, aby zapisać zmiany?", "Restart");
                messageboxbuttons przyciskiRestartu = MessageBoxButtons.YesNo;
            }
            void PrzyciskZakonczClick(object sender,EventArgs ea)
            {
                Application.Exit();
            }
        }
    }
}
