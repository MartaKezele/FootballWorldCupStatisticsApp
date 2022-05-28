
namespace WindowsFormsApp.UserControls
{
    partial class MatchUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MatchUC));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblNumberPlaceholder = new System.Windows.Forms.Label();
            this.lblVenue = new System.Windows.Forms.Label();
            this.lblVenuePlaceholder = new System.Windows.Forms.Label();
            this.lblHomeTeam = new System.Windows.Forms.Label();
            this.lblHomeTeamPlaceholder = new System.Windows.Forms.Label();
            this.lblAwayTeam = new System.Windows.Forms.Label();
            this.lblAwayTeamPlaceholder = new System.Windows.Forms.Label();
            this.lblAttendance = new System.Windows.Forms.Label();
            this.lblAttendancePlaceholder = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.lblNumberPlaceholder, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblVenue, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblVenuePlaceholder, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblHomeTeam, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblHomeTeamPlaceholder, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblAwayTeam, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblAwayTeamPlaceholder, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblAttendance, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblAttendancePlaceholder, 2, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // lblNumberPlaceholder
            // 
            resources.ApplyResources(this.lblNumberPlaceholder, "lblNumberPlaceholder");
            this.lblNumberPlaceholder.Name = "lblNumberPlaceholder";
            // 
            // lblVenue
            // 
            resources.ApplyResources(this.lblVenue, "lblVenue");
            this.lblVenue.Name = "lblVenue";
            // 
            // lblVenuePlaceholder
            // 
            resources.ApplyResources(this.lblVenuePlaceholder, "lblVenuePlaceholder");
            this.lblVenuePlaceholder.Name = "lblVenuePlaceholder";
            // 
            // lblHomeTeam
            // 
            resources.ApplyResources(this.lblHomeTeam, "lblHomeTeam");
            this.lblHomeTeam.Name = "lblHomeTeam";
            // 
            // lblHomeTeamPlaceholder
            // 
            resources.ApplyResources(this.lblHomeTeamPlaceholder, "lblHomeTeamPlaceholder");
            this.lblHomeTeamPlaceholder.Name = "lblHomeTeamPlaceholder";
            // 
            // lblAwayTeam
            // 
            resources.ApplyResources(this.lblAwayTeam, "lblAwayTeam");
            this.lblAwayTeam.Name = "lblAwayTeam";
            // 
            // lblAwayTeamPlaceholder
            // 
            resources.ApplyResources(this.lblAwayTeamPlaceholder, "lblAwayTeamPlaceholder");
            this.lblAwayTeamPlaceholder.Name = "lblAwayTeamPlaceholder";
            // 
            // lblAttendance
            // 
            resources.ApplyResources(this.lblAttendance, "lblAttendance");
            this.lblAttendance.Name = "lblAttendance";
            // 
            // lblAttendancePlaceholder
            // 
            resources.ApplyResources(this.lblAttendancePlaceholder, "lblAttendancePlaceholder");
            this.lblAttendancePlaceholder.Name = "lblAttendancePlaceholder";
            // 
            // MatchUC
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MatchUC";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblNumberPlaceholder;
        private System.Windows.Forms.Label lblVenue;
        private System.Windows.Forms.Label lblVenuePlaceholder;
        private System.Windows.Forms.Label lblHomeTeam;
        private System.Windows.Forms.Label lblHomeTeamPlaceholder;
        private System.Windows.Forms.Label lblAwayTeam;
        private System.Windows.Forms.Label lblAwayTeamPlaceholder;
        private System.Windows.Forms.Label lblAttendance;
        private System.Windows.Forms.Label lblAttendancePlaceholder;
    }
}
