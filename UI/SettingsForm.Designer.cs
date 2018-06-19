namespace SimpleDatabaseReplicator.UI
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
            this.lblCurrentLang = new System.Windows.Forms.Label();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblCurrentLang
            // 
            this.lblCurrentLang.AutoSize = true;
            this.lblCurrentLang.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCurrentLang.Location = new System.Drawing.Point(66, 59);
            this.lblCurrentLang.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCurrentLang.Name = "lblCurrentLang";
            this.lblCurrentLang.Size = new System.Drawing.Size(134, 20);
            this.lblCurrentLang.TabIndex = 6;
            this.lblCurrentLang.Text = "CurrentLanguage";
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.Location = new System.Drawing.Point(72, 84);
            this.cmbLanguage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(268, 28);
            this.cmbLanguage.TabIndex = 4;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 342);
            this.Controls.Add(this.lblCurrentLang);
            this.Controls.Add(this.cmbLanguage);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblCurrentLang;
        private System.Windows.Forms.ComboBox cmbLanguage;
    }
}