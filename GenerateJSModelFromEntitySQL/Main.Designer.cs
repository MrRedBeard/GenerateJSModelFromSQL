
namespace GenerateJSModelFromSQL
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
            this.textBoxDBServer = new System.Windows.Forms.TextBox();
            this.lblDbServer = new System.Windows.Forms.Label();
            this.checkBoxWindowsAuth = new System.Windows.Forms.CheckBox();
            this.lblWindowsAuth = new System.Windows.Forms.Label();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.panelServerConnection = new System.Windows.Forms.Panel();
            this.textBoxFolderLocation = new System.Windows.Forms.TextBox();
            this.labelFolder = new System.Windows.Forms.Label();
            this.buttonSelectFolder = new System.Windows.Forms.Button();
            this.buttonBuildModel = new System.Windows.Forms.Button();
            this.buttonDeleteConnection = new System.Windows.Forms.Button();
            this.buttonCreateNewConnection = new System.Windows.Forms.Button();
            this.comboBoxDatabases = new System.Windows.Forms.ComboBox();
            this.labelExistingConnections = new System.Windows.Forms.Label();
            this.comboBoxExistingConnections = new System.Windows.Forms.ComboBox();
            this.lblDB = new System.Windows.Forms.Label();
            this.textBoxDatabase = new System.Windows.Forms.TextBox();
            this.buttonTestConnection = new System.Windows.Forms.Button();
            this.lblServerConnectionPanel = new System.Windows.Forms.Label();
            this.btnSaveServer = new System.Windows.Forms.Button();
            this.labelWarning = new System.Windows.Forms.Label();
            this.timerCallOut = new System.Windows.Forms.Timer(this.components);
            this.panelModel = new System.Windows.Forms.Panel();
            this.panelServerConnection.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxDBServer
            // 
            this.textBoxDBServer.Location = new System.Drawing.Point(137, 103);
            this.textBoxDBServer.Name = "textBoxDBServer";
            this.textBoxDBServer.Size = new System.Drawing.Size(287, 20);
            this.textBoxDBServer.TabIndex = 0;
            // 
            // lblDbServer
            // 
            this.lblDbServer.AutoSize = true;
            this.lblDbServer.Location = new System.Drawing.Point(71, 106);
            this.lblDbServer.Name = "lblDbServer";
            this.lblDbServer.Size = new System.Drawing.Size(56, 13);
            this.lblDbServer.TabIndex = 1;
            this.lblDbServer.Text = "DB Server";
            // 
            // checkBoxWindowsAuth
            // 
            this.checkBoxWindowsAuth.AutoSize = true;
            this.checkBoxWindowsAuth.Location = new System.Drawing.Point(137, 181);
            this.checkBoxWindowsAuth.Name = "checkBoxWindowsAuth";
            this.checkBoxWindowsAuth.Size = new System.Drawing.Size(15, 14);
            this.checkBoxWindowsAuth.TabIndex = 2;
            this.checkBoxWindowsAuth.UseVisualStyleBackColor = true;
            this.checkBoxWindowsAuth.CheckedChanged += new System.EventHandler(this.checkBoxWindowsAuth_CheckedChanged);
            // 
            // lblWindowsAuth
            // 
            this.lblWindowsAuth.AutoSize = true;
            this.lblWindowsAuth.Location = new System.Drawing.Point(5, 181);
            this.lblWindowsAuth.Name = "lblWindowsAuth";
            this.lblWindowsAuth.Size = new System.Drawing.Size(122, 13);
            this.lblWindowsAuth.TabIndex = 3;
            this.lblWindowsAuth.Text = "Windows Authentication";
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(137, 218);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(287, 20);
            this.textBoxUsername.TabIndex = 4;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(137, 254);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(287, 20);
            this.textBoxPassword.TabIndex = 5;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(70, 221);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(57, 13);
            this.lblUserName.TabIndex = 6;
            this.lblUserName.Text = "UserName";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(74, 257);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 7;
            this.lblPassword.Text = "Password";
            // 
            // panelServerConnection
            // 
            this.panelServerConnection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelServerConnection.Controls.Add(this.textBoxFolderLocation);
            this.panelServerConnection.Controls.Add(this.labelFolder);
            this.panelServerConnection.Controls.Add(this.buttonSelectFolder);
            this.panelServerConnection.Controls.Add(this.buttonBuildModel);
            this.panelServerConnection.Controls.Add(this.buttonDeleteConnection);
            this.panelServerConnection.Controls.Add(this.buttonCreateNewConnection);
            this.panelServerConnection.Controls.Add(this.comboBoxDatabases);
            this.panelServerConnection.Controls.Add(this.labelExistingConnections);
            this.panelServerConnection.Controls.Add(this.comboBoxExistingConnections);
            this.panelServerConnection.Controls.Add(this.lblDB);
            this.panelServerConnection.Controls.Add(this.textBoxDatabase);
            this.panelServerConnection.Controls.Add(this.buttonTestConnection);
            this.panelServerConnection.Controls.Add(this.lblServerConnectionPanel);
            this.panelServerConnection.Controls.Add(this.btnSaveServer);
            this.panelServerConnection.Controls.Add(this.lblDbServer);
            this.panelServerConnection.Controls.Add(this.textBoxDBServer);
            this.panelServerConnection.Controls.Add(this.lblPassword);
            this.panelServerConnection.Controls.Add(this.checkBoxWindowsAuth);
            this.panelServerConnection.Controls.Add(this.lblUserName);
            this.panelServerConnection.Controls.Add(this.lblWindowsAuth);
            this.panelServerConnection.Controls.Add(this.textBoxPassword);
            this.panelServerConnection.Controls.Add(this.textBoxUsername);
            this.panelServerConnection.Location = new System.Drawing.Point(12, 68);
            this.panelServerConnection.Name = "panelServerConnection";
            this.panelServerConnection.Size = new System.Drawing.Size(502, 442);
            this.panelServerConnection.TabIndex = 8;
            // 
            // textBoxFolderLocation
            // 
            this.textBoxFolderLocation.Location = new System.Drawing.Point(168, 294);
            this.textBoxFolderLocation.Name = "textBoxFolderLocation";
            this.textBoxFolderLocation.ReadOnly = true;
            this.textBoxFolderLocation.Size = new System.Drawing.Size(248, 20);
            this.textBoxFolderLocation.TabIndex = 22;
            // 
            // labelFolder
            // 
            this.labelFolder.AutoSize = true;
            this.labelFolder.Location = new System.Drawing.Point(88, 297);
            this.labelFolder.Name = "labelFolder";
            this.labelFolder.Size = new System.Drawing.Size(36, 13);
            this.labelFolder.TabIndex = 21;
            this.labelFolder.Text = "Folder";
            // 
            // buttonSelectFolder
            // 
            this.buttonSelectFolder.AccessibleDescription = "Select Folder";
            this.buttonSelectFolder.AccessibleName = "";
            this.buttonSelectFolder.BackColor = System.Drawing.Color.Transparent;
            this.buttonSelectFolder.BackgroundImage = global::GenerateJSModelFromSQL.Properties.Resources.folder;
            this.buttonSelectFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSelectFolder.FlatAppearance.BorderSize = 0;
            this.buttonSelectFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSelectFolder.Location = new System.Drawing.Point(134, 291);
            this.buttonSelectFolder.Name = "buttonSelectFolder";
            this.buttonSelectFolder.Size = new System.Drawing.Size(24, 23);
            this.buttonSelectFolder.TabIndex = 20;
            this.buttonSelectFolder.UseVisualStyleBackColor = false;
            this.buttonSelectFolder.Click += new System.EventHandler(this.buttonSelectFolder_Click);
            // 
            // buttonBuildModel
            // 
            this.buttonBuildModel.Location = new System.Drawing.Point(422, 405);
            this.buttonBuildModel.Name = "buttonBuildModel";
            this.buttonBuildModel.Size = new System.Drawing.Size(75, 23);
            this.buttonBuildModel.TabIndex = 19;
            this.buttonBuildModel.Text = "Build Model";
            this.buttonBuildModel.UseVisualStyleBackColor = true;
            this.buttonBuildModel.Click += new System.EventHandler(this.buttonBuildModel_Click);
            // 
            // buttonDeleteConnection
            // 
            this.buttonDeleteConnection.Location = new System.Drawing.Point(390, 6);
            this.buttonDeleteConnection.Name = "buttonDeleteConnection";
            this.buttonDeleteConnection.Size = new System.Drawing.Size(107, 23);
            this.buttonDeleteConnection.TabIndex = 16;
            this.buttonDeleteConnection.Text = "Delete Connection";
            this.buttonDeleteConnection.UseVisualStyleBackColor = true;
            this.buttonDeleteConnection.Click += new System.EventHandler(this.buttonDeleteConnection_Click);
            // 
            // buttonCreateNewConnection
            // 
            this.buttonCreateNewConnection.Location = new System.Drawing.Point(7, 405);
            this.buttonCreateNewConnection.Name = "buttonCreateNewConnection";
            this.buttonCreateNewConnection.Size = new System.Drawing.Size(143, 23);
            this.buttonCreateNewConnection.TabIndex = 18;
            this.buttonCreateNewConnection.Text = "Create New Connection";
            this.buttonCreateNewConnection.UseVisualStyleBackColor = true;
            this.buttonCreateNewConnection.Click += new System.EventHandler(this.buttonCreateNewConnection_Click);
            // 
            // comboBoxDatabases
            // 
            this.comboBoxDatabases.FormattingEnabled = true;
            this.comboBoxDatabases.Location = new System.Drawing.Point(288, 141);
            this.comboBoxDatabases.Name = "comboBoxDatabases";
            this.comboBoxDatabases.Size = new System.Drawing.Size(136, 21);
            this.comboBoxDatabases.TabIndex = 17;
            this.comboBoxDatabases.DropDown += new System.EventHandler(this.comboBoxDatabases_DropDown);
            this.comboBoxDatabases.SelectedIndexChanged += new System.EventHandler(this.comboBoxDatabases_SelectedIndexChanged);
            // 
            // labelExistingConnections
            // 
            this.labelExistingConnections.AutoSize = true;
            this.labelExistingConnections.Location = new System.Drawing.Point(23, 63);
            this.labelExistingConnections.Name = "labelExistingConnections";
            this.labelExistingConnections.Size = new System.Drawing.Size(100, 13);
            this.labelExistingConnections.TabIndex = 15;
            this.labelExistingConnections.Text = "Existing Connection";
            // 
            // comboBoxExistingConnections
            // 
            this.comboBoxExistingConnections.FormattingEnabled = true;
            this.comboBoxExistingConnections.Location = new System.Drawing.Point(137, 60);
            this.comboBoxExistingConnections.Name = "comboBoxExistingConnections";
            this.comboBoxExistingConnections.Size = new System.Drawing.Size(287, 21);
            this.comboBoxExistingConnections.TabIndex = 14;
            this.comboBoxExistingConnections.SelectedIndexChanged += new System.EventHandler(this.comboBoxExistingConnections_SelectedIndexChanged);
            // 
            // lblDB
            // 
            this.lblDB.AutoSize = true;
            this.lblDB.Location = new System.Drawing.Point(70, 144);
            this.lblDB.Name = "lblDB";
            this.lblDB.Size = new System.Drawing.Size(53, 13);
            this.lblDB.TabIndex = 13;
            this.lblDB.Text = "Database";
            // 
            // textBoxDatabase
            // 
            this.textBoxDatabase.Location = new System.Drawing.Point(137, 141);
            this.textBoxDatabase.Name = "textBoxDatabase";
            this.textBoxDatabase.Size = new System.Drawing.Size(135, 20);
            this.textBoxDatabase.TabIndex = 12;
            // 
            // buttonTestConnection
            // 
            this.buttonTestConnection.Location = new System.Drawing.Point(277, 405);
            this.buttonTestConnection.Name = "buttonTestConnection";
            this.buttonTestConnection.Size = new System.Drawing.Size(101, 23);
            this.buttonTestConnection.TabIndex = 11;
            this.buttonTestConnection.Text = "Test Connection";
            this.buttonTestConnection.UseVisualStyleBackColor = true;
            this.buttonTestConnection.Click += new System.EventHandler(this.buttonTestConnection_Click);
            // 
            // lblServerConnectionPanel
            // 
            this.lblServerConnectionPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerConnectionPanel.Location = new System.Drawing.Point(3, 4);
            this.lblServerConnectionPanel.Name = "lblServerConnectionPanel";
            this.lblServerConnectionPanel.Size = new System.Drawing.Size(251, 23);
            this.lblServerConnectionPanel.TabIndex = 10;
            this.lblServerConnectionPanel.Text = "Database Server";
            this.lblServerConnectionPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSaveServer
            // 
            this.btnSaveServer.Location = new System.Drawing.Point(156, 405);
            this.btnSaveServer.Name = "btnSaveServer";
            this.btnSaveServer.Size = new System.Drawing.Size(115, 23);
            this.btnSaveServer.TabIndex = 9;
            this.btnSaveServer.Text = "Update Connection";
            this.btnSaveServer.UseVisualStyleBackColor = true;
            this.btnSaveServer.Click += new System.EventHandler(this.btnSaveServer_Click);
            // 
            // labelWarning
            // 
            this.labelWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWarning.Location = new System.Drawing.Point(12, 4);
            this.labelWarning.Name = "labelWarning";
            this.labelWarning.Size = new System.Drawing.Size(776, 45);
            this.labelWarning.TabIndex = 9;
            this.labelWarning.Text = "WarningMsg";
            this.labelWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerCallOut
            // 
            this.timerCallOut.Interval = 3000;
            this.timerCallOut.Tick += new System.EventHandler(this.timerCallOut_Tick);
            // 
            // panelModel
            // 
            this.panelModel.AllowDrop = true;
            this.panelModel.AutoScroll = true;
            this.panelModel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelModel.Location = new System.Drawing.Point(541, 32);
            this.panelModel.Name = "panelModel";
            this.panelModel.Size = new System.Drawing.Size(630, 465);
            this.panelModel.TabIndex = 10;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1183, 522);
            this.Controls.Add(this.panelModel);
            this.Controls.Add(this.labelWarning);
            this.Controls.Add(this.panelServerConnection);
            this.Name = "MainForm";
            this.Text = "Main";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.panelServerConnection.ResumeLayout(false);
            this.panelServerConnection.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxDBServer;
        private System.Windows.Forms.Label lblDbServer;
        private System.Windows.Forms.CheckBox checkBoxWindowsAuth;
        private System.Windows.Forms.Label lblWindowsAuth;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Panel panelServerConnection;
        private System.Windows.Forms.Label lblServerConnectionPanel;
        private System.Windows.Forms.Button btnSaveServer;
        private System.Windows.Forms.Button buttonTestConnection;
        private System.Windows.Forms.TextBox textBoxDatabase;
        private System.Windows.Forms.Label lblDB;
        private System.Windows.Forms.Label labelWarning;
        private System.Windows.Forms.Label labelExistingConnections;
        private System.Windows.Forms.ComboBox comboBoxExistingConnections;
        private System.Windows.Forms.Timer timerCallOut;
        private System.Windows.Forms.Button buttonDeleteConnection;
        private System.Windows.Forms.ComboBox comboBoxDatabases;
        private System.Windows.Forms.Button buttonCreateNewConnection;
        private System.Windows.Forms.Button buttonBuildModel;
        private System.Windows.Forms.TextBox textBoxFolderLocation;
        private System.Windows.Forms.Label labelFolder;
        private System.Windows.Forms.Button buttonSelectFolder;
        private System.Windows.Forms.Panel panelModel;
    }
}