namespace SimpleDatabaseReplicator.UI
{
    partial class Settings
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
            this.lblCurrentLang.Location = new System.Drawing.Point(26, 34);
            this.lblCurrentLang.Name = "lblCurrentLang";
            this.lblCurrentLang.Size = new System.Drawing.Size(89, 13);
            this.lblCurrentLang.TabIndex = 6;
            this.lblCurrentLang.Text = "CurrentLanguage";
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.Location = new System.Drawing.Point(30, 50);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(180, 21);
            this.cmbLanguage.TabIndex = 4;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 222);
            this.Controls.Add(this.lblCurrentLang);
            this.Controls.Add(this.cmbLanguage);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Settings";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblCurrentLang;
        private System.Windows.Forms.ComboBox cmbLanguage;
    }
}