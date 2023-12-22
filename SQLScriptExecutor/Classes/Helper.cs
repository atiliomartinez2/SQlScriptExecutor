using Microsoft.Win32;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace SQLScriptExecutor.Classes
{
    public static class Helper
    {
        const string CONFIG_NAME = "SQLScriptExecutor.config";
        const string REGISTRY_KEY = @"SOFTWARE\SQLScriptExecutor";
        #region Registry methods
        public static void RegistrySetValue(string key, object value)
        {
            RegistryKey currRegistryKey = Registry.CurrentUser.CreateSubKey(REGISTRY_KEY);
            if (currRegistryKey != null)
            {
                currRegistryKey.SetValue(key, value);
                currRegistryKey.Close();
            }
        }

        public static object RegistryGetValue(string key)
        {
            object val = null;

            RegistryKey currRegistryKey = Registry.CurrentUser.CreateSubKey(REGISTRY_KEY);
            if (currRegistryKey != null)
            {
                val = currRegistryKey.GetValue(key);
                currRegistryKey.Close();
            }
            if (val == null)
                val = "";
            return val;
        }

        public static ExecutionSqlCmdResult ExecuteSqlCmd(string command)
        {
            ProcessStartInfo sqlCmdInfo = new ProcessStartInfo()
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                Arguments = command,
                FileName = "sqlcmd",
                StandardErrorEncoding = Encoding.UTF8,
                StandardOutputEncoding = Encoding.UTF8,
            };

            using (Process sqlCmdProcess = new Process())
            {
                sqlCmdProcess.StartInfo = sqlCmdInfo;
                sqlCmdProcess.Start();

                StringBuilder sbOut = new StringBuilder();
                StringBuilder sbErr = new StringBuilder();

                sqlCmdProcess.OutputDataReceived += (sender, e) => {
                    if (e.Data != null)
                        sbOut.Append(e.Data);
                };

                sqlCmdProcess.ErrorDataReceived += (sender, e) => {
                    if (e.Data != null)
                        sbErr.Append(e.Data);
                };

                sqlCmdProcess.BeginErrorReadLine();
                sqlCmdProcess.BeginOutputReadLine();

                sqlCmdProcess.WaitForExit();

                return new ExecutionSqlCmdResult(sbOut.ToString(), sbErr.ToString(), sqlCmdProcess.ExitCode);
            }
        }

        #endregion
        #region Settings methods
        public static AppSettings LoadSettings()
        {
            AppSettings settings = new AppSettings();
            var path = Path.Combine(Directory.GetCurrentDirectory(), CONFIG_NAME);
            if (File.Exists(path))
            {
                settings = LoadSettingsFromFile(path);
            }
            
            return settings;
        }
        private static AppSettings LoadSettingsFromFile(string path)
        {
            AppSettings settings = new AppSettings();
            StreamReader reader = new StreamReader(path);
            var serializer = new XmlSerializer(typeof(AppSettings));
            settings = (AppSettings)serializer.Deserialize(reader);
            reader.Close();
            return settings;
        }
        public static void SaveSettings(AppSettings settings)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), CONFIG_NAME);
            XmlSerializer x = new XmlSerializer(typeof(AppSettings));
            TextWriter writer = new StreamWriter(path, false);
            x.Serialize(writer, settings);
            writer.Close();

        }
        #endregion
    }
}
