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
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for PlayerDetailsWindow.xaml
    /// </summary>
    public partial class PlayerDetailsWindow : Window
    {
        // Settings repository

        private readonly SettingsRepo SETTINGS_REPO = SettingsRepo.Instance;


        public PlayerDetailsWindow(Player player, int numberOfGoals, int numberOfYellowCards)
        {
            InitializeComponent();

            lblPlayerName.Content = player.Name;
            lblShirtNumber.Content = player.ShirtNumber;
            lblCaptain.Content = player.Captain ? "yes" : "no";
            lblPosition.Content = player.Position;
            lblNumberOfGoals.Content = numberOfGoals;
            lblNumberOfYellowCards.Content = numberOfYellowCards;

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

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
