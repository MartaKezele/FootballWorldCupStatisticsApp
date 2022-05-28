using DataLayer.Constants;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public sealed class SettingsRepo
    {
        // Properties

        public string Language { get; set; }
        public string Championship { get; set; }
        public string FavoriteTeamCode { get; set; }
        public string OpposingTeamCode { get; set; }

        private readonly IList<Player> favoritePlayers = new List<Player>();
        public IList<Player> FavoritePlayers { get => favoritePlayers; }

        private readonly IDictionary<Player, string> playerPictures = new Dictionary<Player, string>();
        public IDictionary<Player, string> PlayerPictures { get => playerPictures; }

        public double MainWindowWidth { get; set; }
        public double MainWindowHeight { get; set; }


        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static SettingsRepo()
        {
        }

        private SettingsRepo()
        {
            if (File.Exists(SettingsConstants.SETTINGS_FILE_PATH))
            {
                var settings = ReadSettingsFile();
                if (settings != null)
                {
                    settings.ToList().ForEach(line =>
                    {
                        if (CheckSetting(SettingsConstants.LANGUGAE_IDENTIFIER, line))
                        {
                            Language = GetSettingFromLine(SettingsConstants.LANGUGAE_IDENTIFIER, line).ToLower();
                        }
                        else if (CheckSetting(SettingsConstants.CHAMPIONSHIP_IDENTIFIER, line))
                        {
                            Championship = GetSettingFromLine(SettingsConstants.CHAMPIONSHIP_IDENTIFIER, line).ToLower();
                        }
                        else if (CheckSetting(SettingsConstants.FAVORITE_TEAM_IDENTIFIER, line))
                        {
                            FavoriteTeamCode = GetSettingFromLine(SettingsConstants.FAVORITE_TEAM_IDENTIFIER, line).ToUpper();
                        }
                        else if (CheckSetting(SettingsConstants.FAVORITE_PLAYER_IDENTIFIER, line))
                        {
                            var playerString = GetSettingFromLine(SettingsConstants.FAVORITE_PLAYER_IDENTIFIER, line);
                            var player = Player.GetPlayerFromString(playerString);
                            if (!FavoritePlayers.Contains(player))
                            {
                                FavoritePlayers.Add(player);
                            }
                        }
                        else if (CheckSetting(SettingsConstants.PLAYER_PICTURE_IDENTIFIER, line))
                        {
                            var playerPathString = GetSettingFromLine(SettingsConstants.PLAYER_PICTURE_IDENTIFIER, line);
                            AddPlayerPicturePath(Player.GetPlayerFromString(playerPathString), GetPicturePathFromLine(playerPathString));
                        }
                        else if (CheckSetting(SettingsConstants.MAIN_WINDOW_WIDTH_IDENTIFIER, line))
                        {
                            if (int.TryParse(GetSettingFromLine(SettingsConstants.MAIN_WINDOW_WIDTH_IDENTIFIER, line), out int width))
                            {
                                MainWindowWidth = width;
                            }
                        }
                        else if (CheckSetting(SettingsConstants.MAIN_WINDOW_HEIGHT_IDENTIFIER, line))
                        {
                            if (int.TryParse(GetSettingFromLine(SettingsConstants.MAIN_WINDOW_HEIGHT_IDENTIFIER, line), out int height))
                            {
                                MainWindowHeight = height;
                            }
                        }
                        else if (CheckSetting(SettingsConstants.OPPOSING_TEAM_IDENTIFIER, line))
                        {
                            OpposingTeamCode = GetSettingFromLine(SettingsConstants.OPPOSING_TEAM_IDENTIFIER, line).ToUpper();
                        }
                    });
                }
            }
        }

        public static SettingsRepo Instance { get; } = new SettingsRepo();



        // Private methods

        private IList<string> ReadSettingsFile()
        {
            var settings = File.ReadAllLines(SettingsConstants.SETTINGS_FILE_PATH);

            IList<string> validSettings = new List<string>();
            settings.ToList().ForEach(line =>
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    validSettings.Add(line.Trim());
                }
            });

            return validSettings;
        }

        private bool CheckSetting(string settingIdentifier, string line)
            => line.Length >= settingIdentifier.Length && line.Substring(0, settingIdentifier.Length).ToLower() == settingIdentifier.ToLower();

        private string GetSettingFromLine(string settingIdentfier, string line)
            => line.Substring(settingIdentfier.Length).Trim();

        private void CreateSettingsFileIfNonExistent()
        {
            if (!File.Exists(SettingsConstants.SETTINGS_FILE_PATH))
            {
                File.Create(SettingsConstants.SETTINGS_FILE_PATH).Close();
            }
        }

        private string GetPicturePathFromLine(string line)
        {
            string[] details = line.Split(SettingsConstants.PLAYER_DETAILS_SEPARATOR);
            return details[4];
        }



        // Public methods

        public bool ValidForWindowsFormsApp()
            => File.Exists(SettingsConstants.SETTINGS_FILE_PATH) && HasAllInfoForWindowsFormsApp();

        public bool ValidForWpfApp()
            => File.Exists(SettingsConstants.SETTINGS_FILE_PATH) && HasAllInfoForWpfApp();

        public bool HasAllInfoForWindowsFormsApp()
            => !string.IsNullOrWhiteSpace(Language) &&
               !string.IsNullOrWhiteSpace(Championship);

        public bool HasAllInfoForWpfApp()
            => !string.IsNullOrWhiteSpace(Language) &&
               !string.IsNullOrWhiteSpace(Championship) &&
               MainWindowWidth != default &&
               MainWindowHeight != default;

        public void SaveSettings()
        {
            IList<string> settings = new List<string>();

            // Language
            if (!string.IsNullOrWhiteSpace(Language))
            {
                settings.Add(SettingsConstants.LANGUGAE_IDENTIFIER + Language.ToLower());
            }

            // Championship
            if (!string.IsNullOrWhiteSpace(Championship))
            {
                settings.Add(SettingsConstants.CHAMPIONSHIP_IDENTIFIER + Championship.ToLower());
            }

            // Favorite team
            if (!string.IsNullOrWhiteSpace(FavoriteTeamCode))
            {
                settings.Add(SettingsConstants.FAVORITE_TEAM_IDENTIFIER + FavoriteTeamCode.ToUpper());
            }

            // Favorite players
            if (FavoritePlayers != null && FavoritePlayers.Count() > 0)
            {
                FavoritePlayers.ToList().ForEach(player =>
                {
                    settings.Add(SettingsConstants.FAVORITE_PLAYER_IDENTIFIER + player);
                });
            }

            //Player picture paths
            if (PlayerPictures != null && PlayerPictures.Count() > 0)
            {
                foreach (var item in PlayerPictures)
                {
                    settings.Add(SettingsConstants.PLAYER_PICTURE_IDENTIFIER + item.Key + SettingsConstants.PLAYER_DETAILS_SEPARATOR + item.Value);
                }
            }

            // Main window width
            if (MainWindowWidth != default)
            {
                settings.Add(SettingsConstants.MAIN_WINDOW_WIDTH_IDENTIFIER + MainWindowWidth);
            }

            // Main window height
            if (MainWindowHeight != default)
            {
                settings.Add(SettingsConstants.MAIN_WINDOW_HEIGHT_IDENTIFIER + MainWindowHeight);
            }

            // Opposing team
            if (!string.IsNullOrWhiteSpace(OpposingTeamCode))
            {
                settings.Add(SettingsConstants.OPPOSING_TEAM_IDENTIFIER + OpposingTeamCode.ToUpper());
            }

            CreateSettingsFileIfNonExistent();
            File.WriteAllLines(SettingsConstants.SETTINGS_FILE_PATH, settings);
        }

        public void AddFavoritePlayer(Player player)
        {
            if (!favoritePlayers.Contains(player))
            {
                favoritePlayers.Add(player);
            }
        }

        public void RemoveFavoritePlayer(Player player)
        {
            if (favoritePlayers.Contains(player))
            {
                favoritePlayers.Remove(player);
            }
        }

        public void AddPlayerPicturePath(Player player, string picturePath)
        {
            if (PlayerPictures.Count() > 0)
            {
                if (PlayerPictures.ContainsKey(player))
                {
                    PlayerPictures.Remove(player);
                }
            }

            PlayerPictures.Add(player, picturePath);
        }
    }
}
