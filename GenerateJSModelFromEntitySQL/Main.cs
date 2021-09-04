using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace GenerateJSModelFromSQL
{
    //ToDo:// Add support for SQLite https://docs.microsoft.com/en-us/dotnet/standard/data/sqlite/?tabs=netcore-cli
    //ToDo:// Add support for MySQL https://www.nuget.org/packages/MySql.Data/8.0.26/ https://zetcode.com/csharp/mysql/ https://stackoverflow.com/questions/21618015/how-to-connect-to-mysql-database https://stackoverflow.com/questions/4471482/connecting-to-a-mysql-db-with-c-sharp-need-some-with-datasets
    public partial class MainForm : Form
    {
        public clsSettings settings { get; set; }
        public clsModelBuilder modelBuilder { get; set; }

        public MainForm()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            labelWarning.Text = "";

            LoadExistingConnectionsDropDown();

            modelBuilder = new clsModelBuilder();
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            ResizeForm();
        }

        private void buttonBuildModel_Click(object sender, EventArgs e)
        {
            if (TestConnection(true))
            {
                SaveConnection();
                clsConnections SelectedConnection = settings.Connections[comboBoxExistingConnections.SelectedIndex];

                textBoxDBServer.Text = SelectedConnection.Server;
                textBoxDatabase.Text = SelectedConnection.Database;
                checkBoxWindowsAuth.Checked = SelectedConnection.WindowsAuthentication;
                textBoxUsername.Text = SelectedConnection.UserName;
                textBoxPassword.Text = SelectedConnection.Password;
                textBoxFolderLocation.Text = SelectedConnection.ProjectPath;

                //SelectedConnection
                List<Image> images = modelBuilder.BuildModels(settings, SelectedConnection);

                GenerateModelUI(images);
            }
        }

        public void GenerateModelUI(List<Image> images)
        {
            panelModel.Controls.Clear();

            Point location = new System.Drawing.Point(10, 10);

            foreach (Image image in images)
            {
                Panel pb = new Panel();
                pb.AllowDrop = false;
                pb.BackgroundImage = image;
                pb.BackgroundImageLayout = ImageLayout.Zoom;

                int newWidth = 50;
                int originalHeight = image.Height;
                int originalWidth = image.Width;
                float per = (float) newWidth / originalWidth;
                int newHeight = (int) Math.Round(originalHeight * per, 0);
                pb.Width = newWidth;
                pb.Height = newHeight;

                pb.Location = location;

                pb.MouseDown += new MouseEventHandler(ImgMouseDown);

                panelModel.Controls.Add(pb);

                location.X = location.X + 110;
            }
        }

        private Point start;

        public void ImgMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                start = e.Location;
                Panel pb = (Panel)sender;
                pb.MouseUp += new MouseEventHandler(ImgMouseUp);
                pb.MouseMove += new MouseEventHandler(ImgMouseMove);
            }
        }

        public void ImgMouseUp(object sender, MouseEventArgs e)
        {
            Panel pb = (Panel)sender;
            pb.MouseUp -= new MouseEventHandler(ImgMouseUp);
            pb.MouseMove -= new MouseEventHandler(ImgMouseMove);
        }

        public void ImgMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Panel pb = (Panel)sender;
                pb.Location = new Point(pb.Location.X - (start.X - e.X), pb.Location.Y - (start.Y - e.Y));
            }
        }


        public void ClearFields()
        {
            textBoxDBServer.Text = "";
            textBoxDatabase.Text = "";
            checkBoxWindowsAuth.Checked = false;
            textBoxUsername.Text = "";
            textBoxPassword.Text = "";
            comboBoxDatabases.Items.Clear();
            comboBoxDatabases.Refresh();
            comboBoxDatabases.ResetText();
            textBoxFolderLocation.Text = "";
        }

        private void LoadExistingConnectionsDropDown()
        {
            comboBoxExistingConnections.Items.Clear();

            foreach (clsConnections connection in settings.Connections)
            {
                string item = "";

                if (connection.Server != null && connection.Database != null)
                {
                    item = connection.Server + " | " + connection.Database;
                    if (!connection.WindowsAuthentication)
                    {
                        item += " | " + connection.UserName;
                    }
                }

                comboBoxExistingConnections.Items.Add(item);
            }

            comboBoxExistingConnections.Refresh();

            typeof(ComboBox).InvokeMember("RefreshItems", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod, null, comboBoxExistingConnections, new object[] { });
        }

        private void buttonDeleteConnection_Click(object sender, EventArgs e)
        {
            settings.RemoveConnection(comboBoxExistingConnections.SelectedIndex);

            LoadExistingConnectionsDropDown();

            ClearFields();

            comboBoxExistingConnections.SelectedIndex = 0;
        }

        private void comboBoxExistingConnections_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearFields();

            if (comboBoxExistingConnections.SelectedIndex == 0)
            {
                return;
            }

            var SelectedConnection = settings.Connections[comboBoxExistingConnections.SelectedIndex];

            textBoxDBServer.Text = SelectedConnection.Server;
            textBoxDatabase.Text = SelectedConnection.Database;
            checkBoxWindowsAuth.Checked = SelectedConnection.WindowsAuthentication;
            textBoxUsername.Text = SelectedConnection.UserName;
            textBoxPassword.Text = SelectedConnection.Password;
            textBoxFolderLocation.Text = SelectedConnection.ProjectPath;

            SetConnectionString();
        }

        private void SetConnectionString()
        {
            /*
            textBoxDBServer.Text
            textBoxDatabase.Text
            checkBoxWindowsAuth.Checked
            textBoxUsername.Text
            textBoxPassword.Text
            */

            if (checkBoxWindowsAuth.Checked)
            {
                modelBuilder.connectionString = $@"Data Source={textBoxDBServer.Text};Initial Catalog={textBoxDatabase.Text};integrated security=True;";
            }
            else
            {
                modelBuilder.connectionString = $@"Data Source={textBoxDBServer.Text};Initial Catalog={textBoxDatabase.Text};User ID={textBoxUsername.Text};Password={textBoxPassword.Text}";
            }            
        }

        public void GetDatabases()
        {
            comboBoxDatabases.Items.Clear();

            string conString = "";

            if (checkBoxWindowsAuth.Checked && textBoxDBServer.Text.Length > 0)
            {
                conString = $@"Data Source={textBoxDBServer.Text};integrated security=True;";
            }
            else if(textBoxDBServer.Text.Length > 0 && textBoxUsername.Text.Length > 0 && textBoxPassword.Text.Length > 0)
            {
                conString = $@"Data Source={textBoxDBServer.Text};User ID={textBoxUsername.Text};Password={textBoxPassword.Text}";
            }
            else
            {
                CallOuts("warning", "Server and Authentication must be defined");
            }

            List<string> Databases = new List<string>();

            try
            {
                Databases = new clsGetDatabases().GetDatabases(conString);
            }
            catch (Exception)
            {
                CallOuts("warning", "Connection to DB Sever not valid");
            }

            foreach (string Database in Databases)
            {
                comboBoxDatabases.Items.Add(Database);
            }

            comboBoxDatabases.Refresh();
        }

        public void SelectedExistingConnection(int index)
        {
            comboBoxExistingConnections.SelectedIndex = index;
        }

        #region Add Server
        private void btnSaveServer_Click(object sender, EventArgs e)
        {
            SaveConnection();
        }

        public void SaveConnection()
        {
            int SelectedConnection = comboBoxExistingConnections.SelectedIndex;

            string username = null;
            string password = null;

            if (textBoxUsername.Text.Length > 0)
            {
                username = textBoxUsername.Text;
            }
            if (textBoxPassword.Text.Length > 0)
            {
                password = textBoxPassword.Text;
            }

            if (textBoxDBServer.Text.Length <= 0 || textBoxDatabase.Text.Length <= 0)
            {
                CallOuts("warning", "Connection must have a defined Server and Database");
                return;
            }
            else if (!checkBoxWindowsAuth.Checked && (username == null))
            {
                CallOuts("warning", "If Windows authentication is not being used a username must be defined");
                return;
            }

            clsConnections connection = new clsConnections();

            connection.Server = textBoxDBServer.Text;
            connection.Database = textBoxDatabase.Text;
            connection.WindowsAuthentication = checkBoxWindowsAuth.Checked;
            connection.UserName = username;
            connection.Password = password;
            if (textBoxFolderLocation.Text.Length > 0)
            {
                connection.ProjectPath = textBoxFolderLocation.Text;
            }
            else
            {
                string svr = connection.Server.Replace(@"\", "-");
                connection.ProjectPath = Path.Combine(settings.AppPath, svr + "-" + connection.Database);
            }

            if (!Directory.Exists(connection.ProjectPath))
            {
                Directory.CreateDirectory(connection.ProjectPath);
            }

            if (!Directory.Exists(Path.Combine(connection.ProjectPath, settings.ImagesPath)))
            {
                Directory.CreateDirectory(Path.Combine(connection.ProjectPath, settings.ImagesPath));
            }

            if (SelectedConnection > -1)
            {
                settings.UpdateConnection(SelectedConnection, connection);
            }
            else
            {
                SelectedConnection = settings.Connections.Count;
                settings.AddConnection(connection);
            }

            LoadExistingConnectionsDropDown();

            SelectedExistingConnection(SelectedConnection);

            SetConnectionString();
        }

        private void buttonCreateNewConnection_Click(object sender, EventArgs e)
        {
            string username = null;
            string password = null;

            if (textBoxUsername.Text.Length > 0)
            {
                username = textBoxUsername.Text;
            }
            if (textBoxPassword.Text.Length > 0)
            {
                password = textBoxPassword.Text;
            }

            if (textBoxDBServer.Text.Length <= 0 || textBoxDatabase.Text.Length <= 0)
            {
                CallOuts("warning", "Connection must have a defined Server and Database");
                return;
            }
            else if (!checkBoxWindowsAuth.Checked && (username == null))
            {
                CallOuts("warning", "If Windows authentication is not being used a username must be defined");
                return;
            }

            clsConnections connection = new clsConnections();

            connection.Server = textBoxDBServer.Text;
            connection.Database = textBoxDatabase.Text;
            connection.WindowsAuthentication = checkBoxWindowsAuth.Checked;
            connection.UserName = username;
            connection.Password = password;
            if (textBoxFolderLocation.Text.Length > 0)
            {
                connection.ProjectPath = textBoxFolderLocation.Text;
            }
            else
            {
                string svr = connection.Server.Replace(@"\", "-");
                connection.ProjectPath = Path.Combine(settings.AppPath, svr + "-" + connection.Database);
            }
            if (!Directory.Exists(connection.ProjectPath))
            {
                Directory.CreateDirectory(connection.ProjectPath);
            }
            
            if (!Directory.Exists(Path.Combine(connection.ProjectPath, settings.ImagesPath)))
            {
                Directory.CreateDirectory(Path.Combine(connection.ProjectPath, settings.ImagesPath));
            }            

            settings.AddConnection(connection);

            LoadExistingConnectionsDropDown();

            SelectedExistingConnection(settings.Connections.Count - 1);

            SetConnectionString();
        }
        #endregion

        private bool TestConnection(bool suppress)
        {
            bool validConnection = false;

            SetConnectionString();

            string username = null;
            string password = null;

            if (textBoxUsername.Text.Length > 0)
            {
                username = textBoxUsername.Text;
            }
            if (textBoxPassword.Text.Length > 0)
            {
                password = textBoxPassword.Text;
            }

            if (textBoxDBServer.Text.Length <= 0 || textBoxDatabase.Text.Length <= 0)
            {
                if (!suppress)
                {
                    CallOuts("warning", "Connection must have a defined Server and Database");
                }
            }
            else if (!checkBoxWindowsAuth.Checked && (username == null))
            {
                if (!suppress)
                {
                    CallOuts("warning", "If Windows authentication is not being used a username must be defined");
                }
            }
            else
            {
                validConnection = true;
            }

            if (validConnection && modelBuilder.ConnectionValid())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void buttonTestConnection_Click(object sender, EventArgs e)
        {
            if (TestConnection(false))
            {
                CallOuts("success", "Database Connection Successful");
            }
            else
            {
                CallOuts("warning", "Database Connection Unsuccessful");
            }
        }

        private void checkBoxWindowsAuth_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxWindowsAuth.Checked)
            {
                textBoxUsername.Text = "";
                textBoxPassword.Text = "";

                textBoxUsername.ReadOnly = true;
                textBoxPassword.ReadOnly = true;
            }
            else
            {
                textBoxUsername.ReadOnly = false;
                textBoxPassword.ReadOnly = false;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            ResizeForm();
        }

        private void timerCallOut_Tick(object sender, EventArgs e)
        {
            labelWarning.Text = "";
            labelWarning.BackColor = Color.Transparent;
            labelWarning.ForeColor = Color.Black;
            timerCallOut.Stop();
        }

        private void ResizeForm()
        {
            labelWarning.Width = MainForm.ActiveForm.Width;
            panelModel.Height = MainForm.ActiveForm.Height - panelModel.Location.Y - 50;
            panelModel.Width = MainForm.ActiveForm.Width - panelModel.Location.X - 20;
        }

        public void CallOuts(string Type, string Message)
        {
            //Type: warning, success
            labelWarning.Text = Message;

            Color Green = Color.FromArgb(30, 140, 46);
            Color Red = Color.FromArgb(198, 1, 1);

            if (Type == "warning")
            {
                labelWarning.BackColor = Red;
                labelWarning.ForeColor = Color.White;
            }
            else if (Type == "success")
            {
                labelWarning.BackColor = Green;
                labelWarning.ForeColor = Color.White;
            }
            else
            {
                labelWarning.BackColor = Color.Transparent;
                labelWarning.ForeColor = Color.Black;
            }

            timerCallOut.Start();
        }

        private void comboBoxDatabases_DropDown(object sender, EventArgs e)
        {
            GetDatabases();
        }

        private void comboBoxDatabases_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxDatabase.Text = comboBoxDatabases.SelectedItem.ToString();
        }

        private void buttonSelectFolder_Click(object sender, EventArgs e)
        {
            string newPath = textBoxFolderLocation.Text;

            if (newPath.Length <= 0)
            {
                newPath = settings.AppPath;
            }


            string selectedPath = "";
            var t = new Thread((ThreadStart)(() => {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.RootFolder = System.Environment.SpecialFolder.MyComputer;
                fbd.SelectedPath = newPath;
                fbd.ShowNewFolderButton = true;
                if (fbd.ShowDialog() == DialogResult.Cancel)
                    return;

                selectedPath = fbd.SelectedPath;
            }));

            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();

            textBoxFolderLocation.Text = selectedPath;
        }
    }
}
