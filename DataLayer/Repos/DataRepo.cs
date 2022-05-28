using DataLayer.Constants;
using DataLayer.Enums;
using DataLayer.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataLayer
{
    public sealed class DataRepo
    {
        // Settings repository

        readonly SettingsRepo SETTINGS_REPO = SettingsRepo.Instance;



        // Properties

        private IList<Match> matches = new List<Match>();
        private IList<Player> players = new List<Player>();



        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static DataRepo()
        {
        }

        private DataRepo()
        {
        }

        public static DataRepo Instance { get; } = new DataRepo();



        // Get teams

        public Task<IList<TeamDetails>> GetTeams()
        {

            return Task.Run(() =>
            {
                switch (SETTINGS_REPO.Championship.ToLower())
                {
                    case "female":
                        return GetTeamsFromEndpointOrFile(
                           ApiConstants.FEMALE_TEAMS_ENDPOINT,
                           ApiConstants.FEMALE_TEAMS_FILE_PATH);
                    default:
                        return GetTeamsFromEndpointOrFile(
                            ApiConstants.MALE_TEAMS_ENDPOINT,
                            ApiConstants.MALE_TEAMS_FILE_PATH);
                }
            });
        }


        private IList<TeamDetails> GetTeamsFromEndpointOrFile(string endpoint, string filePath)
        {
            try
            {
                var teams = GetTeamsFromEndpoint(endpoint);
                if (teams != null)
                {
                    return teams;
                }
                else
                {
                    return GetTeamsFromFile(filePath);
                }
            }
            catch (Exception)
            {
                return GetTeamsFromFile(filePath);
            }
        }

        private IList<TeamDetails> GetTeamsFromEndpoint(string endpoint)
        {
            var apiClient = new RestClient(endpoint);
            var apiResult = apiClient.Execute<IList<TeamDetails>>(new RestRequest());
            return TeamDetails.FromJson(apiResult.Content);
        }

        private IList<TeamDetails> GetTeamsFromFile(string filePath)
            => TeamDetails.FromJson(File.ReadAllText(filePath));



        // Get players

        public Task<IList<Player>> GetPlayers()
        {
            return Task.Run(async () =>
            {
                switch (SETTINGS_REPO.Championship.ToLower())
                {
                    case "female":
                        players = await GetPlayersFromEndpointOrFileAsync();
                        return players;
                    default:
                        players = await GetPlayersFromEndpointOrFileAsync();
                        return players;
                }
            });
        }


        private async Task<IList<Player>> GetPlayersFromEndpointOrFileAsync()
        {
            await GetMatches();
            return GetPlayersFromMatch(matches.First());
        }

        private IList<Player> GetPlayersFromMatch(Match match)
        {
            TeamStatistics teamStatistics = new TeamStatistics();

            if (match.HomeTeam.Code.ToUpper() == SETTINGS_REPO.FavoriteTeamCode.ToUpper())
            {
                teamStatistics = match.HomeTeamStatistics;
            }
            else
            {
                teamStatistics = match.AwayTeamStatistics;
            }

            IList<Player> players = new List<Player>(teamStatistics.StartingEleven);

            teamStatistics.Substitutes.ToList().ForEach(player =>
            {
                players.Add(player);
            });

            return players;
        }



        // Get players ranked by type of event

        public IDictionary<Player, int> GetPlayersRankedByTypeOfEvent(TypeOfEvent typeOfEvent)
        {
            IDictionary<Player, int> playersRanks = new Dictionary<Player, int>();

            foreach (var match in matches)
            {
                IList<TeamEvent> teamEvents;

                if (match.HomeTeam.Code.ToUpper() == SETTINGS_REPO.FavoriteTeamCode.ToUpper())
                {
                    teamEvents = match.HomeTeamEvents;
                }
                else
                {
                    teamEvents = match.AwayTeamEvents;
                }

                foreach (var teamEvent in teamEvents)
                {
                    if (teamEvent.TypeOfEvent == typeOfEvent)
                    {
                        try
                        {
                            Player player = players.ToList().Find(p => p.Name == teamEvent.Player);

                            if (!playersRanks.ContainsKey(player))
                            {
                                playersRanks.Add(player, 1);
                            }
                            else
                            {
                                playersRanks.TryGetValue(player, out int numberOfGoals);
                                playersRanks.Remove(player);
                                playersRanks.Add(player, numberOfGoals + 1);
                            }
                        }
                        catch (Exception)
                        {

                        }
                    }
                }

            }

            return playersRanks;
        }



        // Get matches

        public Task<IList<Match>> GetMatches()
        {
            return Task.Run(() =>
            {
                switch (SETTINGS_REPO.Championship.ToLower())
                {
                    case "female":
                        matches = GetMatchesFromEndpointOrFile(
                            ApiConstants.FEMALE_MATCHES_ENDPOINT + SETTINGS_REPO.FavoriteTeamCode.ToUpper(),
                            ApiConstants.FEMALE_MATCHES_FILE_PATH);
                        return matches;
                    default:
                        matches = GetMatchesFromEndpointOrFile(
                            ApiConstants.MALE_MATCHES_ENDPOINT + SETTINGS_REPO.FavoriteTeamCode.ToUpper(),
                            ApiConstants.MALE_MATCHES_FILE_PATH);
                        return matches;
                }
            });
        }

        private IList<Match> GetMatchesFromEndpointOrFile(string endpoint, string filePath)
        {
            try
            {
                var matches = GetMatchesFromEndpoint(endpoint);
                if (matches != null)
                {
                    return matches;
                }
                else
                {
                    return GetMatchesFromFile(filePath);
                }
            }
            catch (Exception)
            {
                return GetMatchesFromFile(filePath);
            }
        }

        private IList<Match> GetMatchesFromEndpoint(string endpoint)
        {
            var apiClient = new RestClient(endpoint);
            var apiResult = apiClient.Execute<IList<Match>>(new RestRequest());
            return Match.FromJson(apiResult.Content);
        }

        private IList<Match> GetMatchesFromFile(string filePath)
        {
            var allMatches = Match.FromJson(File.ReadAllText(filePath));
            IList<Match> matches = new List<Match>();

            allMatches.ToList().ForEach(match =>
            {
                if (match.HomeTeam.Code.ToUpper() == SETTINGS_REPO.FavoriteTeamCode.ToUpper() ||
                    match.AwayTeam.Code.ToUpper() == SETTINGS_REPO.FavoriteTeamCode.ToUpper())
                {
                    matches.Add(match);
                }
            });

            return matches;
        }


        // Get player number of events

        public int GetNumberOfEventsForPlayerInMatch(Match match, Team team, Player player, TypeOfEvent typeOfEvent)
        {
            IList<TeamEvent> teamEvents;

            if (match.HomeTeam.Code.ToUpper() == team.Code.ToUpper())
            {
                teamEvents = match.HomeTeamEvents;
            }
            else
            {
                teamEvents = match.AwayTeamEvents;
            }

            int numberOfEvents = 0;

            foreach (var teamEvent in teamEvents)
            {
                if (teamEvent.TypeOfEvent == typeOfEvent && teamEvent.Player.ToLower() == player.Name.ToLower())
                {
                    numberOfEvents++;
                }
            }

            return numberOfEvents;
        }
    }
}
