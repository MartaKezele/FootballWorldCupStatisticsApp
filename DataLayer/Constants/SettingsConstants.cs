using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Constants
{
    public static class SettingsConstants
    {
        // Settings file path
        public static string SETTINGS_FILE_PATH = GetSettingsFilePath();

        // Setting identifiers
        public const string LANGUGAE_IDENTIFIER = "language:";
        public const string CHAMPIONSHIP_IDENTIFIER = "championship:";
        public const string FAVORITE_TEAM_IDENTIFIER = "favorite team:";
        public const string FAVORITE_PLAYER_IDENTIFIER = "favorite player:";
        public const string PLAYER_PICTURE_IDENTIFIER = "player:";
        public const string MAIN_WINDOW_WIDTH_IDENTIFIER = "main window width:";
        public const string MAIN_WINDOW_HEIGHT_IDENTIFIER = "main window height:";
        public const string OPPOSING_TEAM_IDENTIFIER = "opposing team:";


        // Default settings values
        public const string DEFAULT_LANGUAGE = "en";
        public const string DEFAULT_CHAMPIONSHIP = "male";

        // Separators
        public const char PLAYER_DETAILS_SEPARATOR = ',';

        private static string GetSettingsFilePath()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string solutionDirectory = Directory.GetParent(currentDirectory).Parent.Parent.FullName;
            var projectDirectories = Directory.GetDirectories(solutionDirectory);
            for (int i = 0; i < projectDirectories.Length; i++)
            {
                if (projectDirectories[i].EndsWith("DataLayer"))
                {
                    var dataLayerDirectories = Directory.GetDirectories(projectDirectories[i]);
                    for (int j = 0; j < dataLayerDirectories.Length; j++)
                    {
                        if (dataLayerDirectories[j].EndsWith("AppData"))
                        {
                            return dataLayerDirectories[j] + @"/settings.txt";
                        }
                    }

                    Directory.CreateDirectory(projectDirectories[i] + @"/AppData");
                    return projectDirectories[i] + @"/AppData" + @"/settings.txt";
                }
            }
            return null;
        }
    }
}
