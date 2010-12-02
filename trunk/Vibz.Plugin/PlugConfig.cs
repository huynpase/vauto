using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Configuration;
using System.Reflection;
using Vibz.Contract.Log;

namespace Vibz.Plugin
{
    internal class PlugConfig
    {
        public string RootFolder;
        public string RegFile;
        public string NodePath;
    }
    internal class PlugManager
    {
        PlugManager() { }
        public static PlugConfig GetConfig()
        {
            System.Configuration.Configuration config = ApplicationConfig;

            AppSettingsSection section = (AppSettingsSection)config.GetSection("appSettings");
            if (section.Settings["pluginRoot"] == null)
                throw new Exception("'pluginRoot' node is missing in Plugin configurations.");
            string rootFolder = section.Settings["pluginRoot"].Value;
            return GetConfig(rootFolder);
        }
        internal static PlugConfig GetConfig(string rootFolder)
        {
            PlugConfig pconfig = new PlugConfig();
            System.Configuration.Configuration config = ApplicationConfig;

            AppSettingsSection section = (AppSettingsSection)config.GetSection("appSettings");

            pconfig.RootFolder = rootFolder;
            if (section.Settings["registrationFile"] == null)
                throw new Exception("'registrationFile' node is missing in Plugin configurations.");
            pconfig.RegFile = section.Settings["registrationFile"].Value;
            if (section.Settings["nodePath"] == null)
                throw new Exception("'nodePath' node is missing in Plugin configurations.");
            pconfig.NodePath = section.Settings["nodePath"].Value;
            return pconfig;
        }
        static System.Configuration.Configuration ApplicationConfig
        {
            get
            {
                ExeConfigurationFileMap configFile = new ExeConfigurationFileMap();
                string exeFilePath = Vibz.Reflection.Runtime.GetAbsolutePath(Assembly.GetExecutingAssembly().ManifestModule.Name + ".config");

                if (!File.Exists(exeFilePath))
                    throw new Exception("Plugin Config file not found.");
                configFile.ExeConfigFilename = exeFilePath;

                System.Configuration.Configuration config =
                    ConfigurationManager.OpenMappedExeConfiguration(configFile,
                    ConfigurationUserLevel.None);

                if (config == null)
                    throw new Exception("Unable to access Plugin configurations.");

                return config;
            }
        }
    }
}
