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
            cbProvider = new ComboBox();
            tbHost = new TextBox();
            tbPort = new TextBox();
            tbUsername = new TextBox();
            tbPassword = new TextBox();
            tbDatabase = new TextBox();
            tbConnectionString = new TextBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            btnTest = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // cbProvider
            // 
            cbProvider.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.SetColumnSpan(cbProvider, 3);
            cbProvider.DropDownStyle = ComboBoxStyle.DropDownList;
            cbProvider.Location = new System.Drawing.Point(161, 3);
            cbProvider.Name = "cbProvider";
            cbProvider.Size = new System.Drawing.Size(602, 33);
            cbProvider.TabIndex = 7;
            cbProvider.SelectedIndexChanged += cbProvider_SelectedIndexChanged;
            // 
            // tbHost
            // 
            tbHost.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbHost.Location = new System.Drawing.Point(161, 42);
            tbHost.Name = "tbHost";
            tbHost.Size = new System.Drawing.Size(214, 31);
            tbHost.TabIndex = 8;
            // 
            // tbPort
            // 
            tbPort.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbPort.Location = new System.Drawing.Point(474, 42);
            tbPort.Name = "tbPort";
            tbPort.Size = new System.Drawing.Size(289, 31);
            tbPort.TabIndex = 9;
            // 
            // tbUsername
            // 
            tbUsername.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbUsername.Location = new System.Drawing.Point(163, 81);
            tbUsername.Margin = new Padding(5);
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new System.Drawing.Size(210, 31);
            tbUsername.TabIndex = 10;
            // 
            // tbPassword
            // 
            tbPassword.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbPassword.Location = new System.Drawing.Point(474, 79);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new System.Drawing.Size(289, 31);
            tbPassword.TabIndex = 11;
            // 
            // tbDatabase
            // 
            tbDatabase.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbDatabase.Location = new System.Drawing.Point(163, 122);
            tbDatabase.Margin = new Padding(5);
            tbDatabase.Name = "tbDatabase";
            tbDatabase.Size = new System.Drawing.Size(210, 31);
            tbDatabase.TabIndex = 12;
            // 
            // tbConnectionString
            // 
            tbConnectionString.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.SetColumnSpan(tbConnectionString, 3);
            tbConnectionString.Location = new System.Drawing.Point(163, 163);
            tbConnectionString.Margin = new Padding(5);
            tbConnectionString.Multiline = true;
            tbConnectionString.Name = "tbConnectionString";
            tbConnectionString.Size = new System.Drawing.Size(598, 60);
            tbConnectionString.TabIndex = 13;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(cbProvider, 1, 0);
            tableLayoutPanel1.Controls.Add(tbHost, 1, 1);
            tableLayoutPanel1.Controls.Add(tbPort, 3, 1);
            tableLayoutPanel1.Controls.Add(tbUsername, 1, 2);
            tableLayoutPanel1.Controls.Add(tbPassword, 3, 2);
            tableLayoutPanel1.Controls.Add(tbDatabase, 1, 3);
            tableLayoutPanel1.Controls.Add(tbConnectionString, 1, 4);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(label3, 2, 1);
            tableLayoutPanel1.Controls.Add(label4, 0, 2);
            tableLayoutPanel1.Controls.Add(label5, 2, 2);
            tableLayoutPanel1.Controls.Add(label6, 0, 3);
            tableLayoutPanel1.Controls.Add(label7, 0, 4);
            tableLayoutPanel1.Controls.Add(btnTest, 3, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new System.Drawing.Size(766, 228);
            tableLayoutPanel1.TabIndex = 14;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(3, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(78, 39);
            label1.TabIndex = 14;
            label1.Text = "Provider";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(3, 39);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(50, 37);
            label2.TabIndex = 14;
            label2.Text = "Host";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(381, 39);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(44, 25);
            label3.TabIndex = 14;
            label3.Text = "Port";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(3, 76);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(91, 41);
            label4.TabIndex = 14;
            label4.Text = "Username";
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(381, 76);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(87, 25);
            label5.TabIndex = 14;
            label5.Text = "Password";
            label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(3, 117);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(86, 41);
            label6.TabIndex = 14;
            label6.Text = "Database";
            label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(3, 158);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(152, 70);
            label7.TabIndex = 14;
            label7.Text = "Connection string";
            label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnTest
            // 
            btnTest.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnTest.Location = new System.Drawing.Point(474, 120);
            btnTest.Name = "btnTest";
            btnTest.Size = new System.Drawing.Size(289, 35);
            btnTest.TabIndex = 15;
            btnTest.Text = "Test";
            btnTest.UseVisualStyleBackColor = true;
            btnTest.Click += btnTest_Click;
            // 
            // ConnectionStringSetup
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "ConnectionStringSetup";
            Size = new System.Drawing.Size(766, 228);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
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
