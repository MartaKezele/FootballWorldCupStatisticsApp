using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp.UserControls
{
    /// <summary>
    /// Interaction logic for PlayerUC.xaml
    /// </summary>
    public partial class PlayerUC : UserControl
    {
        // Settings repository

        private readonly SettingsRepo SETTINGS_REPO = SettingsRepo.Instance;

        private Brush BackgroundColor { get; set; }
        public Player Player { get; set; }

        public PlayerUC(Player player, Brush backgroundColor)
        {
            InitializeComponent();

            Player = player;
            BackgroundColor = backgroundColor;


            playerControlGrid.Background = backgroundColor;

            txtName.Text = player.Name;
            txtShirtNumber.Text = player.ShirtNumber.ToString();

            MouseEnter += PlayerUC_MouseEnter;
            MouseLeave += PlayerUC_MouseLeave;

            if (SETTINGS_REPO.PlayerPictures.Count() > 0 && SETTINGS_REPO.PlayerPictures.ContainsKey(player))
            {
                foreach (var item in SETTINGS_REPO.PlayerPictures)
                {
                    if (item.Key == player)
                    {
                        try
                        {
                            var imagePath = item.Value;
                            if (File.Exists(imagePath))
                            {
                                BitmapImage bmImage = new BitmapImage();
                                bmImage.BeginInit();
                                bmImage.UriSource = new Uri(imagePath, UriKind.Absolute);
                                bmImage.EndInit();
                                imgPlayer.Source = bmImage;
                            }

                        }
                        catch (Exception)
                        {

                        }

                        break;
                    }
                }
            }
        }

        private void PlayerUC_MouseLeave(object sender, MouseEventArgs e)
        {
            playerControlGrid.Background = BackgroundColor;
        }

        private void PlayerUC_MouseEnter(object sender, MouseEventArgs e)
        {
            playerControlGrid.Background = Brushes.Black;
        }
    }
}
