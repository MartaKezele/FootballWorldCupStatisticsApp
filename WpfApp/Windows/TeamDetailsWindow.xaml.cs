using DataLayer.Models;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for TeamDetailsWindow.xaml
    /// </summary>
    public partial class TeamDetailsWindow : Window
    {
        public TeamDetailsWindow(TeamDetails teamDetails)
        {
            InitializeComponent();

            lblTeamCountry.Content = teamDetails.Country;
            lblTeamCode.Content = teamDetails.FifaCode;

            lblGamesPlayed.Content = teamDetails.GamesPlayed;
            lblWins.Content = teamDetails.Wins;
            lblDraws.Content = teamDetails.Draws;
            lblLosses.Content = teamDetails.Losses;

            lblGoalsFor.Content = teamDetails.GoalsFor;
            lblGoalsAgainst.Content = teamDetails.GoalsAgainst;
            lblGoalsDifferential.Content = teamDetails.GoalDifferential;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
