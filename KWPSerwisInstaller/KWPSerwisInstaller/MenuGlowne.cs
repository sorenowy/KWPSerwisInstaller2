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
        private Form userCreationMenu = new Form();
        private Form ipConfigMenu = new Form();
        private Form domainMenu = new Form();
        private Form lotusInstallerMenu = new Form();
        private Form ekdInstallerMenu = new Form();
        private Form officeInstallerMenu = new Form();
        private Form faqMenu = new Form();
        private Label mainLabel = new Label();
        private Label lotusLabel = new Label();
        private Label ekdLabel = new Label();
        private Label officeLabel = new Label();
        private Label inputUsernameLabel = new Label();
        private Label inputPasswordLabel = new Label();
        private Label inputInvNumLabel = new Label();
        private Label inputNetBiosName = new Label();
        private Label faqLabel = new Label();
        private ListBox lotusList = new ListBox();
        private ListBox ekdList = new ListBox();
        private ListBox officeList = new ListBox();
        private TextBox usernameTextbox = new TextBox();
        private TextBox passwordTextbox = new TextBox();
        private TextBox inventoryTextbox = new TextBox();
        private TextBox netbiosNameTextbox = new TextBox();
        private Button buttonClose = new Button();
        private Button buttonInternet = new Button();
        private Button buttonPSTD = new Button();
        private Button buttonCWI = new Button();
        private Button buttonCancel = new Button();
        private Button buttonCancelOffice = new Button();
        private Button buttonCancelEKD = new Button();
        private Button buttonOKLotus = new Button();
        private Button buttonOKEKD = new Button();
        private Button buttonOKOffice = new Button();
        private Button buttonAdmin = new Button();
        private Button buttonUser = new Button();
        private Button buttonIpLog = new Button();
        private Button buttonChangeNetbios = new Button();
        private Button buttonFaq = new Button();
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
            MessageBox.Show("Witaj w programie Instalacyjnym KWP Serwis Installer v0.8\nUpewnij się że komputer " +
            "jest podłączony do sieci oraz posiada skonfigurowany \nSerwisowy adres IP, by zainstalować wymaganie oprogramowanie. " +
            "W przypadku podłączenia komputera do domeny, miej ustawiony dynamiczny adres IP", "Powitanie");
            MessageBox.Show(Program.Copyright(), "Copyright");
            // Nazwa tytułu aplikacji
            this.Text = "KWP Serwis Installer v0.8";
            this.Size = new Size(760, 560);
            // Załadowanie i wyskalowanie obrazka na stronę tytułową
            Image titleImage = Image.FromFile(Environment.CurrentDirectory+@"\Logo\obrazek.jpg");
            mainLabel.Left = 120;
            mainLabel.Size = new Size(600, 400);
            mainLabel.Image = titleImage;
            //Ustawianie opisu etykiet listy
            lotusLabel.Text = "Wybierz oprogramowanie z listy i zatwierdź OK w celu instalacji.";
            lotusLabel.Size = new Size(400, 50);
            lotusLabel.Font = new Font("TimesNewRoman", 14f);
            ekdLabel.Text = lotusLabel.Text;
            ekdLabel.Size = lotusLabel.Size;
            ekdLabel.Font = lotusLabel.Font;
            officeLabel.Text = lotusLabel.Text;
            officeLabel.Size = lotusLabel.Size;
            officeLabel.Font = lotusLabel.Font;
            faqLabel.Text = "Witaj w programie Instalacyjnym KWP Serwis Installer v0.8 \nUpewnij się że komputer jest podłączony do sieci oraz posiada skonfigurowany \nSerwisowy adres IP, by zainstalować wymaganie oprogramowanie.\n" +
                "W przypadku podłączenia komputera do domeny, miej ustawiony dynamiczny adres IP.\nLogi ipconfig -all programu zapisują się w folderze /Logi lokalizacji programu.\n" +
                "Pamiętaj aby zawsze uruchamiać program z konta administratora."+"\n-------------------------------------\nW przypadku błędu czy problemu który nie da się rozwiązać, skontaktuj się z programistą i poinformuj go o problemie -\n@mail - hubert.kuszynski@go.policja.gov.pl \nlub \ntel. res. 11659";
            faqLabel.Size = new Size(600, 400);
            faqLabel.Font = lotusLabel.Font;
            // Ustawianie opisu etykiet menu tworzenia konta, nazwyPC, loga Ipconfig
            inputUsernameLabel.Text = "Nazwa użytkownika";
            inputUsernameLabel.Size = new Size(200, 50);
            inputUsernameLabel.Font = new Font("TimesNewRoman", 10f, FontStyle.Bold);
            inputPasswordLabel.Text = "Hasło użytkownika";
            inputPasswordLabel.Size = inputUsernameLabel.Size;
            inputPasswordLabel.Font = inputUsernameLabel.Font;
            inputPasswordLabel.Top = 50;
            inputInvNumLabel.Text = "Nr inw. komputera";
            inputInvNumLabel.Size = inputUsernameLabel.Size;
            inputInvNumLabel.Font = inputUsernameLabel.Font;
            inputInvNumLabel.Top = 20;
            inputNetBiosName.Text = "Nazwa NetBIOS komputera";
            inputNetBiosName.Size = inputUsernameLabel.Size;
            inputNetBiosName.Font = inputUsernameLabel.Font;
            // Opis przycisku zakończ, ustawienie jego pozycji
            buttonClose.Text = "Zakończ";
            buttonClose.Top = 450;
            buttonClose.Left = 600;
            buttonFaq.Text = "F.A.Q";
            buttonFaq.Top = 450;
            buttonFaq.Left = 200;
            buttonFaq.BackColor = Color.Pink;
            // Opis pozostałych przycisków, ustawienie ich pozycji
            buttonInternet.Text = "Ins. Internet";
            buttonInternet.BackColor = Color.LightBlue;
            buttonInternet.Top = 400;
            buttonInternet.Left = 200;
            buttonPSTD.Text = "Ins. PSTD";
            buttonPSTD.BackColor = Color.Red;
            buttonPSTD.Top = 400;
            buttonPSTD.Left = 400;
            buttonCWI.Text = "Ins. CWI";
            buttonCWI.BackColor = Color.LightGreen;
            buttonCWI.Top = 400;
            buttonCWI.Left = 600;
            buttonCancel.Text = "Anuluj";
            buttonCancel.ForeColor = Color.Red;
            buttonCancel.Top = 600;
            buttonCancel.Left = 300;
            buttonCancelOffice.Text = "Anuluj";
            buttonCancelOffice.Top = 600;
            buttonCancelOffice.Left = 300;
            buttonCancelOffice.ForeColor = buttonCancel.ForeColor;
            buttonCancelEKD.Text = buttonCancel.Text;
            buttonCancelEKD.Top = buttonCancel.Top;
            buttonCancelEKD.Left = buttonCancel.Left;
            buttonCancelEKD.ForeColor = buttonCancel.ForeColor;
            //Ustawienia przycisków zatwierdzeń Lotusa,Office i EKD.
            buttonOKLotus.Text = "OK";
            buttonOKLotus.Top = 600;
            buttonOKLotus.Left = 150;
            //Przypisanie do innych..
            buttonOKEKD.Text = buttonOKLotus.Text;
            buttonOKEKD.Top = buttonOKLotus.Top;
            buttonOKEKD.Left = 200;
            buttonOKOffice.Text = buttonOKLotus.Text;
            buttonOKOffice.Top = buttonOKLotus.Top;
            buttonOKOffice.Left = buttonOKLotus.Left;
            //Ustawienia przycisków zatwierdzeń kont użyt.,domeny,iploga
            buttonAdmin.Text = "Admin";
            buttonAdmin.Top = 100;
            buttonAdmin.Left = 10;
            buttonUser.Text = "User";
            buttonUser.Top = 100;
            buttonUser.Left = 90;
            buttonIpLog.Text = "Utwórz";
            buttonIpLog.Top = 130;
            buttonIpLog.Left = 10;
            buttonChangeNetbios.Text = "Zmień Netbios";
            buttonChangeNetbios.Size = new Size(100, 50);
            buttonChangeNetbios.Top = 100;
            buttonChangeNetbios.Left = 50;
            //Ustawienia okien wyboru z listy
            lotusInstallerMenu.Text = "Wybierz klienta poczty w celu instalacji.";
            lotusInstallerMenu.Size = new Size(580, 700);
            ekdInstallerMenu.Text = "Wybierz klienta EKD w celu instalacji";
            ekdInstallerMenu.Size = lotusInstallerMenu.Size;
            officeInstallerMenu.Text = "Wybierz Oprogramowanie Biurowe w celu instalacji.";
            officeInstallerMenu.Size = lotusInstallerMenu.Size;
            faqMenu.Text = "Menu pomocy";
            faqMenu.Size = new Size(600, 500);
            //Ustawienia okien funkcji generujących
            userCreationMenu.Text = "Wprowadź dane użytkownika i hasło.";
            userCreationMenu.Size = new Size(500, 200);
            ipConfigMenu.Text = "Podaj nazwę loga";
            ipConfigMenu.Size = userCreationMenu.Size;
            domainMenu.Text = "Wprowadź nową nazwę komputera";
            domainMenu.Size = userCreationMenu.Size;
            //Inicjalizacja tablic wyboru instalacji oraz ustawienia rozmiaru i czcionki.
            lotusList.Items.AddRange
                (new object[]
                {
                "1. Lotus Notes Basic 8.5.3",
                "2. Lotus Notes Standard 8.5.3",
                "3. Mozilla Thunderbird"
                }
                );
            lotusList.Size = new Size(560, 340);
            lotusList.Top = 120;
            lotusList.Font = new Font("TimesNewRoman", 20f);
            ekdList.Items.AddRange
                (new object[]
                {
                "1. Encard 32bit 2.1.0",
                "2. Encard 64bit 4.1.6",
                "3. CryptoCard Suite 2.1.1"
                }
                );
            ekdList.Size = lotusList.Size;
            ekdList.Top = lotusList.Top;
            ekdList.Font = lotusList.Font;
            officeList.Items.AddRange
                (new object[]
                {
                    "1. OpenOffice 4.1.6",
                    "2. Microsoft Office 2007 Enterprise (cs)",
                    "3. Microsoft Office 2016 MOLP",
                    "4. Microsoft Office 2019 MOLP (KGP)"
                });
            officeList.Size = ekdList.Size;
            officeList.Top = ekdList.Top;
            officeList.Font = ekdList.Font;
            //Ustawianie wl. pól tekstowych
            usernameTextbox.Size = new Size(90, 40);
            usernameTextbox.Font = new Font("TimesNewRoman", 10f);
            usernameTextbox.Top = 20;
            usernameTextbox.Left = 300;
            passwordTextbox.Top = 50;
            passwordTextbox.Size = usernameTextbox.Size;
            passwordTextbox.Font = usernameTextbox.Font;
            passwordTextbox.Left = usernameTextbox.Left;
            netbiosNameTextbox.Size = usernameTextbox.Size;
            netbiosNameTextbox.Font = usernameTextbox.Font;
            netbiosNameTextbox.Left = usernameTextbox.Left;
            netbiosNameTextbox.Top = 20;
            inventoryTextbox.Size = usernameTextbox.Size;
            inventoryTextbox.Font = usernameTextbox.Font;
            inventoryTextbox.Top = 30;
            inventoryTextbox.Left = 200;
            //Metody wywołujące..
            void ButtonLotusOKClick(object sender, EventArgs ea)
            {
                install.LotusInstaller(lotusList.SelectedIndex);
                lotusInstallerMenu.Close();
            }
            void ButtonEKDOKClick(object sender, EventArgs ea)
            {
                install.EKDAuthInstaller(ekdList.SelectedIndex);
                ekdInstallerMenu.Close();
            }
            void ButtonOfficeOKClick(object sender,EventArgs ea)
            {
                install.OfficeInstaller(officeList.SelectedIndex);
                officeInstallerMenu.Close();
            }
            void ButtonAdminClick(object sender,EventArgs ea)
            {
                user.option = 1;
                user.name = usernameTextbox.Text;
                user.password = passwordTextbox.Text;
                user.ShowUser();
                userCreationMenu.Close();
            }
            void ButtonUserClick(object sender,EventArgs ea)
            {
                user.option = 2;
                user.name = usernameTextbox.Text;
                user.password = passwordTextbox.Text;
                user.ShowUser();
                userCreationMenu.Close();
            }
            void ButtonIpLogClick(object sender,EventArgs ea)
            {
                log.option = 1;
                log.inventoryNumber = inventoryTextbox.Text;
                log.GenerateIPConfigLog();
                ipConfigMenu.Close();
            }
            void ButtonChangeDomainClick(object sender,EventArgs ea)
            {
                zmiana.newNETBiosName = netbiosNameTextbox.Text;
                zmiana.ChangeNetBIOS();
                domainMenu.Close();
            }
            void ButtonInternetClick(object sender, EventArgs ea)
            {
                install.ShitRemover();
                Console.WriteLine("Trwa instalacja oprogramowania dla komputera w sieci Internet.");
                lotusInstallerMenu.ShowDialog();
                officeInstallerMenu.ShowDialog();
                install.InternetInstaller();
                DialogResult dialogUser = MessageBox.Show("Czy chcesz utworzyć nowe konto lokalne na komputerze?","Kreator Konta Użytkownika", MessageBoxButtons.YesNo);
                if (dialogUser == DialogResult.Yes)
                {
                    userCreationMenu.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Wybrałeś opcje nie tworzenia konta.", "Uwaga");
                }
                DialogResult dialogPolicy = MessageBox.Show("Czy chcesz wgrać poliykę bezpieczeństwa na komputerze?", "Polityka Bezpieczeństwa KWP", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Exclamation);
                if(dialogPolicy == DialogResult.Yes)
                {
                    policy.ApplySecurityPolicy();
                }
                else
                {
                    MessageBox.Show("Wybrałeś opcję nie instalowania polityki KWP.", "Uwaga");
                }
                DialogResult dIpconfig = MessageBox.Show("Czy chcesz wygenerować loga funkcji ipconfig, Który zostanie zapisany w folderze /LOGI lokacji instalacyjnej programu?",
                    "Ipconfig Log Generator", MessageBoxButtons.YesNo);
                if (dIpconfig == DialogResult.Yes)
                {
                    ipConfigMenu.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Wybrałeś opcje nie tworzenia loga.", "Uwaga");
                }
                DialogResult dNetbios = MessageBox.Show("Czy chcesz dołączyć do domeny? Wybierz Tak, aby dołączyć. Nie aby zmienić tylko nazwę NetBIOS. Anuluj aby pominąć.", 
                    "Domain&NetBIOS connector", MessageBoxButtons.YesNoCancel);
                if (dNetbios == DialogResult.Yes)
                {
                    domainMenu.ShowDialog();
                    domena.JoinDomain();
                }
                else if (dNetbios == DialogResult.No)
                {
                    domainMenu.ShowDialog();
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
                }
                else if (dRestart == DialogResult.No)
                {
                    Program.Thanks();
                    Close();
                }
            }
            void ButtonPSTDClick(object sender,EventArgs ea)
            {
                install.ShitRemover();
                Console.WriteLine("Trwa instalacja oprogramowania dla komputera w sieci PSTD.");
                lotusInstallerMenu.ShowDialog();
                officeInstallerMenu.ShowDialog();
                install.PSTDInstaller();
                cert.InstallInfrastrukturaCert("infrastruktura2019.der");
                driver.InstallDriver();
                ekdInstallerMenu.ShowDialog();
                DialogResult dialogUser = MessageBox.Show("Czy chcesz utworzyć nowe konto lokalne na komputerze?", "Kreator Konta Użytkownika", MessageBoxButtons.YesNo);
                if (dialogUser == DialogResult.Yes)
                {
                    userCreationMenu.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Wybrałeś opcje nie tworzenia konta.", "Uwaga");
                }
                DialogResult dIpconfig = MessageBox.Show("Czy chcesz wygenerować loga funkcji ipconfig, Który zostanie zapisany w folderze /LOGI lokacji instalacyjnej programu?",
                    "Ipconfig Log Generator", MessageBoxButtons.YesNo);
                if (dIpconfig == DialogResult.Yes)
                {
                    ipConfigMenu.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Wybrałeś opcje nie tworzenia loga.", "Uwaga");
                }
                DialogResult dNetbios = MessageBox.Show("Czy chcesz zmienić nazwę komputera? Wybierz Tak, aby dokonać zmiany. Nie aby zakończyć.",
                    "Domain&NetBIOS connector", MessageBoxButtons.YesNo);
                if (dNetbios == DialogResult.Yes)
                {
                    domainMenu.ShowDialog();
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
                }
                else if (dRestart == DialogResult.No)
                {
                    Program.Thanks();
                    Close();
                }
            }
            void ButtonCWIClick(object sender,EventArgs ea)
            {
                install.ShitRemover();
                lotusInstallerMenu.ShowDialog();
                officeInstallerMenu.ShowDialog();
                install.CWIInstaller();
                cert.InstallCWICert("CWI_CERT.cer");
                DialogResult dialogUser = MessageBox.Show("Czy chcesz utworzyć nowe konto lokalne na komputerze?", "Kreator Konta Użytkownika", MessageBoxButtons.YesNo);
                if (dialogUser == DialogResult.Yes)
                {
                    userCreationMenu.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Wybrałeś opcje nie tworzenia konta.","Uwaga");
                }
                DialogResult dIpconfig = MessageBox.Show("Czy chcesz wygenerować loga funkcji ipconfig, Który zostanie zapisany w folderze /LOGI lokacji instalacyjnej programu?",
                    "Ipconfig Log Generator", MessageBoxButtons.YesNo);
                if (dIpconfig == DialogResult.Yes)
                {
                    ipConfigMenu.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Wybrałeś opcje nie tworzenia konta.","Uwaga");
                }
                DialogResult dNetbios = MessageBox.Show("Czy chcesz zmienić nazwę komputera? Wybierz Tak, aby dokonać zmiany. Nie aby zakończyć.",
                    "Domain&NetBIOS connector", MessageBoxButtons.YesNo);
                if (dNetbios == DialogResult.Yes)
                {
                    domainMenu.ShowDialog();
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
            void ButtonCloseClick(object sender,EventArgs ea)
            {
                Application.Exit();
            }
            void ButtonFAQClick(object sender, EventArgs ea)
            {
                faqMenu.ShowDialog();
            }
            void ButtonCancelClick(object sender, EventArgs ea)
            {
                lotusInstallerMenu.Close();
            }
            void ButtonCancelEKDClick(object sender, EventArgs ea)
            {
                ekdInstallerMenu.Close();
            }
            void ButtonCancelOfficeClick(object sender, EventArgs ea)
            {
                officeInstallerMenu.Close();
            }
            //Delegowanie metod do eventu przycisku myszy
            buttonClose.Click += new EventHandler(ButtonCloseClick);
            buttonFaq.Click += new EventHandler(ButtonFAQClick);
            buttonInternet.Click += new EventHandler(ButtonInternetClick);
            buttonPSTD.Click += new EventHandler(ButtonPSTDClick);
            buttonCWI.Click += new EventHandler(ButtonCWIClick);
            buttonCancel.Click += new EventHandler(ButtonCancelClick);
            buttonCancelEKD.Click += new EventHandler(ButtonCancelEKDClick);
            buttonCancelOffice.Click += new EventHandler(ButtonCancelOfficeClick);
            buttonOKLotus.Click += new EventHandler(ButtonLotusOKClick);
            buttonOKEKD.Click += new EventHandler(ButtonEKDOKClick);
            buttonOKOffice.Click += new EventHandler(ButtonOfficeOKClick);
            buttonAdmin.Click += new EventHandler(ButtonAdminClick);
            buttonUser.Click += new EventHandler(ButtonUserClick);
            buttonIpLog.Click += new EventHandler(ButtonIpLogClick);
            buttonChangeNetbios.Click += new EventHandler(ButtonChangeDomainClick);
            //Dopisywanie opcji do głównego menu i list.
            lotusInstallerMenu.Controls.Add(lotusLabel);
            lotusInstallerMenu.Controls.Add(lotusList);
            lotusInstallerMenu.Controls.Add(buttonOKLotus);
            lotusInstallerMenu.Controls.Add(buttonCancel);
            ekdInstallerMenu.Controls.Add(ekdLabel);
            ekdInstallerMenu.Controls.Add(ekdList);
            ekdInstallerMenu.Controls.Add(buttonOKEKD);
            ekdInstallerMenu.Controls.Add(buttonCancelEKD);
            officeInstallerMenu.Controls.Add(officeLabel);
            officeInstallerMenu.Controls.Add(officeList);
            officeInstallerMenu.Controls.Add(buttonOKOffice);
            officeInstallerMenu.Controls.Add(buttonCancelOffice);
            userCreationMenu.Controls.Add(inputUsernameLabel);
            userCreationMenu.Controls.Add(inputPasswordLabel);
            userCreationMenu.Controls.Add(usernameTextbox);
            userCreationMenu.Controls.Add(passwordTextbox);
            userCreationMenu.Controls.Add(buttonAdmin);
            userCreationMenu.Controls.Add(buttonUser);
            ipConfigMenu.Controls.Add(inputInvNumLabel);
            ipConfigMenu.Controls.Add(inventoryTextbox);
            ipConfigMenu.Controls.Add(buttonIpLog);
            domainMenu.Controls.Add(inputNetBiosName);
            domainMenu.Controls.Add(netbiosNameTextbox);
            domainMenu.Controls.Add(buttonChangeNetbios);
            faqMenu.Controls.Add(faqLabel);
            Controls.Add(mainLabel);
            Controls.Add(buttonInternet);
            Controls.Add(buttonPSTD);
            Controls.Add(buttonCWI);
            Controls.Add(buttonClose);
            Controls.Add(buttonFaq);
        }
    }
}
