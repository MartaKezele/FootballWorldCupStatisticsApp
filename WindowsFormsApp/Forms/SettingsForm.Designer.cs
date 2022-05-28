
namespace WindowsFormsApp
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ddlChampionship = new System.Windows.Forms.ComboBox();
            this.lblChampionship = new System.Windows.Forms.Label();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.ddlLanguage = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.ddlChampionship, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblChampionship, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblLanguage, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ddlLanguage, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnOK, 0, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // ddlChampionship
            // 
            resources.ApplyResources(this.ddlChampionship, "ddlChampionship");
            this.tableLayoutPanel1.SetColumnSpan(this.ddlChampionship, 2);
            this.ddlChampionship.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlChampionship.FormattingEnabled = true;
            this.ddlChampionship.Items.AddRange(new object[] {
            resources.GetString("ddlChampionship.Items"),
            resources.GetString("ddlChampionship.Items1")});
            this.ddlChampionship.Name = "ddlChampionship";
            // 
            // lblChampionship
            // 
            resources.ApplyResources(this.lblChampionship, "lblChampionship");
            this.tableLayoutPanel1.SetColumnSpan(this.lblChampionship, 2);
            this.lblChampionship.Name = "lblChampionship";
            // 
            // lblLanguage
            // 
            resources.ApplyResources(this.lblLanguage, "lblLanguage");
            this.tableLayoutPanel1.SetColumnSpan(this.lblLanguage, 2);
            this.lblLanguage.Name = "lblLanguage";
            // 
            // ddlLanguage
            // 
            resources.ApplyResources(this.ddlLanguage, "ddlLanguage");
            this.tableLayoutPanel1.SetColumnSpan(this.ddlLanguage, 2);
            this.ddlLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlLanguage.FormattingEnabled = true;
            this.ddlLanguage.Items.AddRange(new object[] {
            resources.GetString("ddlLanguage.Items"),
            resources.GetString("ddlLanguage.Items1")});
            this.ddlLanguage.Name = "ddlLanguage";
            this.ddlLanguage.SelectedIndexChanged += new System.EventHandler(this.DdlLanguage_SelectedIndexChanged);
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.btnOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SettingsForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox ddlChampionship;
        private System.Windows.Forms.Label lblChampionship;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.ComboBox ddlLanguage;
        private System.Windows.Forms.Button btnOK;
    }
}