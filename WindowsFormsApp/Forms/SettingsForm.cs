using DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class SettingsForm : Form
    {
        // Settings repository

        private readonly SettingsRepo SETTINGS_REPO = SettingsRepo.Instance;



        // Languages

        private const string HR = "hr";
        private const string EN = "en";



        // Constructor

        public SettingsForm()
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
        }



        // Events

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (SETTINGS_REPO.HasAllInfoForWindowsFormsApp())
            {
                var result = MessageBox.Show(DataLayer.Resources.Messages.ConfirmSettingsMessage,
                                DataLayer.Resources.Messages.ConfirmSettingsTitle,
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    return;
                }
            }

            SaveSelectedLanguage();
            SaveSelectedChampionship();
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !SETTINGS_REPO.HasAllInfoForWindowsFormsApp())
            {
                ShowExitAppMessageBox();
            }
        }

        private void DdlLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ddlLanguage.SelectedItem)
            {
                case "English":
                    if (Thread.CurrentThread.CurrentUICulture.Name != EN)
                    {
                        SetLanguage(EN);
                    }
                    break;

                case "Hrvatski":
                    if (Thread.CurrentThread.CurrentUICulture.Name != HR)
                    {
                        SetLanguage(HR);
                    }
                    break;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (!SETTINGS_REPO.HasAllInfoForWindowsFormsApp())
            {
                ShowExitAppMessageBox();
            }
        }



        // Methods

        private void SaveSelectedLanguage()
        {
            switch (ddlLanguage.SelectedItem)
            {
                case "English":
                    SETTINGS_REPO.Language = EN;
                    break;
                case "Hrvatski":
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

        private void SetLanguage(string language)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
            UpdateUI();
        }

        private void UpdateUI()
        {
            Controls.Clear();
            InitializeComponent();

            SetDdlLanguageSelectedItem();
            SetDdlChampionshipSelectedItem();
        }

        private void SetDdlLanguageSelectedItem()
        {
            switch (Thread.CurrentThread.CurrentUICulture.Name)
            {
                case EN:
                    ddlLanguage.SelectedItem = "English";
                    break;
                case HR:
                    ddlLanguage.SelectedItem = "Hrvatski";
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

        private void ShowExitAppMessageBox()
        {
            DialogResult dialogResult = MessageBox.Show(DataLayer.Resources.Messages.ExitApplicationMessage,
                                                  DataLayer.Resources.Messages.ExitApplicationTitle,
                                                   MessageBoxButtons.YesNo,
                                                   MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
