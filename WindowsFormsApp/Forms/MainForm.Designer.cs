
namespace WindowsFormsApp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.settingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblAllPlayers = new System.Windows.Forms.Label();
            this.lblFavoritePlayers = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblPlayersRanked = new System.Windows.Forms.Label();
            this.ddlRankOptions = new System.Windows.Forms.ComboBox();
            this.lblMatchesRanked = new System.Windows.Forms.Label();
            this.pnlAllPlayers = new System.Windows.Forms.FlowLayoutPanel();
            this.tlpLoadingAllPlayersInfo = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblLoadingAllPlayers = new System.Windows.Forms.Label();
            this.pnlFavoritePlayers = new System.Windows.Forms.FlowLayoutPanel();
            this.tlpLoadingFavoritePlayersInfo = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lblLoadingFavoritePlayers = new System.Windows.Forms.Label();
            this.pnlRankedPlayers = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlRankedMatches = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPrintRankedPlayers = new System.Windows.Forms.Button();
            this.btnPrintRankedMatches = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblFavoriteTeam = new System.Windows.Forms.Label();
            this.ddlTeams = new System.Windows.Forms.ComboBox();
            this.tlpLoadingTeamsInfo = new System.Windows.Forms.TableLayoutPanel();
            this.lblLoadingTeams = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuPlayer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToFavoritePlayersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuFavoritePlayer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeFromFavoritePlayersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.pageSetupDialog = new System.Windows.Forms.PageSetupDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.pnlAllPlayers.SuspendLayout();
            this.tlpLoadingAllPlayersInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pnlFavoritePlayers.SuspendLayout();
            this.tlpLoadingFavoritePlayersInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.tlpLoadingTeamsInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuPlayer.SuspendLayout();
            this.contextMenuFavoritePlayer.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.menuStrip, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblAllPlayers, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblFavoritePlayers, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblMatchesRanked, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.pnlAllPlayers, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.pnlFavoritePlayers, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.pnlRankedPlayers, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.pnlRankedMatches, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnPrintRankedPlayers, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnPrintRankedMatches, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tlpLoadingTeamsInfo, 1, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // menuStrip
            // 
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tableLayoutPanel1.SetColumnSpan(this.menuStrip, 4);
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsMenuItem});
            this.menuStrip.Name = "menuStrip";
            // 
            // settingsMenuItem
            // 
            this.settingsMenuItem.Name = "settingsMenuItem";
            resources.ApplyResources(this.settingsMenuItem, "settingsMenuItem");
            this.settingsMenuItem.Click += new System.EventHandler(this.SettingsMenuItem_Click);
            // 
            // lblAllPlayers
            // 
            resources.ApplyResources(this.lblAllPlayers, "lblAllPlayers");
            this.lblAllPlayers.Name = "lblAllPlayers";
            // 
            // lblFavoritePlayers
            // 
            resources.ApplyResources(this.lblFavoritePlayers, "lblFavoritePlayers");
            this.lblFavoritePlayers.Name = "lblFavoritePlayers";
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.lblPlayersRanked, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.ddlRankOptions, 1, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // lblPlayersRanked
            // 
            resources.ApplyResources(this.lblPlayersRanked, "lblPlayersRanked");
            this.lblPlayersRanked.Name = "lblPlayersRanked";
            // 
            // ddlRankOptions
            // 
            resources.ApplyResources(this.ddlRankOptions, "ddlRankOptions");
            this.ddlRankOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlRankOptions.FormattingEnabled = true;
            this.ddlRankOptions.Items.AddRange(new object[] {
            resources.GetString("ddlRankOptions.Items"),
            resources.GetString("ddlRankOptions.Items1")});
            this.ddlRankOptions.Name = "ddlRankOptions";
            this.ddlRankOptions.SelectedIndexChanged += new System.EventHandler(this.DdlRankOptions_SelectedIndexChanged);
            // 
            // lblMatchesRanked
            // 
            resources.ApplyResources(this.lblMatchesRanked, "lblMatchesRanked");
            this.lblMatchesRanked.Name = "lblMatchesRanked";
            // 
            // pnlAllPlayers
            // 
            this.pnlAllPlayers.AllowDrop = true;
            resources.ApplyResources(this.pnlAllPlayers, "pnlAllPlayers");
            this.pnlAllPlayers.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlAllPlayers.Controls.Add(this.tlpLoadingAllPlayersInfo);
            this.pnlAllPlayers.Name = "pnlAllPlayers";
            this.pnlAllPlayers.DragDrop += new System.Windows.Forms.DragEventHandler(this.PnlAllPlayers_DragDrop);
            this.pnlAllPlayers.DragEnter += new System.Windows.Forms.DragEventHandler(this.PnlPlayers_DragEnter);
            // 
            // tlpLoadingAllPlayersInfo
            // 
            resources.ApplyResources(this.tlpLoadingAllPlayersInfo, "tlpLoadingAllPlayersInfo");
            this.tlpLoadingAllPlayersInfo.Controls.Add(this.pictureBox2, 0, 0);
            this.tlpLoadingAllPlayersInfo.Controls.Add(this.lblLoadingAllPlayers, 1, 0);
            this.tlpLoadingAllPlayersInfo.Name = "tlpLoadingAllPlayersInfo";
            // 
            // pictureBox2
            // 
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.Image = global::WindowsFormsApp.Properties.Resources.ajax_loader;
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            // 
            // lblLoadingAllPlayers
            // 
            resources.ApplyResources(this.lblLoadingAllPlayers, "lblLoadingAllPlayers");
            this.lblLoadingAllPlayers.Name = "lblLoadingAllPlayers";
            // 
            // pnlFavoritePlayers
            // 
            this.pnlFavoritePlayers.AllowDrop = true;
            resources.ApplyResources(this.pnlFavoritePlayers, "pnlFavoritePlayers");
            this.pnlFavoritePlayers.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlFavoritePlayers.Controls.Add(this.tlpLoadingFavoritePlayersInfo);
            this.pnlFavoritePlayers.Name = "pnlFavoritePlayers";
            this.pnlFavoritePlayers.DragDrop += new System.Windows.Forms.DragEventHandler(this.PnlFavoritePlayers_DragDrop);
            this.pnlFavoritePlayers.DragEnter += new System.Windows.Forms.DragEventHandler(this.PnlPlayers_DragEnter);
            // 
            // tlpLoadingFavoritePlayersInfo
            // 
            resources.ApplyResources(this.tlpLoadingFavoritePlayersInfo, "tlpLoadingFavoritePlayersInfo");
            this.tlpLoadingFavoritePlayersInfo.Controls.Add(this.pictureBox3, 0, 0);
            this.tlpLoadingFavoritePlayersInfo.Controls.Add(this.lblLoadingFavoritePlayers, 1, 0);
            this.tlpLoadingFavoritePlayersInfo.Name = "tlpLoadingFavoritePlayersInfo";
            // 
            // pictureBox3
            // 
            resources.ApplyResources(this.pictureBox3, "pictureBox3");
            this.pictureBox3.Image = global::WindowsFormsApp.Properties.Resources.ajax_loader;
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.TabStop = false;
            // 
            // lblLoadingFavoritePlayers
            // 
            resources.ApplyResources(this.lblLoadingFavoritePlayers, "lblLoadingFavoritePlayers");
            this.lblLoadingFavoritePlayers.Name = "lblLoadingFavoritePlayers";
            // 
            // pnlRankedPlayers
            // 
            resources.ApplyResources(this.pnlRankedPlayers, "pnlRankedPlayers");
            this.pnlRankedPlayers.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlRankedPlayers.Name = "pnlRankedPlayers";
            // 
            // pnlRankedMatches
            // 
            resources.ApplyResources(this.pnlRankedMatches, "pnlRankedMatches");
            this.pnlRankedMatches.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlRankedMatches.Name = "pnlRankedMatches";
            // 
            // btnPrintRankedPlayers
            // 
            this.btnPrintRankedPlayers.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.btnPrintRankedPlayers, "btnPrintRankedPlayers");
            this.btnPrintRankedPlayers.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnPrintRankedPlayers.Name = "btnPrintRankedPlayers";
            this.btnPrintRankedPlayers.UseVisualStyleBackColor = false;
            this.btnPrintRankedPlayers.Click += new System.EventHandler(this.BtnPrintRankedPlayers_Click);
            // 
            // btnPrintRankedMatches
            // 
            this.btnPrintRankedMatches.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.btnPrintRankedMatches, "btnPrintRankedMatches");
            this.btnPrintRankedMatches.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnPrintRankedMatches.Name = "btnPrintRankedMatches";
            this.btnPrintRankedMatches.UseVisualStyleBackColor = false;
            this.btnPrintRankedMatches.Click += new System.EventHandler(this.BtnPrintRankedMatches_Click);
            // 
            // tableLayoutPanel3
            // 
            resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
            this.tableLayoutPanel3.Controls.Add(this.lblFavoriteTeam, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.ddlTeams, 1, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            // 
            // lblFavoriteTeam
            // 
            resources.ApplyResources(this.lblFavoriteTeam, "lblFavoriteTeam");
            this.lblFavoriteTeam.Name = "lblFavoriteTeam";
            // 
            // ddlTeams
            // 
            resources.ApplyResources(this.ddlTeams, "ddlTeams");
            this.ddlTeams.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlTeams.FormattingEnabled = true;
            this.ddlTeams.Name = "ddlTeams";
            this.ddlTeams.SelectedIndexChanged += new System.EventHandler(this.DdlTeams_SelectedIndexChanged);
            // 
            // tlpLoadingTeamsInfo
            // 
            resources.ApplyResources(this.tlpLoadingTeamsInfo, "tlpLoadingTeamsInfo");
            this.tlpLoadingTeamsInfo.Controls.Add(this.lblLoadingTeams, 1, 0);
            this.tlpLoadingTeamsInfo.Controls.Add(this.pictureBox1, 0, 0);
            this.tlpLoadingTeamsInfo.Name = "tlpLoadingTeamsInfo";
            // 
            // lblLoadingTeams
            // 
            resources.ApplyResources(this.lblLoadingTeams, "lblLoadingTeams");
            this.lblLoadingTeams.Name = "lblLoadingTeams";
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Image = global::WindowsFormsApp.Properties.Resources.ajax_loader;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // contextMenuPlayer
            // 
            this.contextMenuPlayer.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuPlayer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToFavoritePlayersToolStripMenuItem});
            this.contextMenuPlayer.Name = "contextMenuPlayer";
            resources.ApplyResources(this.contextMenuPlayer, "contextMenuPlayer");
            this.contextMenuPlayer.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuPlayer_Opening);
            // 
            // addToFavoritePlayersToolStripMenuItem
            // 
            this.addToFavoritePlayersToolStripMenuItem.Name = "addToFavoritePlayersToolStripMenuItem";
            resources.ApplyResources(this.addToFavoritePlayersToolStripMenuItem, "addToFavoritePlayersToolStripMenuItem");
            this.addToFavoritePlayersToolStripMenuItem.Click += new System.EventHandler(this.AddToFavoritePlayersContextMenuItem_Click);
            // 
            // contextMenuFavoritePlayer
            // 
            this.contextMenuFavoritePlayer.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuFavoritePlayer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeFromFavoritePlayersToolStripMenuItem});
            this.contextMenuFavoritePlayer.Name = "contextMenuFavoritePlayer";
            resources.ApplyResources(this.contextMenuFavoritePlayer, "contextMenuFavoritePlayer");
            this.contextMenuFavoritePlayer.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuPlayer_Opening);
            // 
            // removeFromFavoritePlayersToolStripMenuItem
            // 
            this.removeFromFavoritePlayersToolStripMenuItem.Name = "removeFromFavoritePlayersToolStripMenuItem";
            resources.ApplyResources(this.removeFromFavoritePlayersToolStripMenuItem, "removeFromFavoritePlayersToolStripMenuItem");
            this.removeFromFavoritePlayersToolStripMenuItem.Click += new System.EventHandler(this.RemoveFromFavoritePlayersContextMenuItem_Click);
            // 
            // printDialog
            // 
            this.printDialog.Document = this.printDocument;
            this.printDialog.UseEXDialog = true;
            // 
            // printDocument
            // 
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintDocument_PrintPage);
            // 
            // printPreviewDialog
            // 
            resources.ApplyResources(this.printPreviewDialog, "printPreviewDialog");
            this.printPreviewDialog.Document = this.printDocument;
            this.printPreviewDialog.Name = "printPreviewDialog";
            // 
            // pageSetupDialog
            // 
            this.pageSetupDialog.Document = this.printDocument;
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.pnlAllPlayers.ResumeLayout(false);
            this.tlpLoadingAllPlayersInfo.ResumeLayout(false);
            this.tlpLoadingAllPlayersInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pnlFavoritePlayers.ResumeLayout(false);
            this.tlpLoadingFavoritePlayersInfo.ResumeLayout(false);
            this.tlpLoadingFavoritePlayersInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tlpLoadingTeamsInfo.ResumeLayout(false);
            this.tlpLoadingTeamsInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuPlayer.ResumeLayout(false);
            this.contextMenuFavoritePlayer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem settingsMenuItem;
        private System.Windows.Forms.Label lblAllPlayers;
        private System.Windows.Forms.Label lblFavoritePlayers;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblPlayersRanked;
        private System.Windows.Forms.ComboBox ddlRankOptions;
        private System.Windows.Forms.Label lblMatchesRanked;
        private System.Windows.Forms.FlowLayoutPanel pnlAllPlayers;
        private System.Windows.Forms.FlowLayoutPanel pnlFavoritePlayers;
        private System.Windows.Forms.FlowLayoutPanel pnlRankedPlayers;
        private System.Windows.Forms.FlowLayoutPanel pnlRankedMatches;
        private System.Windows.Forms.Button btnPrintRankedPlayers;
        private System.Windows.Forms.Button btnPrintRankedMatches;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lblFavoriteTeam;
        private System.Windows.Forms.ComboBox ddlTeams;
        private System.Windows.Forms.TableLayoutPanel tlpLoadingAllPlayersInfo;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblLoadingAllPlayers;
        private System.Windows.Forms.TableLayoutPanel tlpLoadingFavoritePlayersInfo;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lblLoadingFavoritePlayers;
        private System.Windows.Forms.TableLayoutPanel tlpLoadingTeamsInfo;
        private System.Windows.Forms.Label lblLoadingTeams;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuPlayer;
        private System.Windows.Forms.ToolStripMenuItem addToFavoritePlayersToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuFavoritePlayer;
        private System.Windows.Forms.ToolStripMenuItem removeFromFavoritePlayersToolStripMenuItem;
        private System.Windows.Forms.PrintDialog printDialog;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog;
    }
}

