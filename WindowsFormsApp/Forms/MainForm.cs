using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp.UserControls;

namespace WindowsFormsApp
{
    public partial class MainForm : Form
    {
        // Settings repository

        private readonly SettingsRepo SETTINGS_REPO = SettingsRepo.Instance;


        // Data repository

        private readonly DataRepo DATA_REPO = DataRepo.Instance;


        // Languages

        private const string HR = "hr";
        private const string EN = "en";


        // Control to print

        private Control controlToPrint;

        private int currentControlToPrintIndex = 0;
        private int numberOfControlsPerPage = 0;
        private int controlToPrintTopLocation = 0;


        // Constructor

        public MainForm()
        {
            SetLanguage(EN);
        }



        // Events

        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (!SETTINGS_REPO.ValidForWindowsFormsApp())
            {
                SettingsForm settingsForm = new SettingsForm();

                do
                {

                } while (settingsForm.ShowDialog() != DialogResult.OK);
            }

            CheckLanguageUpdateForm();

            FillDdlTeamsAsync();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                SETTINGS_REPO.SaveSettings();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, DataLayer.Resources.Messages.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DdlTeams_SelectedIndexChanged(object sender, EventArgs e)
        {
            SETTINGS_REPO.FavoriteTeamCode = (ddlTeams.SelectedItem as TeamDetails).FifaCode.ToUpper();
            FillAllPlayersPanelAsync();
            pnlRankedPlayers.Controls.Clear();
            pnlRankedMatches.Controls.Clear();

            DisableRankOptionsAndPrintButtons();
        }

        private void PlayerUC_MouseDown(object sender, MouseEventArgs e)
        {
            PlayerUC playerUC = sender as PlayerUC;
            IList<PlayerUC> selectedPlayers;

            if (e.Button == MouseButtons.Left)
            {
                playerUC.ToggleBackgroundColor();

                if (playerUC.Parent == pnlAllPlayers)
                {
                    selectedPlayers = GetSelectedPlayers(pnlAllPlayers);
                }
                else
                {
                    selectedPlayers = GetSelectedPlayers(pnlFavoritePlayers);
                }

                selectedPlayers.Add(playerUC);

                foreach (var player in selectedPlayers)
                {
                    player.DoDragDrop(player, DragDropEffects.Move);
                }
            }
        }

        private void AddToFavoritePlayersContextMenuItem_Click(object sender, EventArgs e)
        {
            IList<PlayerUC> selectedPlayers = GetSelectedPlayers(pnlAllPlayers);
            selectedPlayers.ToList().ForEach(playerUC =>
            {
                MovePlayer(playerUC, pnlAllPlayers, pnlFavoritePlayers, true, contextMenuFavoritePlayer);
                SETTINGS_REPO.AddFavoritePlayer(playerUC.Player);
            });
        }

        private void RemoveFromFavoritePlayersContextMenuItem_Click(object sender, EventArgs e)
        {
            IList<PlayerUC> selectedPlayers = GetSelectedPlayers(pnlFavoritePlayers);
            selectedPlayers.ToList().ForEach(playerUC =>
            {
                MovePlayer(playerUC, pnlFavoritePlayers, pnlAllPlayers, false, contextMenuPlayer);
                SETTINGS_REPO.RemoveFavoritePlayer(playerUC.Player);
            });
        }

        private void ContextMenuPlayer_Opening(object sender, CancelEventArgs e)
        {
            var contextMenu = sender as ContextMenuStrip;
            PlayerUC playerUC = contextMenu.SourceControl as PlayerUC;
            playerUC.BackColor = PlayerUC.backgroundColorActive;
        }

        private void PnlAllPlayers_DragDrop(object sender, DragEventArgs e)
        {
            var playerUC = (PlayerUC)e.Data.GetData(typeof(PlayerUC));

            if (playerUC.Parent != pnlAllPlayers)
            {
                MovePlayer(playerUC, pnlFavoritePlayers, pnlAllPlayers, false, contextMenuPlayer);
                SETTINGS_REPO.RemoveFavoritePlayer(playerUC.Player);
            }
        }

        private void PnlFavoritePlayers_DragDrop(object sender, DragEventArgs e)
        {
            var playerUC = (PlayerUC)e.Data.GetData(typeof(PlayerUC));

            if (playerUC.Parent != pnlFavoritePlayers)
            {
                MovePlayer(playerUC, pnlAllPlayers, pnlFavoritePlayers, true, contextMenuFavoritePlayer);
                SETTINGS_REPO.AddFavoritePlayer(playerUC.Player);
            }
        }

        private void PnlPlayers_DragEnter(object sender, DragEventArgs e)
            => e.Effect = DragDropEffects.Move;

        private void TlpPlayerContainer_MouseDown(object sender, MouseEventArgs e)
        {
            var tlpPlayerContainer = sender as TableLayoutPanel;
            var playerUC = tlpPlayerContainer.Parent;
            PlayerUC_MouseDown(playerUC, e);
        }

        private void PlayerInfoControl_MouseDown(object sender, MouseEventArgs e)
        {
            var playerInfoControl = sender as Control;
            var tlpPlayerContainer = playerInfoControl.Parent;
            TlpPlayerContainer_MouseDown(tlpPlayerContainer, e);
        }

        private void DdlRankOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            IDictionary<Player, int> rankedPlayers;
            switch (ddlRankOptions.SelectedIndex)
            {
                case 0:
                    rankedPlayers = DATA_REPO.GetPlayersRankedByTypeOfEvent(DataLayer.Enums.TypeOfEvent.Goal);
                    FillRankedPlayersPanel(rankedPlayers, DataLayer.Enums.TypeOfEvent.Goal);
                    break;
                case 1:
                    rankedPlayers = DATA_REPO.GetPlayersRankedByTypeOfEvent(DataLayer.Enums.TypeOfEvent.YellowCard);
                    FillRankedPlayersPanel(rankedPlayers, DataLayer.Enums.TypeOfEvent.YellowCard);
                    break;
            }
        }

        private void BtnPrintRankedPlayers_Click(object sender, EventArgs e)
        {
            controlToPrint = pnlRankedPlayers;
            StepsToPrint();
            ResetPrintVariables();
        }

        private void BtnPrintRankedMatches_Click(object sender, EventArgs e)
        {
            controlToPrint = pnlRankedMatches;
            StepsToPrint();
            ResetPrintVariables();
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            var x = e.MarginBounds.Left;
            var y = e.MarginBounds.Top;
            var bmp = new Bitmap(e.MarginBounds.Width, e.MarginBounds.Height);

            while (currentControlToPrintIndex < controlToPrint.Controls.Count)
            {
                var control = controlToPrint.Controls[currentControlToPrintIndex];

                control.DrawToBitmap(bmp, new Rectangle
                {
                    X = 0,
                    Y = controlToPrintTopLocation * (control.Height + 10),
                    Width = control.Width,
                    Height = control.Height
                });


                e.Graphics.DrawImage(bmp, x, y);
                currentControlToPrintIndex++;
                controlToPrintTopLocation++;

                if (numberOfControlsPerPage < 5)
                {
                    numberOfControlsPerPage++;
                    e.HasMorePages = false;
                }
                else
                {
                    numberOfControlsPerPage = 0;
                    controlToPrintTopLocation = 0;
                    e.HasMorePages = true;
                    return;
                }
            }
        }

        private void SettingsMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            if (settingsForm.ShowDialog() == DialogResult.OK)
            {
                CheckLanguageUpdateForm();

                FillDdlTeamsAsync();
            }
        }



        // Methods

        private async void FillDdlTeamsAsync()
        {
            try
            {
                ddlTeams.Enabled = false;

                DisableRankOptionsAndPrintButtons();

                tlpLoadingTeamsInfo.Visible = true;

                var teams = await DATA_REPO.GetTeams();

                teams.ToList().ForEach(team =>
                {
                    ddlTeams.Items.Add(team);

                    if (SETTINGS_REPO.FavoriteTeamCode != null)
                    {
                        if (team.FifaCode.ToUpper() == SETTINGS_REPO.FavoriteTeamCode.ToUpper())
                        {
                            ddlTeams.SelectedItem = team;
                        }
                    }
                });

                tlpLoadingTeamsInfo.Visible = false;
                ddlTeams.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, DataLayer.Resources.Messages.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void FillAllPlayersPanelAsync()
        {
            try
            {
                pnlAllPlayers.Controls.Clear();
                pnlFavoritePlayers.Controls.Clear();

                tlpLoadingAllPlayersInfo.Visible = true;
                tlpLoadingFavoritePlayersInfo.Visible = true;
                pnlAllPlayers.Controls.Add(tlpLoadingAllPlayersInfo);
                pnlFavoritePlayers.Controls.Add(tlpLoadingFavoritePlayersInfo);

                var allPlayers = await DATA_REPO.GetPlayers();

                tlpLoadingAllPlayersInfo.Visible = false;
                tlpLoadingFavoritePlayersInfo.Visible = false;

                allPlayers.ToList().ForEach(player =>
                {
                    PlayerUC playerUC = new PlayerUC(player, SETTINGS_REPO.Language);

                    var tlpPlayerContainer = playerUC.Controls.Find("tlpPlayerContainer", true)[0] as TableLayoutPanel;
                    foreach (var control in tlpPlayerContainer.Controls)
                    {
                        if (!(control is Button))
                        {
                            var playerInfoControl = control as Control;
                            playerInfoControl.MouseDown += PlayerInfoControl_MouseDown;
                        }
                    }
                    tlpPlayerContainer.MouseDown += TlpPlayerContainer_MouseDown;

                    playerUC.MouseDown += PlayerUC_MouseDown;

                    if (SETTINGS_REPO.FavoritePlayers != null && SETTINGS_REPO.FavoritePlayers.Contains(player))
                    {
                        playerUC.Favorite = true;
                        playerUC.ContextMenuStrip = contextMenuFavoritePlayer;
                        pnlFavoritePlayers.Controls.Add(playerUC);
                    }
                    else
                    {
                        playerUC.ContextMenuStrip = contextMenuPlayer;
                        pnlAllPlayers.Controls.Add(playerUC);
                    }
                });

                ddlRankOptions.Enabled = true;
                ddlRankOptions.SelectedIndex = 0;

                FillRankedMatchesPanel();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, DataLayer.Resources.Messages.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private IList<PlayerUC> GetSelectedPlayers(FlowLayoutPanel fromPanel)
        {
            IList<PlayerUC> selectedPlayers = new List<PlayerUC>();

            foreach (var playerUC in fromPanel.Controls)
            {
                if (playerUC is PlayerUC)
                {

                    if ((playerUC as PlayerUC).BackColor == PlayerUC.backgroundColorActive)
                    {
                        selectedPlayers.Add((playerUC as PlayerUC));
                    }
                }
            }

            return selectedPlayers;
        }

        private void MovePlayer(PlayerUC playerUC, FlowLayoutPanel fromPanel, FlowLayoutPanel toPanel, bool isFavorite, ContextMenuStrip newContextMenu)
        {
            fromPanel.Controls.Remove(playerUC);

            playerUC.Favorite = isFavorite;
            playerUC.ContextMenuStrip = newContextMenu;
            playerUC.ChangeBackgroudColorToInactive();

            toPanel.Controls.Add(playerUC);
        }

        private async void FillRankedMatchesPanel()
        {
            try
            {
                var matches = await DATA_REPO.GetMatches();

                var sortedMatches = matches.ToList();

                sortedMatches.Sort();

                int i = 1;
                sortedMatches.ToList().ForEach(match =>
                {
                    MatchUC matchUC = new MatchUC(i++, match, SETTINGS_REPO.Language);
                    pnlRankedMatches.Controls.Add(matchUC);
                });

                btnPrintRankedMatches.Enabled = true;
                btnPrintRankedMatches.BackColor = SystemColors.ControlDarkDark;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, DataLayer.Resources.Messages.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillRankedPlayersPanel(IDictionary<Player, int> rankedPlayers, DataLayer.Enums.TypeOfEvent typeOfEvent)
        {
            pnlRankedPlayers.Controls.Clear();

            if (rankedPlayers.Count == 0)
            {
                btnPrintRankedPlayers.BackColor = SystemColors.Control;
                btnPrintRankedPlayers.Enabled = false;

                pnlRankedPlayers.Controls.Add(new Label
                {
                    Text = Resources.Data.NoPlayersAssociatedWithThisEvent,
                    AutoSize = true
                });
                return;
            }

            var sortedPlayers = rankedPlayers.ToList();
            sortedPlayers.Sort((player1, player2) => -player1.Value.CompareTo(player2.Value));

            int i = 1;
            sortedPlayers.ToList().ForEach(player =>
            {
                RankedPlayerUC rankedPlayerUC = new RankedPlayerUC(i++, player, typeOfEvent, SETTINGS_REPO.Language);
                pnlRankedPlayers.Controls.Add(rankedPlayerUC);
            });

            btnPrintRankedPlayers.BackColor = SystemColors.ControlDarkDark;
            btnPrintRankedPlayers.Enabled = true;
        }

        private void StepsToPrint()
        {
            if (pageSetupDialog.ShowDialog() == DialogResult.OK)
            {
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printPreviewDialog.ShowDialog();
                }
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
        }

        private void CheckLanguageUpdateForm()
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

        private void DisableRankOptionsAndPrintButtons()
        {
            ddlRankOptions.SelectedIndex = -1;
            ddlRankOptions.Enabled = false;
            btnPrintRankedPlayers.Enabled = false;
            btnPrintRankedPlayers.BackColor = SystemColors.Control;
            btnPrintRankedMatches.Enabled = false;
            btnPrintRankedMatches.BackColor = SystemColors.Control;
        }

        private void ResetPrintVariables()
        {
            currentControlToPrintIndex = 0;
            numberOfControlsPerPage = 0;
            controlToPrintTopLocation = 0;
        }
    }
}
