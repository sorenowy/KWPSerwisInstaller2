using System.Windows.Forms;
using System.Drawing;

namespace KWPSerwisInstaller.Configuration
{
    internal class MenuParameters : Form
    {
        internal static Form userCreationMenu = new Form();
        internal static Form ipConfigMenu = new Form();
        internal static Form domainMenu = new Form();
        internal static Form lotusInstallerMenu = new Form();
        internal static Form ekdInstallerMenu = new Form();
        internal static Form officeInstallerMenu = new Form();
        internal static Form faqMenu = new Form();
        internal static Label mainLabel = new Label();
        internal static Label lotusLabel = new Label();
        internal static Label ekdLabel = new Label();
        internal static Label officeLabel = new Label();
        internal static Label inputUsernameLabel = new Label();
        internal static Label inputPasswordLabel = new Label();
        internal static Label inputInvNumLabel = new Label();
        internal static Label inputNetBiosName = new Label();
        internal static Label faqLabel = new Label();
        internal static ListBox lotusList = new ListBox();
        internal static ListBox ekdList = new ListBox();
        internal static ListBox officeList = new ListBox();
        internal static TextBox usernameTextbox = new TextBox();
        internal static TextBox passwordTextbox = new TextBox();
        internal static TextBox inventoryTextbox = new TextBox();
        internal static TextBox netbiosNameTextbox = new TextBox();
        internal static Button buttonClose = new Button();
        internal static Button buttonInternet = new Button();
        internal static Button buttonPSTD = new Button();
        internal static Button buttonCWI = new Button();
        internal static Button buttonCancel = new Button();
        internal static Button buttonCancelOffice = new Button();
        internal static Button buttonCancelEKD = new Button();
        internal static Button buttonOKLotus = new Button();
        internal static Button buttonOKEKD = new Button();
        internal static Button buttonOKOffice = new Button();
        internal static Button buttonAdmin = new Button();
        internal static Button buttonUser = new Button();
        internal static Button buttonIpLog = new Button();
        internal static Button buttonChangeNetbios = new Button();
        internal static Button buttonFaq = new Button();

        internal static void CreateForms()
        {
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
                "Pamiętaj aby zawsze uruchamiać program z konta administratora." + "\n-------------------------------------\nW przypadku błędu czy problemu który nie da się rozwiązać, skontaktuj się z programistą i poinformuj go o problemie -\n@mail - hubert.kuszynski@go.policja.gov.pl \nlub \ntel. res. 11659";
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
                    "4. Microsoft Office 2019 MOLP (KGP)" // Brak dodania z racji tego że instalator nie jest lokalny, tylko odwołujący się do sciezki sieciowej :)
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
        }
    }
}
