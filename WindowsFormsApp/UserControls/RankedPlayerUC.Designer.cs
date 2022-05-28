
namespace WindowsFormsApp.UserControls
{
    partial class RankedPlayerUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RankedPlayerUC));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblNamePlaceholder = new System.Windows.Forms.Label();
            this.lblRankPlaceholder = new System.Windows.Forms.Label();
            this.pbPlayerPicture = new System.Windows.Forms.PictureBox();
            this.btnChangePicture = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.lblCaptain = new System.Windows.Forms.Label();
            this.lblCaptainPlaceholder = new System.Windows.Forms.Label();
            this.lblShirtNumber = new System.Windows.Forms.Label();
            this.lblShirtNumberPlaceholder = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblPositionPlaceholder = new System.Windows.Forms.Label();
            this.lblNumber = new System.Windows.Forms.Label();
            this.lblNumberPlaceholder = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayerPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.lblNamePlaceholder, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblRankPlaceholder, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pbPlayerPicture, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnChangePicture, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblName, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblCaptain, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblCaptainPlaceholder, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblShirtNumber, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblShirtNumberPlaceholder, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblPosition, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblPositionPlaceholder, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblNumber, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblNumberPlaceholder, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Click += new System.EventHandler(this.BtnChangePicture_Click);
            // 
            // lblNamePlaceholder
            // 
            resources.ApplyResources(this.lblNamePlaceholder, "lblNamePlaceholder");
            this.lblNamePlaceholder.Name = "lblNamePlaceholder";
            // 
            // lblRankPlaceholder
            // 
            resources.ApplyResources(this.lblRankPlaceholder, "lblRankPlaceholder");
            this.lblRankPlaceholder.Name = "lblRankPlaceholder";
            // 
            // pbPlayerPicture
            // 
            this.pbPlayerPicture.BackColor = System.Drawing.SystemColors.ControlLightLight;
            resources.ApplyResources(this.pbPlayerPicture, "pbPlayerPicture");
            this.pbPlayerPicture.Image = global::WindowsFormsApp.Properties.Resources.player_generic;
            this.pbPlayerPicture.Name = "pbPlayerPicture";
            this.tableLayoutPanel1.SetRowSpan(this.pbPlayerPicture, 3);
            this.pbPlayerPicture.TabStop = false;
            // 
            // btnChangePicture
            // 
            resources.ApplyResources(this.btnChangePicture, "btnChangePicture");
            this.btnChangePicture.Name = "btnChangePicture";
            this.tableLayoutPanel1.SetRowSpan(this.btnChangePicture, 2);
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
            // lblNumber
            // 
            resources.ApplyResources(this.lblNumber, "lblNumber");
            this.lblNumber.Name = "lblNumber";
            // 
            // lblNumberPlaceholder
            // 
            resources.ApplyResources(this.lblNumberPlaceholder, "lblNumberPlaceholder");
            this.lblNumberPlaceholder.Name = "lblNumberPlaceholder";
            // 
            // RankedPlayerUC
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "RankedPlayerUC";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayerPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblRankPlaceholder;
        private System.Windows.Forms.Label lblNamePlaceholder;
        private System.Windows.Forms.PictureBox pbPlayerPicture;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblCaptain;
        private System.Windows.Forms.Label lblCaptainPlaceholder;
        private System.Windows.Forms.Label lblShirtNumber;
        private System.Windows.Forms.Label lblShirtNumberPlaceholder;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblPositionPlaceholder;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Label lblNumberPlaceholder;
        private System.Windows.Forms.Button btnChangePicture;
    }
}
