using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleDatabaseReplicator.Util
{
    public class Settings
    {
        public static string SettingsFile = "settings.json";
        public static Settings Default = new Settings();


        static Settings()
        {
            SettingsFile = Path.Combine(new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName, SettingsFile);
        }
        public static void Save()
        {
            File.WriteAllText(SettingsFile, JsonSerializer.Serialize(Default));
        }
        public static void Load()
        {
            if (!File.Exists(SettingsFile))
            {
                return;
            }

            Default = JsonSerializer.Deserialize<Settings>(File.ReadAllText(SettingsFile));
            if (Default.Culture != null)
            {
            var culture = CultureInfo.GetCultureInfoByIetfLanguageTag(Default.Culture);
                System.Threading.Thread.CurrentThread.CurrentCulture = culture;
                System.Threading.Thread.CurrentThread.CurrentUICulture = culture;
            }
        }
        public List<ReplicationTaskInfo> ReplicationTasks { get; set; } = new List<ReplicationTaskInfo>();
        public DateTime MinDateTime = new DateTime(1800, 1, 1);

        public int SplitterDistance { get; set; }
        public int ColumnWidthJobName { get; set; }
        public int ColumnWidthStatus { get; set; }

        public int ColumnWidthProgress { get; set; }
        public string Culture { get; set; }
    }
}