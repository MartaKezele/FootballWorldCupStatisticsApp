using DataLayer;
using DataLayer.Enums;
using DataLayer.Models;
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

namespace WindowsFormsApp.UserControls
{
    public partial class RankedPlayerUC : UserControl
    {
        // Settings repository

        private readonly SettingsRepo SETTINGS_REPO = SettingsRepo.Instance;


        // Background color constants

        public static readonly Color captainBackgroundColorInactive = Color.BurlyWood;


        // Properties

        public Player Player
        {
            get
                => new Player
                {
                    Name = lblNamePlaceholder.Text,
                    Captain = lblCaptainPlaceholder.Text == Resources.Data.Yes,
                    ShirtNumber = long.Parse(lblShirtNumberPlaceholder.Text),
                    Position = PlayerPosition.GetPositionFromString(lblPositionPlaceholder.Text)
                };
            set
            {
                // Name
                lblNamePlaceholder.Text = value.Name;

                // Captain
                if (value.Captain)
                {
                    lblCaptainPlaceholder.Text = Resources.Data.Yes;
                    lblCaptainPlaceholder.Font = new Font(lblCaptainPlaceholder.Font, FontStyle.Bold);
                    BackColor = captainBackgroundColorInactive;
                }
                else
                {
                    lblCaptainPlaceholder.Text = Resources.Data.No;
                }

                // Shirt number
                lblShirtNumberPlaceholder.Text = value.ShirtNumber.ToString();

                // Position
                lblPositionPlaceholder.Text = value.Position.ToString();
            }
        }

        public int Number
        {
            get => int.Parse(lblNumberPlaceholder.Text);
            set
            {
                lblNumberPlaceholder.Text = value.ToString();
            }
        }


        // Constructor

        public RankedPlayerUC(int rankNumber, KeyValuePair<Player, int> player, TypeOfEvent typeOfEvent, string language)
        {
            SetLanguage(language);
            Player = player.Key;
            Number = player.Value;

            lblRankPlaceholder.Text = $"{rankNumber}.";

            switch (typeOfEvent)
            {
                case TypeOfEvent.Goal:
                    lblNumber.Text = Resources.Data.NumberOfGoals;
                    break;
                case TypeOfEvent.YellowCard:
                    lblNumber.Text = Resources.Data.NumberOfYellowCards;
                    break;
            }

            if (SETTINGS_REPO.PlayerPictures.Count() > 0 && SETTINGS_REPO.PlayerPictures.ContainsKey(player.Key))
            {
                foreach (var item in SETTINGS_REPO.PlayerPictures)
                {
                    if (item.Key == player.Key)
                    {
                        try
                        {
                            pbPlayerPicture.ImageLocation = item.Value;
                            pbPlayerPicture.BackColor = Color.Transparent;
                            pbPlayerPicture.BorderStyle = BorderStyle.None;
                        }
                        catch (Exception)
                        {

                        }

                        break;
                    }
                }
            }
        }



        // Events

        private void BtnChangePicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Pictures|*.bmp;*.jpg;*.jpeg;*.png;|All files|*.*"
            };

            //ofd.SafeFileName - file name and extension
            //ofd.FileName - absolute file path

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pbPlayerPicture.ImageLocation = ofd.FileName;
                pbPlayerPicture.BackColor = Color.Transparent;
                pbPlayerPicture.BorderStyle = BorderStyle.None;
                SETTINGS_REPO.AddPlayerPicturePath(Player, ofd.FileName);
            }
        }



        // Methods

        private void SetLanguage(string language)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
            UpdateUI();
        }

        private void UpdateUI()
        {
            Controls.Clear();
            InitializeComponent();
        }
    }
}