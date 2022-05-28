using DataLayer;
using DataLayer.Enums;
using DataLayer.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp.UserControls;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Settings repository

        private readonly SettingsRepo SETTINGS_REPO = SettingsRepo.Instance;


        // Data repository

        private readonly DataRepo DATA_REPO = DataRepo.Instance;


        // Languages

        private const string HR = "hr";
        private const string EN = "en";


        // Matches

        private IList<Match> matches = new List<Match>();


        // Constructor

        public MainWindow()
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
        }



        // Events

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (!SETTINGS_REPO.ValidForWpfApp())
            {
                SettingsWindow settingsWindow = new SettingsWindow();
                settingsWindow.ShowDialog();
            }
            CheckSettingsUpdateWindow();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (SETTINGS_REPO.HasAllInfoForWpfApp())
            {
                var result = MessageBox.Show($"{DataLayer.Resources.Messages.ExitApplicationMessage}",
                                $"{DataLayer.Resources.Messages.ExitApplicationTitle}",
                                MessageBoxButton.YesNo,
                                MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        SETTINGS_REPO.SaveSettings();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, DataLayer.Resources.Messages.Error, MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    e.Cancel = true;
                }
            }

        }

        private void SettingsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow settingsWindow = new SettingsWindow();

            if (settingsWindow.ShowDialog() == true)
            {
                CheckSettingsUpdateWindow();
            }
        }

        private void DdlTeams_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SETTINGS_REPO.FavoriteTeamCode = (ddlTeams.SelectedItem as TeamDetails).FifaCode.ToUpper();
            FillDdlOpposingTeams();
        }

        private void DdlOpposingTeams_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SETTINGS_REPO.OpposingTeamCode = (ddlOpposingTeams.SelectedItem as Team).Code.ToUpper();
            ShowTeamDetailButtons();
            FillDdlMatches();
        }

        private void DdlMatches_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Match match = ddlMatches.SelectedItem as Match;
            ShowGameResult(match);
            FillFieldWithPlayers(match);
        }

        private void BtnFavoriteTeamDetails_Click(object sender, RoutedEventArgs e)
        {
            TeamDetailsWindow teamDetailsWindow = new TeamDetailsWindow(ddlTeams.SelectedItem as TeamDetails);

            var location = btnFavoriteTeamDetails.PointToScreen(new Point(0, 0));
            teamDetailsWindow.Left = location.X;
            teamDetailsWindow.Top = location.Y + 40;

            teamDetailsWindow.Show();
        }

        private void BtnOpposingTeamDetails_Click(object sender, RoutedEventArgs e)
        {
            Team opposingTeam = ddlOpposingTeams.SelectedItem as Team;
            foreach (var item in ddlTeams.Items)
            {
                if (item is TeamDetails)
                {
                    if (opposingTeam.Code == (item as TeamDetails).FifaCode)
                    {
                        TeamDetailsWindow teamDetailsWindow = new TeamDetailsWindow(item as TeamDetails);

                        var location = btnOpposingTeamDetails.PointToScreen(new Point(0, 0));
                        teamDetailsWindow.Left = location.X;
                        teamDetailsWindow.Top = location.Y + 40;

                        teamDetailsWindow.Show();
                        return;
                    }
                }
            }
        }

        private void FavoriteTeamPlayerUC_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Match match = ddlMatches.SelectedItem as Match;
            TeamDetails teamDetails = ddlTeams.SelectedItem as TeamDetails;
            Team team = new Team
            {
                Code = teamDetails.FifaCode,
                Country = teamDetails.Country
            };
            Player player = (sender as PlayerUC).Player;

            int numberOfGoals = DATA_REPO.GetNumberOfEventsForPlayerInMatch(match, team, player, TypeOfEvent.Goal);
            int numberOfYellowCards = DATA_REPO.GetNumberOfEventsForPlayerInMatch(match, team, player, TypeOfEvent.YellowCard);

            PlayerDetailsWindow playerDetailsWindow = new PlayerDetailsWindow(player, numberOfGoals, numberOfYellowCards);

            var location = lblResultDash.PointToScreen(new Point(0, 0));
            playerDetailsWindow.Left = location.X - playerDetailsWindow.Width / 2;
            playerDetailsWindow.Top = location.Y;

            playerDetailsWindow.Show();
        }

        private void OpposingTeamPlayerUC_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Match match = ddlMatches.SelectedItem as Match;
                Team team = ddlOpposingTeams.SelectedItem as Team;
                Player player = (sender as PlayerUC).Player;

                int numberOfGoals = DATA_REPO.GetNumberOfEventsForPlayerInMatch(match, team, player, TypeOfEvent.Goal);
                int numberOfYellowCards = DATA_REPO.GetNumberOfEventsForPlayerInMatch(match, team, player, TypeOfEvent.YellowCard);

                PlayerDetailsWindow playerDetailsWindow = new PlayerDetailsWindow(player, numberOfGoals, numberOfYellowCards);

                var location = lblResultDash.PointToScreen(new Point(0, 0));
                playerDetailsWindow.Left = location.X - playerDetailsWindow.Width / 2;
                playerDetailsWindow.Top = location.Y;

                playerDetailsWindow.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, DataLayer.Resources.Messages.Error, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        // Methods

        private void CheckSettingsUpdateWindow()
        {
            if (SETTINGS_REPO.MainWindowWidth != -1 && SETTINGS_REPO.MainWindowHeight != -1)
            {
                WindowState = WindowState.Normal;
                Width = SETTINGS_REPO.MainWindowWidth;
                Height = SETTINGS_REPO.MainWindowHeight;
            }
            else
            {
                WindowState = WindowState.Maximized;
            }

            CenterWindowOnScreen();
            FillDdlTeamsAsync();
        }

        private async void FillDdlTeamsAsync()
        {
            try
            {
                try
                {
                    ddlTeams.Items.Clear();
                }
                catch (Exception)
                {

                }

                lblLoadingMessage.Visibility = Visibility.Visible;
                lblLoadingMessage.Content = "Loading teams...";

                var teams = await DATA_REPO.GetTeams();

                bool favoriteTeamFound = false;

                for (int i = 0; i < teams.Count(); i++)
                {
                    ddlTeams.Items.Add(teams[i]);

                    if (SETTINGS_REPO.FavoriteTeamCode != null)
                    {
                        if (teams[i].FifaCode.ToUpper() == SETTINGS_REPO.FavoriteTeamCode.ToUpper())
                        {
                            ddlTeams.SelectedIndex = i;
                            favoriteTeamFound = true;
                        }
                    }
                }

                if (!favoriteTeamFound)
                {
                    ddlTeams.SelectedIndex = 0;
                }

                lblLoadingMessage.Visibility = Visibility.Hidden;
                ddlTeams.IsEnabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, DataLayer.Resources.Messages.Error, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void FillDdlOpposingTeams()
        {
            try
            {
                try
                {
                    ddlOpposingTeams.Items.Clear();
                }
                catch (Exception)
                {

                }


                lblLoadingMessage.Visibility = Visibility.Visible;
                lblLoadingMessage.Content = "Loading opposing teams";

                matches = await DATA_REPO.GetMatches();
                IList<Team> opposingTeams = new List<Team>();

                matches.ToList().ForEach(match =>
                {
                    if (match.AwayTeam.Code.ToUpper() != SETTINGS_REPO.FavoriteTeamCode.ToUpper())
                    {
                        if (!opposingTeams.Contains(match.AwayTeam))
                        {
                            opposingTeams.Add(match.AwayTeam);
                        }
                    }
                    else if (match.HomeTeam.Code.ToUpper() != SETTINGS_REPO.FavoriteTeamCode.ToUpper())
                    {
                        if (!opposingTeams.Contains(match.HomeTeam))
                        {
                            opposingTeams.Add(match.HomeTeam);
                        }
                    }
                });

                bool opposingTeamFound = false;

                for (int i = 0; i < opposingTeams.Count(); i++)
                {
                    ddlOpposingTeams.Items.Add(opposingTeams[i]);

                    if (SETTINGS_REPO.OpposingTeamCode != null)
                    {
                        if (opposingTeams[i].Code.ToUpper() == SETTINGS_REPO.OpposingTeamCode.ToUpper())
                        {
                            ddlOpposingTeams.SelectedItem = opposingTeams[i];
                            opposingTeamFound = true;
                        }
                    }
                }

                if (!opposingTeamFound)
                {
                    ddlOpposingTeams.SelectedIndex = 0;
                }

                lblLoadingMessage.Visibility = Visibility.Hidden;
                ddlOpposingTeams.IsEnabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, DataLayer.Resources.Messages.Error, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void FillDdlMatches()
        {
            try
            {
                ddlMatches.Items.Clear();
                ddlMatches.IsEnabled = false;
            }
            catch (Exception)
            {

            }

            foreach (var match in matches)
            {
                if (match.HomeTeam == ddlOpposingTeams.SelectedItem || match.AwayTeam == ddlOpposingTeams.SelectedItem)
                {
                    ddlMatches.Items.Add(match);
                }
            }

            ddlMatches.SelectedIndex = 0;

            ddlMatches.IsEnabled = true;
        }

        private void ShowGameResult(Match match)
        {
            if (match.HomeTeam == ddlTeams.SelectedItem)
            {
                lblFavoriteTeamGoals.Content = match.HomeTeam.Goals;
                lblOpposingTeamGoals.Content = match.AwayTeam.Goals;
            }
            else
            {
                lblFavoriteTeamGoals.Content = match.AwayTeam.Goals;
                lblOpposingTeamGoals.Content = match.HomeTeam.Goals;
            }

            lblFavoriteTeamGoals.Visibility = Visibility.Visible;
            lblOpposingTeamGoals.Visibility = Visibility.Visible;
            lblResultDash.Visibility = Visibility.Visible;
        }

        private void ShowTeamDetailButtons()
        {
            btnFavoriteTeamDetails.IsEnabled = true;
            btnOpposingTeamDetails.IsEnabled = true;
        }

        private void CenterWindowOnScreen()
        {
            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
        }

        private void FillFieldWithPlayers(Match match)
        {
            TeamStatistics favoriteTeamStatistics;
            TeamStatistics opposingTeamStatistics;

            if (match.HomeTeam == (ddlOpposingTeams.SelectedItem as Team))
            {
                opposingTeamStatistics = match.HomeTeamStatistics;
                favoriteTeamStatistics = match.AwayTeamStatistics;
            }
            else
            {
                opposingTeamStatistics = match.AwayTeamStatistics;
                favoriteTeamStatistics = match.HomeTeamStatistics;
            }

            FillFieldWithFavoriteTeamPlayers(favoriteTeamStatistics);
            FillFieldWithOpposingTeamPlayers(opposingTeamStatistics);
        }

        private void FillFieldWithFavoriteTeamPlayers(TeamStatistics teamStatistics)
        {
            favoriteTeamGoalie.Children.Clear();
            favoriteTeamDefenders.Children.Clear();
            favoriteTeamMidfields.Children.Clear();
            favoriteTeamForwards.Children.Clear();

            foreach (var player in teamStatistics.StartingEleven)
            {
                PlayerUC playerUC = new PlayerUC(player, Brushes.DarkBlue)
                {
                    Margin = new Thickness(10, 5, 10, 5)
                };

                playerUC.MouseDown += FavoriteTeamPlayerUC_MouseDown;

                if (player.Position == PlayerPosition.Position.Goalie)
                {
                    favoriteTeamGoalie.Children.Add(playerUC);
                }
                else if (player.Position == PlayerPosition.Position.Defender)
                {

                    favoriteTeamDefenders.Children.Add(playerUC);
                }
                else if (player.Position == PlayerPosition.Position.Midfield)
                {
                    favoriteTeamMidfields.Children.Add(playerUC);
                }
                else if (player.Position == PlayerPosition.Position.Forward)
                {
                    favoriteTeamForwards.Children.Add(playerUC);
                }
            }
        }

        private void FillFieldWithOpposingTeamPlayers(TeamStatistics teamStatistics)
        {
            opposingTeamGoalie.Children.Clear();
            opposingTeamDefenders.Children.Clear();
            opposingTeamMidfields.Children.Clear();
            opposingTeamForwards.Children.Clear();

            foreach (var player in teamStatistics.StartingEleven)
            {
                PlayerUC playerUC = new PlayerUC(player, Brushes.DarkRed)
                {
                    Margin = new Thickness(10, 5, 10, 5)
                };

                playerUC.MouseDown += OpposingTeamPlayerUC_MouseDown;

                if (player.Position == PlayerPosition.Position.Goalie)
                {
                    opposingTeamGoalie.Children.Add(playerUC);
                }
                else if (player.Position == PlayerPosition.Position.Defender)
                {
                    opposingTeamDefenders.Children.Add(playerUC);
                }
                else if (player.Position == PlayerPosition.Position.Midfield)
                {
                    opposingTeamMidfields.Children.Add(playerUC);
                }
                else if (player.Position == PlayerPosition.Position.Forward)
                {
                    opposingTeamForwards.Children.Add(playerUC);
                }
            }
        }

        private void SetLanguage(string language)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
        }
    }
}
