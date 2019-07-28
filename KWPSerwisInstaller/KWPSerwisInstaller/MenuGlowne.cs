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
    public class MenuGlowne : Form
    {
        //Deklarowanie i inicjalizacja wszystkich elementów menu graficznego.
        private Form instalatorLotus = new Form();
        private Form instalatorEKD = new Form();
        private Form instalatorOffice = new Form();
        private Label stronaGlowna = new Label();
        private Label informacjaLotusa = new Label();
        private Label informacjaEKD = new Label();
        private Label informacjaOffice = new Label();
        private ListBox listaLotus = new ListBox();
        private ListBox listaEKD = new ListBox();
        private ListBox listaOffice = new ListBox();
        private Button przyciskZakoncz = new Button();
        private Button przyciskInternet = new Button();
        private Button przyciskPSTD = new Button();
        private Button przyciskCWI = new Button();
        private Button przyciskAnuluj = new Button();
        private Button przyciskAnulujLotus = new Button();
        private Button przyciskAnulujEKD = new Button();
        private Button przyciskOKLotus = new Button();
        private Button przyciskOKEKD = new Button();
        private Button przyciskOKOffice = new Button();
        public MenuGlowne()
        {
            Installer install = new Installer();
            IPConfigLog log = new IPConfigLog();
            ClassCreateUser user = new ClassCreateUser();
            ZmienNetBIOS zmiana = new ZmienNetBIOS();
            DodajCertyfikat cert = new DodajCertyfikat();
            Console.Title = "Log KWP Serwis Installer";
            MessageBox.Show("Witaj w programie Instalacyjnym KWP Serwis Installer v0.7\nUpewnij się że komputer " +
            "jest podłączony do sieci oraz posiada skonfigurowany \nSerwisowy adres IP, by zainstalować wymaganie oprogramowanie. " +
            "W przypadku podłączenia komputera do domeny, miej ustawiony dynamiczny adres IP", "Powitanie");
            MessageBox.Show(Program.Copyright(), "Copyright");
            // Nazwa tytułu aplikacji
            Text = "KWP Serwis Installer v0.7";
            Size = new Size(760, 560);
            // Załadowanie i wyskalowanie obrazka na stronę tytułową
            Image obrazekTytułowy = Image.FromFile(Environment.CurrentDirectory+@"\Logo\obrazek.jpg");
            stronaGlowna.Left = 120;
            stronaGlowna.Size = new Size(600, 400);
            stronaGlowna.Image = obrazekTytułowy;
            //Ustawianie opisu listy
            informacjaLotusa.Text = "Wybierz oprogramowanie z listy i zatwierdź OK w celu instalacji.";
            informacjaLotusa.Size = new Size(400, 50);
            informacjaLotusa.Font = new Font("TimesNewRoman", 14f);
            informacjaEKD.Text = informacjaLotusa.Text;
            informacjaEKD.Size = informacjaLotusa.Size;
            informacjaEKD.Font = informacjaLotusa.Font;
            informacjaOffice.Text = informacjaLotusa.Text;
            informacjaOffice.Size = informacjaLotusa.Size;
            informacjaOffice.Font = informacjaLotusa.Font;
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
            przyciskAnulujLotus.Text = "Anuluj";
            przyciskAnulujLotus.Top = 600;
            przyciskAnulujLotus.Left = 300;
            //Ustawienia przycisków zatwierdzeń Lotusa,Office i EKD.
            przyciskOKLotus.Text = "OK";
            przyciskOKLotus.Top = 600;
            przyciskOKLotus.Left = 150;
            //Przypisanie do innych..
            przyciskOKEKD.Text = przyciskOKLotus.Text;
            przyciskOKEKD.Top = przyciskOKLotus.Top;
            przyciskOKEKD.Left = przyciskOKEKD.Left;
            przyciskOKOffice.Text = przyciskOKLotus.Text;
            przyciskOKOffice.Top = przyciskOKLotus.Top;
            przyciskOKOffice.Left = przyciskOKLotus.Left;
            //Ustawienia okien wyboru z listy
            instalatorLotus.Text = "Wybierz klienta poczty w celu instalacji.";
            instalatorLotus.Size = new Size(580, 700);
            instalatorEKD.Text = "Wybierz klienta EKD w celu instalacji";
            instalatorEKD.Size = instalatorLotus.Size;
            instalatorOffice.Text = "Wybierz Oprogramowanie Biurowe w celu instalacji.";
            instalatorOffice.Size = instalatorLotus.Size;
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
            //Metody wywołujące..
            void PrzyciskLotusOKClick(object sender, EventArgs ea)
            {
                install.InstalacjaLotus(listaLotus.SelectedIndex);
                Close();
            }
            void PrzyciskEKDOKClick(object sender, EventArgs ea)
            {
                install.InstalacjaEKD(listaEKD.SelectedIndex);
                Close();
            }
            void PrzyciskOfficeOKClick(object sender,EventArgs ea)
            {
                install.InstalacjaOffice(listaOffice.SelectedIndex);
                Close();
            }
            void PrzyciskInternetClick(object sender, EventArgs ea)
            {
                instalatorLotus.ShowDialog();
                instalatorOffice.ShowDialog();
                install.InstalacjaInternet();
                DialogResult dialogUser = MessageBox.Show("Czy chcesz utworzyć nowe konto lokalne na komputerze?","Kreator Konta Użytkownika", MessageBoxButtons.YesNo);
                if (dialogUser == DialogResult.Yes)
                {
                    user.WyswietlUser();
                }
                DialogResult dIpconfig = MessageBox.Show("Czy chcesz wygenerować loga funkcji ipconfig, Który zostanie zapisany w folderze /LOGI lokacji instalacyjnej programu?",
                    "Ipconfig Log Generator", MessageBoxButtons.YesNo);
                if (dIpconfig == DialogResult.Yes)
                {
                    log.GenerujIPConfigLog();
                }
                DialogResult dNetbios = MessageBox.Show("Czy chcesz dołączyć do domeny? Wybierz Tak, aby dołączyć. Nie aby zmienić tylko nazwę NetBIOS. Anuluj aby pominąć.", 
                    "Domain&NetBIOS connector", MessageBoxButtons.YesNoCancel);
                if (dNetbios == DialogResult.Yes)
                {
                    zmiana.JoinDomain();
                }
                else if (dNetbios == DialogResult.No)
                {
                    zmiana.ChangeNetBIOS();
                }
                DialogResult dRestart = MessageBox.Show("Czy chcesz uruchomić komputer ponownie, aby zapisać zmiany?", "Restart", MessageBoxButtons.YesNo);
                if(dRestart == DialogResult.Yes)
                {
                    Process.Start("shutdown", "/r /f /t 0");
                }
                else if (dRestart == DialogResult.No)
                {
                    return;
                }
            }
            void przyciskPSTDClick(object sender,EventArgs ea)
            {
                Console.WriteLine("Trwa instalacja oprogramowania dla komputera w sieci PSTD.");
                instalatorLotus.ShowDialog();
                instalatorOffice.ShowDialog();
                install.InstalacjaPSTD();
                cert.InstalujInfrastruktura("infrastruktura2019.der");
                instalatorEKD.ShowDialog();
                DialogResult dialogUser = MessageBox.Show("Czy chcesz utworzyć nowe konto lokalne na komputerze?", "Kreator Konta Użytkownika", MessageBoxButtons.YesNo);
                if (dialogUser == DialogResult.Yes)
                {
                    user.WyswietlUser();
                }
                DialogResult dIpconfig = MessageBox.Show("Czy chcesz wygenerować loga funkcji ipconfig, Który zostanie zapisany w folderze /LOGI lokacji instalacyjnej programu?",
                    "Ipconfig Log Generator", MessageBoxButtons.YesNo);
                if (dIpconfig == DialogResult.Yes)
                {
                    log.GenerujIPConfigLog();
                }
                DialogResult dNetbios = MessageBox.Show("Czy chcesz dołączyć do domeny? Wybierz Tak, aby dołączyć. Nie aby zmienić tylko nazwę NetBIOS. Anuluj aby pominąć.",
                    "Domain&NetBIOS connector", MessageBoxButtons.YesNoCancel);
                if (dNetbios == DialogResult.Yes)
                {
                    zmiana.JoinDomain();
                }
                else if (dNetbios == DialogResult.No)
                {
                    zmiana.ChangeNetBIOS();
                }
                DialogResult dRestart = MessageBox.Show("Czy chcesz uruchomić komputer ponownie, aby zapisać zmiany?", "Restart", MessageBoxButtons.YesNo);
                if (dRestart == DialogResult.Yes)
                {
                    Process.Start("shutdown", "/r /f /t 0");
                }
                else if (dRestart == DialogResult.No)
                {
                    return;
                }
            }
            void przyciskCWIClick(object sender,EventArgs ea)
            {
                instalatorLotus.ShowDialog();
                instalatorOffice.ShowDialog();
                install.InstalacjaCWI();
                cert.InstalujCWI("CWI_CERT.cer");
                DialogResult dialogUser = MessageBox.Show("Czy chcesz utworzyć nowe konto lokalne na komputerze?", "Kreator Konta Użytkownika", MessageBoxButtons.YesNo);
                if (dialogUser == DialogResult.Yes)
                {
                    user.WyswietlUser();
                }
                DialogResult dIpconfig = MessageBox.Show("Czy chcesz wygenerować loga funkcji ipconfig, Który zostanie zapisany w folderze /LOGI lokacji instalacyjnej programu?",
                    "Ipconfig Log Generator", MessageBoxButtons.YesNo);
                if (dIpconfig == DialogResult.Yes)
                {
                    log.GenerujIPConfigLog();
                }
                DialogResult dNetbios = MessageBox.Show("Czy chcesz dołączyć do domeny? Wybierz Tak, aby dołączyć. Nie aby zmienić tylko nazwę NetBIOS. Anuluj aby pominąć.",
                    "Domain&NetBIOS connector", MessageBoxButtons.YesNoCancel);
                if (dNetbios == DialogResult.Yes)
                {
                    zmiana.JoinDomain();
                }
                else if (dNetbios == DialogResult.No)
                {
                    zmiana.ChangeNetBIOS();
                }
                DialogResult dRestart = MessageBox.Show("Czy chcesz uruchomić komputer ponownie, aby zapisać zmiany?", "Restart", MessageBoxButtons.YesNo);
                if (dRestart == DialogResult.Yes)
                {
                    Process.Start("shutdown", "/r /f /t 0");
                }
                else if (dRestart == DialogResult.No)
                {
                    return;
                }
            }
            void PrzyciskZakonczClick(object sender,EventArgs ea)
            {
                Application.Exit();
            }
            void PrzyciskAnulujClick(object sender, EventArgs ea)
            {
                Close();
            }
            //Delegowanie metod do eventu przycisku myszy
            przyciskZakoncz.Click += new EventHandler(PrzyciskZakonczClick);
            przyciskInternet.Click += new EventHandler(PrzyciskInternetClick);
            przyciskPSTD.Click += new EventHandler(przyciskPSTDClick);
            przyciskCWI.Click += new EventHandler(przyciskCWIClick);
            przyciskAnuluj.Click += new EventHandler(PrzyciskAnulujClick);
            przyciskAnulujLotus.Click += new EventHandler(PrzyciskAnulujClick);
            przyciskAnulujEKD.Click += new EventHandler(PrzyciskAnulujClick);
            przyciskOKLotus.Click += new EventHandler(PrzyciskLotusOKClick);
            przyciskOKEKD.Click += new EventHandler(PrzyciskEKDOKClick);
            przyciskOKOffice.Click += new EventHandler(PrzyciskOfficeOKClick);
            //Dopisywanie opcji do głównego menu i list.
            instalatorLotus.Controls.Add(informacjaLotusa);
            instalatorLotus.Controls.Add(listaLotus);
            instalatorLotus.Controls.Add(przyciskOKLotus);
            instalatorLotus.Controls.Add(przyciskAnulujLotus);
            instalatorEKD.Controls.Add(informacjaEKD);
            instalatorEKD.Controls.Add(listaEKD);
            instalatorEKD.Controls.Add(przyciskOKEKD);
            instalatorEKD.Controls.Add(przyciskAnulujEKD);
            instalatorOffice.Controls.Add(informacjaOffice);
            instalatorOffice.Controls.Add(listaOffice);
            instalatorOffice.Controls.Add(przyciskOKEKD);
            instalatorOffice.Controls.Add(przyciskAnuluj);
            Controls.Add(stronaGlowna);
            Controls.Add(przyciskInternet);
            Controls.Add(przyciskPSTD);
            Controls.Add(przyciskCWI);
            Controls.Add(przyciskZakoncz);
        }
    }
}
