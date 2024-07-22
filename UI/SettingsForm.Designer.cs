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
            lblCurrentLang = new System.Windows.Forms.Label();
            cmbLanguage = new System.Windows.Forms.ComboBox();
            SuspendLayout();
            // 
            // lblCurrentLang
            // 
            lblCurrentLang.AutoSize = true;
            lblCurrentLang.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            lblCurrentLang.Location = new System.Drawing.Point(67, 55);
            lblCurrentLang.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblCurrentLang.Name = "lblCurrentLang";
            lblCurrentLang.Size = new System.Drawing.Size(89, 25);
            lblCurrentLang.TabIndex = 6;
            lblCurrentLang.Text = "Language";
            // 
            // cmbLanguage
            // 
            cmbLanguage.FormattingEnabled = true;
            cmbLanguage.Location = new System.Drawing.Point(67, 86);
            cmbLanguage.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cmbLanguage.Name = "cmbLanguage";
            cmbLanguage.Size = new System.Drawing.Size(297, 33);
            cmbLanguage.TabIndex = 4;
            cmbLanguage.SelectedIndexChanged += cmbLanguage_SelectedIndexChanged;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            ClientSize = new System.Drawing.Size(686, 459);
            Controls.Add(lblCurrentLang);
            Controls.Add(cmbLanguage);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "SettingsForm";
            Text = "Settings";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label lblCurrentLang;
        private System.Windows.Forms.ComboBox cmbLanguage;
    }
}