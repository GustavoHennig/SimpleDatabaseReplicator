using System.Windows.Forms;

namespace SimpleDatabaseReplicator.UI
{
    partial class ConnectionStringSetup
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
            this.cbProvider = new ComboBox();
            this.tbHost = new TextBox();
            this.tbPort = new TextBox();
            this.tbUsername = new TextBox();
            this.tbPassword = new TextBox();
            this.tbDatabase = new TextBox();
            this.tbConnectionString = new TextBox();
            this.tableLayoutPanel1 = new TableLayoutPanel();
            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.label4 = new Label();
            this.label5 = new Label();
            this.label6 = new Label();
            this.label7 = new Label();
            this.btnTest = new Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbProvider
            // 
            this.cbProvider.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.tableLayoutPanel1.SetColumnSpan(this.cbProvider, 3);
            this.cbProvider.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbProvider.Location = new System.Drawing.Point(161, 3);
            this.cbProvider.Name = "cbProvider";
            this.cbProvider.Size = new System.Drawing.Size(602, 33);
            this.cbProvider.TabIndex = 7;
            this.cbProvider.SelectedIndexChanged += this.cbProvider_SelectedIndexChanged;
            // 
            // tbHost
            // 
            this.tbHost.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.tbHost.Location = new System.Drawing.Point(161, 42);
            this.tbHost.Name = "tbHost";
            this.tbHost.Size = new System.Drawing.Size(214, 31);
            this.tbHost.TabIndex = 8;
            // 
            // tbPort
            // 
            this.tbPort.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.tbPort.Location = new System.Drawing.Point(474, 42);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(289, 31);
            this.tbPort.TabIndex = 9;
            // 
            // tbUsername
            // 
            this.tbUsername.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.tbUsername.Location = new System.Drawing.Point(163, 81);
            this.tbUsername.Margin = new Padding(5);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(210, 31);
            this.tbUsername.TabIndex = 10;
            // 
            // tbPassword
            // 
            this.tbPassword.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.tbPassword.Location = new System.Drawing.Point(474, 79);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(289, 31);
            this.tbPassword.TabIndex = 11;
            // 
            // tbDatabase
            // 
            this.tbDatabase.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.tbDatabase.Location = new System.Drawing.Point(163, 122);
            this.tbDatabase.Margin = new Padding(5);
            this.tbDatabase.Name = "tbDatabase";
            this.tbDatabase.Size = new System.Drawing.Size(210, 31);
            this.tbDatabase.TabIndex = 12;
            // 
            // tbConnectionString
            // 
            this.tbConnectionString.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.tableLayoutPanel1.SetColumnSpan(this.tbConnectionString, 3);
            this.tbConnectionString.Location = new System.Drawing.Point(163, 163);
            this.tbConnectionString.Margin = new Padding(5);
            this.tbConnectionString.Multiline = true;
            this.tbConnectionString.Name = "tbConnectionString";
            this.tbConnectionString.Size = new System.Drawing.Size(598, 60);
            this.tbConnectionString.TabIndex = 13;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.cbProvider, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbHost, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbPort, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbUsername, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbPassword, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbDatabase, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.tbConnectionString, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnTest, 3, 3);
            this.tableLayoutPanel1.Dock = DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(766, 228);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 39);
            this.label1.TabIndex = 14;
            this.label1.Text = "Provider";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 37);
            this.label2.TabIndex = 14;
            this.label2.Text = "Host";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(381, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 25);
            this.label3.TabIndex = 14;
            this.label3.Text = "Port";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 41);
            this.label4.TabIndex = 14;
            this.label4.Text = "Username";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(381, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 25);
            this.label5.TabIndex = 14;
            this.label5.Text = "Password";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 41);
            this.label6.TabIndex = 14;
            this.label6.Text = "Database";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 158);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(152, 70);
            this.label7.TabIndex = 14;
            this.label7.Text = "Connection string";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnTest
            // 
            this.btnTest.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.btnTest.Location = new System.Drawing.Point(474, 120);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(289, 35);
            this.btnTest.TabIndex = 15;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += this.btnTest_Click;
            // 
            // ConnectionStringSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ConnectionStringSetup";
            this.Size = new System.Drawing.Size(766, 228);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private ComboBox cbProvider;
        private TextBox tbHost;
        private TextBox tbPort;
        private TextBox tbUsername;
        private TextBox tbPassword;
        private TextBox tbDatabase;
        private TextBox tbConnectionString;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Button btnTest;
    }
}
