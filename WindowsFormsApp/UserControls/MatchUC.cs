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
    public partial class MatchUC : UserControl
    {
        // Properties

        private readonly Match match;
        public Match Match
        {
            get => match;
            private set
            {
                // Venue
                lblVenuePlaceholder.Text = match.Venue;

                // Home team
                lblHomeTeamPlaceholder.Text = match.HomeTeam.Country;

                // Away team
                lblAwayTeamPlaceholder.Text = match.AwayTeam.Country;

                // Attendance
                lblAttendancePlaceholder.Text = match.Attendance.ToString();
            }
        }


        // Constructor

        public MatchUC(int number, Match m, string language)
        {
            SetLanguage(language);

            lblNumberPlaceholder.Text = $"{number}.";

            match = m;
            Match = match;
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
