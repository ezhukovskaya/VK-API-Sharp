using System;
using System.IO;

namespace VK.Application.Constants.Paths
{
    public static class FilePathConstants
    {
        private static readonly string CurrentProjectPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        public static readonly string TestConfigurationPath = CurrentProjectPath + "/Application/Configuration/config.xml";
        public static readonly string AppConfigurationPath = CurrentProjectPath + "/Application/Configuration/application.xml";
    }
}