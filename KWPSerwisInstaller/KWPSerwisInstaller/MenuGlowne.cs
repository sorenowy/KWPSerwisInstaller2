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
using System.DirectoryServices;
using System.Security;
using System.Windows;
using System.Windows.Forms;

namespace KWPSerwisInstaller
{
    public class MenuGlowne : Form
    {
        //Deklarowanie i inicjalizacja wszystkich elementów menu graficznego.
        private Form menuTworzeniaUsera = new Form();
        private Form menuIpconfig = new Form();
        private Form menuDomeny = new Form();
        private Form instalatorLotus = new Form();
        private Form instalatorEKD = new Form();
        private Form instalatorOffice = new Form();
        private Label stronaGlowna = new Label();
        private Label informacjaLotusa = new Label();
        private Label informacjaEKD = new Label();
        private Label informacjaOffice = new Label();
        private Label podajUsername = new Label();
        private Label podajPassword = new Label();
        private Label podajNrInw = new Label();
        private Label podajNazweDomeny = new Label();
        private ListBox listaLotus = new ListBox();
        private ListBox listaEKD = new ListBox();
        private ListBox listaOffice = new ListBox();
        private TextBox tekstUser = new TextBox();
        private TextBox tekstPassword = new TextBox();
        private TextBox tekstInwentarzowy = new TextBox();
        private TextBox nazwaKomputera = new TextBox();
        private Button przyciskZakoncz = new Button();
        private Button przyciskInternet = new Button();
        private Button przyciskPSTD = new Button();
        private Button przyciskCWI = new Button();
        private Button przyciskAnuluj = new Button();
        private Button przyciskAnulujOffice = new Button();
        private Button przyciskAnulujEKD = new Button();
        private Button przyciskOKLotus = new Button();
        private Button przyciskOKEKD = new Button();
        private Button przyciskOKOffice = new Button();
        private Button przyciskAdmin = new Button();
        private Button przyciskUser = new Button();
        private Button przyciskIpLog = new Button();
        private Button przyciskZmienDomene = new Button();
        public MenuGlowne()
        {
            Installer install = new Installer();
            IPConfigLog log = new IPConfigLog();
            ClassCreateUser user = new ClassCreateUser();
            ZmienNetBIOS zmiana = new ZmienNetBIOS();
            ZmienNetBIOS domena = new ZmienNetBIOS();
            DodajCertyfikat cert = new DodajCertyfikat();
            DriverInstaller driver = new DriverInstaller();
            PolitykaBezpieczenstwa policy = new PolitykaBezpieczenstwa();
            Console.Title = "Log KWP Serwis Installer";
            MessageBox.Show("Witaj w programie Instalacyjnym KWP Serwis Installer v0.7\nUpewnij się że komputer " +
            "jest podłączony do sieci oraz posiada skonfigurowany \nSerwisowy adres IP, by zainstalować wymaganie oprogramowanie. " +
            "W przypadku podłączenia komputera do domeny, miej ustawiony dynamiczny adres IP", "Powitanie");
            MessageBox.Show(Program.Copyright(), "Copyright");
            // Nazwa tytułu aplikacji
            this.Text = "KWP Serwis Installer v0.7";
            this.Size = new Size(760, 560);
            // Załadowanie i wyskalowanie obrazka na stronę tytułową
            Image obrazekTytułowy = Image.FromFile(Environment.CurrentDirectory+@"\Logo\obrazek.jpg");
            stronaGlowna.Left = 120;
            stronaGlowna.Size = new Size(600, 400);
            stronaGlowna.Image = obrazekTytułowy;
            //Ustawianie opisu etykiet listy
            informacjaLotusa.Text = "Wybierz oprogramowanie z listy i zatwierdź OK w celu instalacji.";
            informacjaLotusa.Size = new Size(400, 50);
            informacjaLotusa.Font = new Font("TimesNewRoman", 14f);
            informacjaEKD.Text = informacjaLotusa.Text;
            informacjaEKD.Size = informacjaLotusa.Size;
            informacjaEKD.Font = informacjaLotusa.Font;
            informacjaOffice.Text = informacjaLotusa.Text;
            informacjaOffice.Size = informacjaLotusa.Size;
            informacjaOffice.Font = informacjaLotusa.Font;
            // Ustawianie opisu etykiet menu tworzenia konta, nazwyPC, loga Ipconfig
            podajUsername.Text = "Nazwa użytkownika";
            podajUsername.Size = new Size(200, 50);
            podajUsername.Font = new Font("TimesNewRoman", 10f, FontStyle.Bold);
            podajPassword.Text = "Hasło użytkownika";
            podajPassword.Size = podajUsername.Size;
            podajPassword.Font = podajUsername.Font;
            podajPassword.Top = 50;
            podajNrInw.Text = "Nr inw. komputera";
            podajNrInw.Size = podajUsername.Size;
            podajNrInw.Font = podajUsername.Font;
            podajNazweDomeny.Text = "Nazwa NetBIOS kompuera";
            podajNazweDomeny.Size = podajUsername.Size;
            podajNazweDomeny.Font = podajUsername.Font;
            // Opis przycisku zakończ, ustawienie jego pozycji
            przyciskZakoncz.Text = "Zakończ";
            przyciskZakoncz.Top = 450;
            przyciskZakoncz.Left = 600;
            // Opis pozostałych przycisków, ustawienie ich pozycji
            przyciskInternet.Text = "Ins. Internet";
            przyciskInternet.BackColor = Color.LightBlue;
            przyciskInternet.Top = 400;
            przyciskInternet.Left = 200;
            przyciskPSTD.Text = "Ins. PSTD";
            przyciskPSTD.BackColor = Color.Red;
            przyciskPSTD.Top = 400;
            przyciskPSTD.Left = 400;
            przyciskCWI.Text = "Ins. CWI";
            przyciskCWI.BackColor = Color.LightGreen;
            przyciskCWI.Top = 400;
            przyciskCWI.Left = 600;
            przyciskAnuluj.Text = "Anuluj";
            przyciskAnuluj.ForeColor = Color.Red;
            przyciskAnuluj.Top = 600;
            przyciskAnuluj.Left = 300;
            przyciskAnulujOffice.Text = "Anuluj";
            przyciskAnulujOffice.Top = 600;
            przyciskAnulujOffice.Left = 300;
            przyciskAnulujEKD.Text = przyciskAnuluj.Text;
            przyciskAnulujEKD.Top = przyciskAnuluj.Top;
            przyciskAnulujEKD.Left = przyciskAnuluj.Left;
            //Ustawienia przycisków zatwierdzeń Lotusa,Office i EKD.
            przyciskOKLotus.Text = "OK";
            przyciskOKLotus.Top = 600;
            przyciskOKLotus.Left = 150;
            //Przypisanie do innych..
            przyciskOKEKD.Text = przyciskOKLotus.Text;
            przyciskOKEKD.Top = przyciskOKLotus.Top;
            przyciskOKEKD.Left = 200;
            przyciskOKOffice.Text = przyciskOKLotus.Text;
            przyciskOKOffice.Top = przyciskOKLotus.Top;
            przyciskOKOffice.Left = przyciskOKLotus.Left;
            //Ustawienia przycisków zatwierdzeń kont użyt.,domeny,iploga
            przyciskAdmin.Text = "Admin";
            przyciskAdmin.Top = 100;
            przyciskAdmin.Left = 10;
            przyciskUser.Text = "User";
            przyciskUser.Top = 100;
            przyciskUser.Left = 90;
            przyciskIpLog.Text = "Utwórz";
            przyciskIpLog.Top = 130;
            przyciskIpLog.Left = 10;
            przyciskZmienDomene.Text = "Zmień Netbios";
            przyciskZmienDomene.Size = new Size(100, 50);
            przyciskZmienDomene.Top = 100;
            przyciskZmienDomene.Left = 10;
            //Ustawienia okien wyboru z listy
            instalatorLotus.Text = "Wybierz klienta poczty w celu instalacji.";
            instalatorLotus.Size = new Size(580, 700);
            instalatorEKD.Text = "Wybierz klienta EKD w celu instalacji";
            instalatorEKD.Size = instalatorLotus.Size;
            instalatorOffice.Text = "Wybierz Oprogramowanie Biurowe w celu instalacji.";
            instalatorOffice.Size = instalatorLotus.Size;
            //Ustawienia okien funkcji generujących
            menuTworzeniaUsera.Text = "Wprowadź dane użytkownika i hasło.";
            menuTworzeniaUsera.Size = new Size(500, 200);
            menuIpconfig.Text = "Podaj nazwę loga";
            menuIpconfig.Size = menuTworzeniaUsera.Size;
            menuDomeny.Text = "Wprowadź nową nazwę komputera";
            menuDomeny.Size = menuTworzeniaUsera.Size;
            //Inicjalizacja tablic wyboru instalacji oraz ustawienia rozmiaru i czcionki.
            listaLotus.Items.AddRange
                (new object[]
                {
                "1. Lotus Notes Basic 8.5.3",
                "2. Lotus Notes Standard 8.5.3",
                "3. Mozilla Thunderbird"
                }
                );
            listaLotus.Size = new Size(560, 340);
            listaLotus.Top = 120;
            listaLotus.Font = new Font("TimesNewRoman", 20f);
            listaEKD.Items.AddRange
                (new object[]
                {
                "1. Encard 32bit 2.1.0",
                "2. Encard 64bit 4.1.6",
                "3. CryptoCard Suite 2.1.1"
                }
                );
            listaEKD.Size = listaLotus.Size;
            listaEKD.Top = listaLotus.Top;
            listaEKD.Font = listaLotus.Font;
            listaOffice.Items.AddRange
                (new object[]
                {
                    "1. OpenOffice 4.1.6",
                    "2. Microsoft Office 2007 Enterprise (cs)",
                    "3. Microsoft Office 2016 MOLP",
                    "4. Microsoft Office 2019 MOLP (KGP)"
                });
            listaOffice.Size = listaEKD.Size;
            listaOffice.Top = listaEKD.Top;
            listaOffice.Font = listaEKD.Font;
            //Ustawianie wl. pól tekstowych
            tekstUser.Size = new Size(90, 40);
            tekstUser.Font = new Font("TimesNewRoman", 10f);
            tekstUser.Top = 20;
            tekstUser.Left = 300;
            tekstPassword.Top = 50;
            tekstPassword.Size = tekstUser.Size;
            tekstPassword.Font = tekstUser.Font;
            tekstPassword.Left = tekstUser.Left;
            nazwaKomputera.Size = tekstUser.Size;
            nazwaKomputera.Font = tekstUser.Font;
            nazwaKomputera.Left = tekstUser.Left;
            nazwaKomputera.Top = 20;
            tekstInwentarzowy.Size = tekstUser.Size;
            tekstInwentarzowy.Font = tekstInwentarzowy.Font;
            tekstInwentarzowy.Top = 50;
            tekstInwentarzowy.Left = tekstInwentarzowy.Left;
            //Metody wywołujące..
            void PrzyciskLotusOKClick(object sender, EventArgs ea)
            {
                install.InstalacjaLotus(listaLotus.SelectedIndex);
                instalatorLotus.Close();
            }
            void PrzyciskEKDOKClick(object sender, EventArgs ea)
            {
                install.InstalacjaEKD(listaEKD.SelectedIndex);
                instalatorEKD.Close();
            }
            void PrzyciskOfficeOKClick(object sender,EventArgs ea)
            {
                install.InstalacjaOffice(listaOffice.SelectedIndex);
                instalatorOffice.Close();
            }
            void PrzyciskAdminClick(object sender,EventArgs ea)
            {
                user.kategoria = 1;
                user.name = tekstUser.Text;
                user.password = tekstPassword.Text;
                user.WyswietlUser();
                menuTworzeniaUsera.Close();
            }
            void PrzyciskUserClick(object sender,EventArgs ea)
            {
                user.kategoria = 2;
                user.name = tekstUser.Text;
                user.password = tekstPassword.Text;
                user.WyswietlUser();
                menuTworzeniaUsera.Close();
            }
            void PrzyciskIpLogClick(object sender,EventArgs ea)
            {
                log.opcja = 1;
                log.nrInwentarzowy = tekstInwentarzowy.Text;
                log.GenerujIPConfigLog();
                menuIpconfig.Close();
            }
            void PrzyciskZmienDomeneClick(object sender,EventArgs ea)
            {
                zmiana.nowaNazwa = nazwaKomputera.Text;
                zmiana.ChangeNetBIOS();
                menuDomeny.Close();
            }
            void PrzyciskInternetClick(object sender, EventArgs ea)
            {
                install.Wyczyszczenie();
                Console.WriteLine("Trwa instalacja oprogramowania dla komputera w sieci Internet.");
                instalatorLotus.ShowDialog();
                instalatorOffice.ShowDialog();
                install.InstalacjaInternet();
                DialogResult dialogUser = MessageBox.Show("Czy chcesz utworzyć nowe konto lokalne na komputerze?","Kreator Konta Użytkownika", MessageBoxButtons.YesNo);
                if (dialogUser == DialogResult.Yes)
                {
                    menuTworzeniaUsera.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Wybrałeś opcje nie tworzenia konta.", "Uwaga");
                }
                DialogResult dialogPolicy = MessageBox.Show("Czy chcesz wgrać poliykę bezpieczeństwa na komputerze?", "Polityka Bezpieczeństwa KWP", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Exclamation);
                if(dialogPolicy == DialogResult.Yes)
                {
                    policy.ZainstalujPolitykeBezpieczenstwa();
                }
                else
                {
                    MessageBox.Show("Wybrałeś opcję nie instalowania polityki KWP.", "Uwaga");
                }
                DialogResult dIpconfig = MessageBox.Show("Czy chcesz wygenerować loga funkcji ipconfig, Który zostanie zapisany w folderze /LOGI lokacji instalacyjnej programu?",
                    "Ipconfig Log Generator", MessageBoxButtons.YesNo);
                if (dIpconfig == DialogResult.Yes)
                {
                    menuIpconfig.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Wybrałeś opcje nie tworzenia loga.", "Uwaga");
                }
                DialogResult dNetbios = MessageBox.Show("Czy chcesz dołączyć do domeny? Wybierz Tak, aby dołączyć. Nie aby zmienić tylko nazwę NetBIOS. Anuluj aby pominąć.", 
                    "Domain&NetBIOS connector", MessageBoxButtons.YesNoCancel);
                if (dNetbios == DialogResult.Yes)
                {
                    menuDomeny.ShowDialog();
                    domena.JoinDomain();
                }
                else if (dNetbios == DialogResult.No)
                {
                    menuDomeny.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Wybrałeś opcje nie zmieniania nazwy.","Uwaga");
                }
                DialogResult dRestart = MessageBox.Show("Czy chcesz uruchomić komputer ponownie, aby zapisać zmiany?", "Restart", MessageBoxButtons.YesNo);
                if(dRestart == DialogResult.Yes)
                {
                    Program.Thanks();
                    Process.Start("shutdown", "/r /f /t 0");
                    Close();
                    return;
                }
                else if (dRestart == DialogResult.No)
                {
                    Program.Thanks();
                    Close();
                    return;
                }
            }
            void przyciskPSTDClick(object sender,EventArgs ea)
            {
                install.Wyczyszczenie();
                Console.WriteLine("Trwa instalacja oprogramowania dla komputera w sieci PSTD.");
                instalatorLotus.ShowDialog();
                instalatorOffice.ShowDialog();
                install.InstalacjaPSTD();
                cert.InstalujInfrastruktura("infrastruktura2019.der");
                driver.ZainstalujSterownik();
                instalatorEKD.ShowDialog();
                DialogResult dialogUser = MessageBox.Show("Czy chcesz utworzyć nowe konto lokalne na komputerze?", "Kreator Konta Użytkownika", MessageBoxButtons.YesNo);
                if (dialogUser == DialogResult.Yes)
                {
                    menuTworzeniaUsera.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Wybrałeś opcje nie tworzenia konta.", "Uwaga");
                }
                DialogResult dIpconfig = MessageBox.Show("Czy chcesz wygenerować loga funkcji ipconfig, Który zostanie zapisany w folderze /LOGI lokacji instalacyjnej programu?",
                    "Ipconfig Log Generator", MessageBoxButtons.YesNo);
                if (dIpconfig == DialogResult.Yes)
                {
                    menuIpconfig.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Wybrałeś opcje nie tworzenia loga.", "Uwaga");
                }
                DialogResult dNetbios = MessageBox.Show("Czy chcesz zmienić nazwę komputera? Wybierz Tak, aby dokonać zmiany. Nie aby zakończyć.",
                    "Domain&NetBIOS connector", MessageBoxButtons.YesNo);
                if (dNetbios == DialogResult.Yes)
                {
                    menuDomeny.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Wybrałeś opcje nie zmieniania nazwy.", "Uwaga");
                }
                DialogResult dRestart = MessageBox.Show("Czy chcesz uruchomić komputer ponownie, aby zapisać zmiany?", "Restart", MessageBoxButtons.YesNo);
                if (dRestart == DialogResult.Yes)
                {
                    Program.Thanks();
                    Process.Start("shutdown", "/r /f /t 0");
                    Close();
                    return;
                }
                else if (dRestart == DialogResult.No)
                {
                    Program.Thanks();
                    Close();
                    return;
                }
            }
            void przyciskCWIClick(object sender,EventArgs ea)
            {
                install.Wyczyszczenie();
                instalatorLotus.ShowDialog();
                instalatorOffice.ShowDialog();
                install.InstalacjaCWI();
                cert.InstalujCWI("CWI_CERT.cer");
                DialogResult dialogUser = MessageBox.Show("Czy chcesz utworzyć nowe konto lokalne na komputerze?", "Kreator Konta Użytkownika", MessageBoxButtons.YesNo);
                if (dialogUser == DialogResult.Yes)
                {
                    menuTworzeniaUsera.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Wybrałeś opcje nie tworzenia konta.","Uwaga");
                }
                DialogResult dIpconfig = MessageBox.Show("Czy chcesz wygenerować loga funkcji ipconfig, Który zostanie zapisany w folderze /LOGI lokacji instalacyjnej programu?",
                    "Ipconfig Log Generator", MessageBoxButtons.YesNo);
                if (dIpconfig == DialogResult.Yes)
                {
                    menuIpconfig.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Wybrałeś opcje nie tworzenia konta.","Uwaga");
                }
                DialogResult dNetbios = MessageBox.Show("Czy chcesz zmienić nazwę komputera? Wybierz Tak, aby dokonać zmiany. Nie aby zakończyć.",
                    "Domain&NetBIOS connector", MessageBoxButtons.YesNo);
                if (dNetbios == DialogResult.Yes)
                {
                    menuDomeny.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Wybrałeś opcje nie zmieniania nazwy.","Uwaga");
                }
                DialogResult dRestart = MessageBox.Show("Czy chcesz uruchomić komputer ponownie, aby zapisać zmiany?", "Restart", MessageBoxButtons.YesNo);
                if (dRestart == DialogResult.Yes)
                {
                    Program.Thanks();
                    Process.Start("shutdown", "/r /f /t 0");
                    Close();
                }
                else if (dRestart == DialogResult.No)
                {
                    Program.Thanks();
                    Close();
                }
            }
            void PrzyciskZakonczClick(object sender,EventArgs ea)
            {
                Application.Exit();
            }
            void PrzyciskAnulujClick(object sender, EventArgs ea)
            {
                instalatorLotus.Close();
            }
            void PrzyciskAnulujEKDClick(object sender, EventArgs ea)
            {
                instalatorEKD.Close();
            }
            void PrzyciskAnulujOfficeClick(object sender, EventArgs ea)
            {
                instalatorOffice.Close();
            }
            //Delegowanie metod do eventu przycisku myszy
            przyciskZakoncz.Click += new EventHandler(PrzyciskZakonczClick);
            przyciskInternet.Click += new EventHandler(PrzyciskInternetClick);
            przyciskPSTD.Click += new EventHandler(przyciskPSTDClick);
            przyciskCWI.Click += new EventHandler(przyciskCWIClick);
            przyciskAnuluj.Click += new EventHandler(PrzyciskAnulujClick);
            przyciskAnulujEKD.Click += new EventHandler(PrzyciskAnulujEKDClick);
            przyciskAnulujOffice.Click += new EventHandler(PrzyciskAnulujOfficeClick);
            przyciskOKLotus.Click += new EventHandler(PrzyciskLotusOKClick);
            przyciskOKEKD.Click += new EventHandler(PrzyciskEKDOKClick);
            przyciskOKOffice.Click += new EventHandler(PrzyciskOfficeOKClick);
            przyciskAdmin.Click += new EventHandler(PrzyciskAdminClick);
            przyciskUser.Click += new EventHandler(PrzyciskUserClick);
            przyciskIpLog.Click += new EventHandler(PrzyciskIpLogClick);
            przyciskZmienDomene.Click += new EventHandler(PrzyciskZmienDomeneClick);
            //Dopisywanie opcji do głównego menu i list.
            instalatorLotus.Controls.Add(informacjaLotusa);
            instalatorLotus.Controls.Add(listaLotus);
            instalatorLotus.Controls.Add(przyciskOKLotus);
            instalatorLotus.Controls.Add(przyciskAnuluj);
            instalatorEKD.Controls.Add(informacjaEKD);
            instalatorEKD.Controls.Add(listaEKD);
            instalatorEKD.Controls.Add(przyciskOKEKD);
            instalatorEKD.Controls.Add(przyciskAnulujEKD);
            instalatorOffice.Controls.Add(informacjaOffice);
            instalatorOffice.Controls.Add(listaOffice);
            instalatorOffice.Controls.Add(przyciskOKOffice);
            instalatorOffice.Controls.Add(przyciskAnulujOffice);
            menuTworzeniaUsera.Controls.Add(podajUsername);
            menuTworzeniaUsera.Controls.Add(podajPassword);
            menuTworzeniaUsera.Controls.Add(tekstUser);
            menuTworzeniaUsera.Controls.Add(tekstPassword);
            menuTworzeniaUsera.Controls.Add(przyciskAdmin);
            menuTworzeniaUsera.Controls.Add(przyciskUser);
            menuIpconfig.Controls.Add(podajNrInw);
            menuIpconfig.Controls.Add(tekstInwentarzowy);
            menuIpconfig.Controls.Add(przyciskIpLog);
            menuDomeny.Controls.Add(podajNazweDomeny);
            menuDomeny.Controls.Add(nazwaKomputera);
            menuDomeny.Controls.Add(przyciskZmienDomene);
            Controls.Add(stronaGlowna);
            Controls.Add(przyciskInternet);
            Controls.Add(przyciskPSTD);
            Controls.Add(przyciskCWI);
            Controls.Add(przyciskZakoncz);
        }
    }
}
