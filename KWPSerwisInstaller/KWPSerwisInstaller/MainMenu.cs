using System;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using KWPSerwisInstaller.Configuration;
using KWPSerwisInstaller.Main;
using KWPSerwisInstaller.Logs;
using KWPSerwisInstaller.Policy;

namespace KWPSerwisInstaller
{
    public class MainMenu : Form
    {
        public MainMenu()
        {
            MenuParameters.CreateForms();
            IPConfigLog log = new IPConfigLog();
            ClassCreateUser user = new ClassCreateUser();
            NetBIOSChange zmiana = new NetBIOSChange();
            NetBIOSChange domena = new NetBIOSChange();
            AddCert cert = new AddCert();
            DriverInstaller driver = new DriverInstaller();
            SecurityPolicy policy = new SecurityPolicy();
            Console.Title = "Log KWP Serwis Installer";
            MessageBox.Show("Witaj w programie Instalacyjnym KWP Serwis Installer v0.8\nUpewnij się że komputer " +
            "jest podłączony do sieci oraz posiada skonfigurowany \nSerwisowy adres IP, by zainstalować wymaganie oprogramowanie. " +
            "W przypadku podłączenia komputera do domeny, miej ustawiony dynamiczny adres IP", "Powitanie");
            MessageBox.Show(Program.Copyright(), "Copyright");
            DialogResult connection = MessageBox.Show("Czy chcesz uruchomic program w trybie autonomicznym?", "Uwaga", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (connection == DialogResult.Yes)
            {
                LocalParameters.netconnection = false;
            }
            else
            {
                LocalParameters.netconnection = true;
            }
            Installer install = new Installer(LocalParameters.netconnection);
            // Nazwa tytułu aplikacji
            this.Text = "KWP Serwis Installer v0.8";
            this.Size = new Size(760, 560);
            // Załadowanie i wyskalowanie obrazka na stronę tytułową
            Image titleImage = Image.FromFile(Environment.CurrentDirectory+@"\Logo\obrazek.jpg");
            MenuParameters.mainLabel.Left = 120;
            MenuParameters.mainLabel.Size = new Size(600, 400);
            MenuParameters.mainLabel.Image = titleImage;
            //Metody wywołujące..
            void ButtonLotusOKClick(object sender, EventArgs ea)
            {
                install.LotusInstaller(MenuParameters.lotusList.SelectedIndex);
                MenuParameters.lotusInstallerMenu.Close();
            }
            void ButtonEKDOKClick(object sender, EventArgs ea)
            {
                install.EKDAuthInstaller(MenuParameters.ekdList.SelectedIndex);
                MenuParameters.ekdInstallerMenu.Close();
            }
            void ButtonOfficeOKClick(object sender,EventArgs ea)
            {
                install.OfficeInstaller(MenuParameters.officeList.SelectedIndex);
                MenuParameters.officeInstallerMenu.Close();
            }
            void ButtonAdminClick(object sender,EventArgs ea)
            {
                user.option = 1;
                user.name = MenuParameters.usernameTextbox.Text;
                user.password = MenuParameters.passwordTextbox.Text;
                user.ShowUser();
                MenuParameters.userCreationMenu.Close();
            }
            void ButtonUserClick(object sender,EventArgs ea)
            {
                user.option = 2;
                user.name = MenuParameters.usernameTextbox.Text;
                user.password = MenuParameters.passwordTextbox.Text;
                user.ShowUser();
                MenuParameters.userCreationMenu.Close();
            }
            void ButtonIpLogClick(object sender,EventArgs ea)
            {
                log.option = 1;
                log.inventoryNumber = MenuParameters.inventoryTextbox.Text;
                log.GenerateIPConfigLog();
                MenuParameters.ipConfigMenu.Close();
            }
            void ButtonChangeDomainClick(object sender,EventArgs ea)
            {
                zmiana.newNETBiosName = MenuParameters.netbiosNameTextbox.Text;
                zmiana.ChangeNetBIOS();
                MenuParameters.domainMenu.Close();
            }
            void ButtonInternetClick(object sender, EventArgs ea)
            {
                install.ShitRemover();
                Console.WriteLine("Trwa instalacja oprogramowania dla komputera w sieci Internet.");
                MenuParameters.lotusInstallerMenu.ShowDialog();
                MenuParameters.officeInstallerMenu.ShowDialog();
                install.InternetInstaller();
                DialogResult dialogUser = MessageBox.Show("Czy chcesz utworzyć nowe konto lokalne na komputerze?","Kreator Konta Użytkownika", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (dialogUser == DialogResult.Yes)
                {
                    MenuParameters.userCreationMenu.ShowDialog();
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
                    "Ipconfig Log Generator", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dIpconfig == DialogResult.Yes)
                {
                    MenuParameters.ipConfigMenu.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Wybrałeś opcje nie tworzenia loga.", "Uwaga");
                }
                DialogResult dNetbios = MessageBox.Show("Czy chcesz dołączyć do domeny? Wybierz Tak, aby dołączyć. Nie aby zmienić tylko nazwę NetBIOS. Anuluj aby pominąć.", 
                    "Domain&NetBIOS connector", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dNetbios == DialogResult.Yes)
                {
                    MenuParameters.domainMenu.ShowDialog();
                    domena.JoinDomain();
                }
                else if (dNetbios == DialogResult.No)
                {
                    MenuParameters.domainMenu.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Wybrałeś opcje nie zmieniania nazwy.","Uwaga");
                }
                DialogResult dRestart = MessageBox.Show("Czy chcesz uruchomić komputer ponownie, aby zapisać zmiany?", "Restart", MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation);
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
                MenuParameters.lotusInstallerMenu.ShowDialog();
                MenuParameters.officeInstallerMenu.ShowDialog();
                install.PSTDInstaller();
                cert.InstallInfrastrukturaCert("infrastruktura2019.der");
                driver.InstallDriver();
                MenuParameters.ekdInstallerMenu.ShowDialog();
                DialogResult dialogUser = MessageBox.Show("Czy chcesz utworzyć nowe konto lokalne na komputerze?", "Kreator Konta Użytkownika", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogUser == DialogResult.Yes)
                {
                    MenuParameters.userCreationMenu.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Wybrałeś opcje nie tworzenia konta.", "Uwaga");
                }
                DialogResult dIpconfig = MessageBox.Show("Czy chcesz wygenerować loga funkcji ipconfig, Który zostanie zapisany w folderze /LOGI lokacji instalacyjnej programu?",
                    "Ipconfig Log Generator", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dIpconfig == DialogResult.Yes)
                {
                    MenuParameters.ipConfigMenu.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Wybrałeś opcje nie tworzenia loga.", "Uwaga");
                }
                DialogResult dNetbios = MessageBox.Show("Czy chcesz zmienić nazwę komputera? Wybierz Tak, aby dokonać zmiany. Nie aby zakończyć.",
                    "Domain&NetBIOS connector", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dNetbios == DialogResult.Yes)
                {
                    MenuParameters.domainMenu.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Wybrałeś opcje nie zmieniania nazwy.", "Uwaga");
                }
                DialogResult dRestart = MessageBox.Show("Czy chcesz uruchomić komputer ponownie, aby zapisać zmiany?", "Restart", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
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
                MenuParameters.lotusInstallerMenu.ShowDialog();
                MenuParameters.officeInstallerMenu.ShowDialog();
                install.CWIInstaller();
                cert.InstallCWICert("CWI_CERT.cer");
                DialogResult dialogUser = MessageBox.Show("Czy chcesz utworzyć nowe konto lokalne na komputerze?", "Kreator Konta Użytkownika", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogUser == DialogResult.Yes)
                {
                    MenuParameters.userCreationMenu.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Wybrałeś opcje nie tworzenia konta.","Uwaga");
                }
                DialogResult dIpconfig = MessageBox.Show("Czy chcesz wygenerować loga funkcji ipconfig, Który zostanie zapisany w folderze /LOGI lokacji instalacyjnej programu?",
                    "Ipconfig Log Generator", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dIpconfig == DialogResult.Yes)
                {
                    MenuParameters.ipConfigMenu.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Wybrałeś opcje nie tworzenia konta.","Uwaga");
                }
                DialogResult dNetbios = MessageBox.Show("Czy chcesz zmienić nazwę komputera? Wybierz Tak, aby dokonać zmiany. Nie aby zakończyć.",
                    "Domain&NetBIOS connector", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dNetbios == DialogResult.Yes)
                {
                    MenuParameters.domainMenu.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Wybrałeś opcje nie zmieniania nazwy.","Uwaga");
                }
                DialogResult dRestart = MessageBox.Show("Czy chcesz uruchomić komputer ponownie, aby zapisać zmiany?", "Restart", MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation);
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
                MenuParameters.faqMenu.ShowDialog();
            }
            void ButtonCancelClick(object sender, EventArgs ea)
            {
                MenuParameters.lotusInstallerMenu.Close();
            }
            void ButtonCancelEKDClick(object sender, EventArgs ea)
            {
                MenuParameters.ekdInstallerMenu.Close();
            }
            void ButtonCancelOfficeClick(object sender, EventArgs ea)
            {
                MenuParameters.officeInstallerMenu.Close();
            }
            //Delegowanie metod do eventu przycisku myszy
            MenuParameters.buttonClose.Click += new EventHandler(ButtonCloseClick);
            MenuParameters.buttonFaq.Click += new EventHandler(ButtonFAQClick);
            MenuParameters.buttonInternet.Click += new EventHandler(ButtonInternetClick);
            MenuParameters.buttonPSTD.Click += new EventHandler(ButtonPSTDClick);
            MenuParameters.buttonCWI.Click += new EventHandler(ButtonCWIClick);
            MenuParameters.buttonCancel.Click += new EventHandler(ButtonCancelClick);
            MenuParameters.buttonCancelEKD.Click += new EventHandler(ButtonCancelEKDClick);
            MenuParameters.buttonCancelOffice.Click += new EventHandler(ButtonCancelOfficeClick);
            MenuParameters.buttonOKLotus.Click += new EventHandler(ButtonLotusOKClick);
            MenuParameters.buttonOKEKD.Click += new EventHandler(ButtonEKDOKClick);
            MenuParameters.buttonOKOffice.Click += new EventHandler(ButtonOfficeOKClick);
            MenuParameters.buttonAdmin.Click += new EventHandler(ButtonAdminClick);
            MenuParameters.buttonUser.Click += new EventHandler(ButtonUserClick);
            MenuParameters.buttonIpLog.Click += new EventHandler(ButtonIpLogClick);
            MenuParameters.buttonChangeNetbios.Click += new EventHandler(ButtonChangeDomainClick);
            // Dopisanie elementów statycznych do forms
            Controls.Add(MenuParameters.mainLabel);
            Controls.Add(MenuParameters.buttonInternet);
            Controls.Add(MenuParameters.buttonPSTD);
            Controls.Add(MenuParameters.buttonCWI);
            Controls.Add(MenuParameters.buttonClose);
            Controls.Add(MenuParameters.buttonFaq);
        }
    }
}
