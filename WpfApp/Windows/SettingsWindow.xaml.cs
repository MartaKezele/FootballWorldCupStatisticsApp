using DataLayer;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        // Settings repository

        private readonly SettingsRepo SETTINGS_REPO = SettingsRepo.Instance;


        // Languages

        private const string HR = "hr";
        private const string EN = "en";


        // Main window size options

        private readonly Size small = new Size(800, 600);
        private readonly Size medium = new Size(1200, 800);
        private readonly Size big = new Size(1400, 900);


        // Constructor

        public SettingsWindow()
        {
            switch (SETTINGS_REPO.Language)
            {
                case HR:
                    SetLanguage(HR);
                    break;
                default:
                    SetLanguage(EN);
                    break;
            }

            InitializeComponent();

            SetDdlLanguageSelectedItem();
            SetDdlChampionshipSelectedItem();
            SetDdlMainWindowSizeSelectedItem();
        }



        // Events

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            if (SETTINGS_REPO.HasAllInfoForWpfApp())
            {
                var result = MessageBox.Show($"{DataLayer.Resources.Messages.ConfirmSettingsMessage}",
                                $"{DataLayer.Resources.Messages.ConfirmSettingsTitle}",
                                MessageBoxButton.YesNo,
                                MessageBoxImage.Question);

                if (result == MessageBoxResult.No)
                {
                    return;
                }
            }

            SaveSelectedLanguage();
            SaveSelectedChampionship();
            SaveSelectedMainWindowSize();
            DialogResult = true;
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!SETTINGS_REPO.HasAllInfoForWpfApp())
            {
                var result = MessageBox.Show($"{DataLayer.Resources.Messages.ExitApplicationMessage}",
                    $"{DataLayer.Resources.Messages.ExitApplicationTitle}",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (result == MessageBoxResult.No)
                {

                    e.Cancel = true;
                }
                else
                {
                    Application.Current.Shutdown();
                }
            }
        }



        // Methods

        private void SaveSelectedLanguage()
        {
            switch (ddlLanguage.SelectedIndex)
            {
                case 0:
                    SETTINGS_REPO.Language = EN;
                    break;
                case 1:
                    SETTINGS_REPO.Language = HR;
                    break;
            }
        }

        private void SaveSelectedChampionship()
        {
            switch (ddlChampionship.SelectedIndex)
            {
                case 0:
                    SETTINGS_REPO.Championship = "male";
                    break;
                case 1:
                    SETTINGS_REPO.Championship = "female";
                    break;
            }
        }

        private void SaveSelectedMainWindowSize()
        {
            switch (ddlMainWindowSize.SelectedIndex)
            {
                case 0:
                    SETTINGS_REPO.MainWindowWidth = -1;
                    SETTINGS_REPO.MainWindowHeight = -1;
                    break;
                case 1:
                    SETTINGS_REPO.MainWindowWidth = small.Width;
                    SETTINGS_REPO.MainWindowHeight = small.Height;
                    break;
                case 2:
                    SETTINGS_REPO.MainWindowWidth = medium.Width;
                    SETTINGS_REPO.MainWindowHeight = medium.Height;
                    break;
                case 3:
                    SETTINGS_REPO.MainWindowWidth = big.Width;
                    SETTINGS_REPO.MainWindowHeight = big.Height;
                    break;
            }
        }

        private void SetDdlLanguageSelectedItem()
        {
            switch (Thread.CurrentThread.CurrentUICulture.Name)
            {
                case EN:
                    ddlLanguage.SelectedIndex = 0;
                    break;
                case HR:
                    ddlLanguage.SelectedIndex = 1;
                    break;
            }
        }

        private void SetDdlChampionshipSelectedItem()
        {
            switch (SETTINGS_REPO.Championship)
            {
                case "female":
                    ddlChampionship.SelectedIndex = 1;
                    break;
                default:
                    ddlChampionship.SelectedIndex = 0;
                    break;
            }
        }

        private void SetDdlMainWindowSizeSelectedItem()
        {
            if (SETTINGS_REPO.MainWindowWidth > 0 && SETTINGS_REPO.MainWindowHeight > 0)
            {
                Size mainWindowSize = new Size(SETTINGS_REPO.MainWindowWidth, SETTINGS_REPO.MainWindowHeight);
                if (mainWindowSize == small)
                {
                    ddlMainWindowSize.SelectedIndex = 1;
                }
                else if (mainWindowSize == medium)
                {
                    ddlMainWindowSize.SelectedIndex = 2;
                }
                else if (mainWindowSize == big)
                {
                    ddlMainWindowSize.SelectedIndex = 3;
                }
                else
                {
                    ddlMainWindowSize.SelectedIndex = 0;
                }
            }
            else
            {
                ddlMainWindowSize.SelectedIndex = 0;
            }
        }

        private void SetLanguage(string language)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
        }
    }
}
