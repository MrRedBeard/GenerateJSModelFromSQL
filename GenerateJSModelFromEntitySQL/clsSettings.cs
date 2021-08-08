using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GenerateJSModelFromSQL
{
    public class clsSettings
    {
        public string AppPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public string SettingsPath { get; set; }
        public string ImagesPath { get; set; }
        public List<clsConnections> Connections { get; set; }

        public clsSettings()
        {
            CreateDefaults();
            LoadSettings();
        }

        public void CreateDefaults()
        {
            SettingsPath = Path.Combine(AppPath, "settings.ini");

            ImagesPath = "ModelImages";
            //if (!Directory.Exists(ImagesPath))
            //{
            //    Directory.CreateDirectory(ImagesPath);
            //}
        }

        public void LoadSettings()
        {
            Connections = new List<clsConnections>();

            if (!File.Exists(SettingsPath))
            {
                Connections.Add(new clsConnections());

                string jsonString = JsonConvert.SerializeObject(Connections);

                StreamWriter sw = new StreamWriter(SettingsPath);
                sw.Write(jsonString);
                sw.Close();
                sw.Dispose();
            }
            else
            {
                var settingsString = File.ReadAllText(SettingsPath);
                Connections = JsonConvert.DeserializeObject<List<clsConnections>>(settingsString);
            }

            List<clsConnections> validConnections = Connections.Where(x => x.Server != null && x.Database != null).ToList();

            Connections = new List<clsConnections>();

            clsConnections blankConnection = new clsConnections();
            blankConnection.Server = null;
            blankConnection.Database = null;
            Connections.Add(blankConnection);

            Connections.AddRange(validConnections);

            SaveSettings();
        }

        public void SaveSettings()
        {
            string jsonString = JsonConvert.SerializeObject(Connections);

            StreamWriter sw = new StreamWriter(SettingsPath);
            sw.Write(jsonString);
            sw.Close();
            sw.Dispose();
        }

        public void AddConnection(clsConnections connection)
        {
            Connections.Add(connection);

            SaveSettings();
        }

        public void UpdateConnection(int connectionIndex, clsConnections connection)
        {
            Connections[connectionIndex] = connection;

            SaveSettings();
        }

        public void RemoveConnection(int connectionIndex)
        {
            if (connectionIndex > 0)
            {
                Connections.RemoveAt(connectionIndex);
                SaveSettings();
            }
        }
    }

    public class clsConnections
    {
        public string Server { get; set; }
        public string Database { get; set; }
        public bool WindowsAuthentication { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ProjectPath { get; set; }
    }
}
