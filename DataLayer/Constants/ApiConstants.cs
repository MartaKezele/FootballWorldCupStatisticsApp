using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Constants
{
    public static class ApiConstants
    {
        // ENDPOINT URLS

        // Teams
        public const string MALE_TEAMS_ENDPOINT = "https://world-cup-json-2018.herokuapp.com/teams/results";
        public const string FEMALE_TEAMS_ENDPOINT = "http://worldcup.sfg.io/teams/results";

        // Players & Matches
        public const string MALE_MATCHES_ENDPOINT = "https://world-cup-json-2018.herokuapp.com/matches/country?fifa_code=";
        public const string FEMALE_MATCHES_ENDPOINT = "http://worldcup.sfg.io/matches/country?fifa_code=";



        // FILE PATHS

        //Teams
        public static string MALE_TEAMS_FILE_PATH = GetDataLayerFolderPath() + @"\WorldCup_Resources\Men\results.json";
        public static string FEMALE_TEAMS_FILE_PATH = GetDataLayerFolderPath() + @"\WorldCup_Resources\Women\results.json";

        // Players & Matches
        public static string MALE_MATCHES_FILE_PATH = GetDataLayerFolderPath() + @"\WorldCup_Resources\Men\matches.json";
        public static string FEMALE_MATCHES_FILE_PATH = GetDataLayerFolderPath() + @"\WorldCup_Resources\Women\matches.json";

        private static string GetDataLayerFolderPath()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string solutionDirectory = Directory.GetParent(currentDirectory).Parent.Parent.FullName;
            var projectDirectories = Directory.GetDirectories(solutionDirectory);
            for (int i = 0; i < projectDirectories.Length; i++)
            {
                if (projectDirectories[i].EndsWith("DataLayer"))
                {
                    return projectDirectories[i];
                }
            }
            return null;
        }
    }
}
