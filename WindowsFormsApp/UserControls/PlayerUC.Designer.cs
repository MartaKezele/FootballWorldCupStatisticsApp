
namespace WindowsFormsApp.UserControls
{
    partial class PlayerUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerUC));
            this.tlpPlayerContainer = new System.Windows.Forms.TableLayoutPanel();
            this.lblNamePlaceholder = new System.Windows.Forms.Label();
            this.btnChangePicture = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.lblCaptain = new System.Windows.Forms.Label();
            this.lblCaptainPlaceholder = new System.Windows.Forms.Label();
            this.lblShirtNumber = new System.Windows.Forms.Label();
            this.lblShirtNumberPlaceholder = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblPositionPlaceholder = new System.Windows.Forms.Label();
            this.pbPlayerPicture = new System.Windows.Forms.PictureBox();
            this.pbFavoriteStar = new System.Windows.Forms.PictureBox();
            this.tlpPlayerContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayerPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFavoriteStar)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpPlayerContainer
            // 
            resources.ApplyResources(this.tlpPlayerContainer, "tlpPlayerContainer");
            this.tlpPlayerContainer.Controls.Add(this.lblNamePlaceholder, 2, 0);
            this.tlpPlayerContainer.Controls.Add(this.pbPlayerPicture, 0, 0);
            this.tlpPlayerContainer.Controls.Add(this.btnChangePicture, 0, 3);
            this.tlpPlayerContainer.Controls.Add(this.lblName, 1, 0);
            this.tlpPlayerContainer.Controls.Add(this.lblCaptain, 1, 1);
            this.tlpPlayerContainer.Controls.Add(this.lblCaptainPlaceholder, 2, 1);
            this.tlpPlayerContainer.Controls.Add(this.lblShirtNumber, 1, 2);
            this.tlpPlayerContainer.Controls.Add(this.lblShirtNumberPlaceholder, 2, 2);
            this.tlpPlayerContainer.Controls.Add(this.lblPosition, 1, 3);
            this.tlpPlayerContainer.Controls.Add(this.lblPositionPlaceholder, 2, 3);
            this.tlpPlayerContainer.Controls.Add(this.pbFavoriteStar, 3, 0);
            this.tlpPlayerContainer.Name = "tlpPlayerContainer";
            // 
            // lblNamePlaceholder
            // 
            resources.ApplyResources(this.lblNamePlaceholder, "lblNamePlaceholder");
            this.lblNamePlaceholder.Name = "lblNamePlaceholder";
            // 
            // btnChangePicture
            // 
            resources.ApplyResources(this.btnChangePicture, "btnChangePicture");
            this.btnChangePicture.Name = "btnChangePicture";
            this.tlpPlayerContainer.SetRowSpan(this.btnChangePicture, 2);
            this.btnChangePicture.UseVisualStyleBackColor = true;
            this.btnChangePicture.Click += new System.EventHandler(this.BtnChangePicture_Click);
            // 
            // lblName
            // 
            resources.ApplyResources(this.lblName, "lblName");
            this.lblName.Name = "lblName";
            // 
            // lblCaptain
            // 
            resources.ApplyResources(this.lblCaptain, "lblCaptain");
            this.lblCaptain.Name = "lblCaptain";
            // 
            // lblCaptainPlaceholder
            // 
            resources.ApplyResources(this.lblCaptainPlaceholder, "lblCaptainPlaceholder");
            this.lblCaptainPlaceholder.Name = "lblCaptainPlaceholder";
            // 
            // lblShirtNumber
            // 
            resources.ApplyResources(this.lblShirtNumber, "lblShirtNumber");
            this.lblShirtNumber.Name = "lblShirtNumber";
            // 
            // lblShirtNumberPlaceholder
            // 
            resources.ApplyResources(this.lblShirtNumberPlaceholder, "lblShirtNumberPlaceholder");
            this.lblShirtNumberPlaceholder.Name = "lblShirtNumberPlaceholder";
            // 
            // lblPosition
            // 
            resources.ApplyResources(this.lblPosition, "lblPosition");
            this.lblPosition.Name = "lblPosition";
            // 
            // lblPositionPlaceholder
            // 
            resources.ApplyResources(this.lblPositionPlaceholder, "lblPositionPlaceholder");
            this.lblPositionPlaceholder.Name = "lblPositionPlaceholder";
            // 
            // pbPlayerPicture
            // 
            this.pbPlayerPicture.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pbPlayerPicture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.pbPlayerPicture, "pbPlayerPicture");
            this.pbPlayerPicture.Image = global::WindowsFormsApp.Properties.Resources.player_generic;
            this.pbPlayerPicture.Name = "pbPlayerPicture";
            this.tlpPlayerContainer.SetRowSpan(this.pbPlayerPicture, 3);
            this.pbPlayerPicture.TabStop = false;
            // 
            // pbFavoriteStar
            // 
            resources.ApplyResources(this.pbFavoriteStar, "pbFavoriteStar");
            this.pbFavoriteStar.Name = "pbFavoriteStar";
            this.pbFavoriteStar.TabStop = false;
            // 
            // PlayerUC
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.tlpPlayerContainer);
            this.Name = "PlayerUC";
            this.tlpPlayerContainer.ResumeLayout(false);
            this.tlpPlayerContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayerPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFavoriteStar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpPlayerContainer;
        private System.Windows.Forms.Label lblNamePlaceholder;
        private System.Windows.Forms.PictureBox pbPlayerPicture;
        private System.Windows.Forms.Button btnChangePicture;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblCaptain;
        private System.Windows.Forms.Label lblCaptainPlaceholder;
        private System.Windows.Forms.Label lblShirtNumber;
        private System.Windows.Forms.Label lblShirtNumberPlaceholder;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblPositionPlaceholder;
        private System.Windows.Forms.PictureBox pbFavoriteStar;
    }
}
