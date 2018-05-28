using FortniteApi;
using FortniteApi.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FortniteApi.Response;

namespace ForniteApi
{
    public class FortniteApi
    {
        public static async Task<FortnitePlayer> GetPlayerData(string username)
        {
            ProfileResponse response;
            using (FortniteClient client = new FortniteClient("bb93b0a2-0a92-4969-89aa-5180e589a065"))
            {
                response = await client.FindPlayerAsync(Platform.Pc, username);
            }
            return new FortnitePlayer(response);
        }
    }

    public class FortnitePlayer
    {
        public string Username { get; set; }
        public string Platform { get; set; }
        public List<KeyValuePair<string, string>> LifeTimeStats { get; set; }
        public List<Match> RecentMatches { get; set; }

        public FortnitePlayer(ProfileResponse data)
        {
            PopulateData(data);
        }

        private void PopulateData(ProfileResponse data)
        {
            Username = data.EpicUserHandle;
            Platform = data.PlatformNameLong;
            LifeTimeStats = new List<KeyValuePair<string, string>>();
            
            foreach (var stat in data.LifeTimeStats)
            {
                LifeTimeStats.Add(new KeyValuePair<string, string>(stat.Key, stat.Value));
            }

            RecentMatches = new List<Match>();
            foreach (var stat in data.RecentMatches)
            {
                RecentMatches.Add(new Match(stat));
            }
        }

        public class Match
        {
            private int Matches { get; set; }
            public int Kills { get; set; }
            public int Score { get; set; }
            public double Rating { get; set; }
            public double RatingChange { get; set; }
            public string Composition { get; set; }
            public int Top1 { get; set; }
            public int Top3 { get; set; }
            public int Top5 { get; set; }

            public Match(ProfileMatch stats)
            {
                Matches = stats.Matches;
                Kills = stats.Kills;
                Score = stats.Score;
                Rating = stats.TrnRating;
                RatingChange = stats.TrnRatingChange;
                Composition = stats.Playlist;
                Top1 = stats.Top1;
                Top3 = stats.Top3;
                Top5 = stats.Top5;
            }
        }
    }
}

/* 
 Stats worth it
     PlatformId
     PlatformName
     EpicUserHandle
     LifeTimeStats
         0
             Key
             Value
         ...
         7
             Key: //Matches played
         8
             Key: //Wins
         9
             Key: //Win%
         10
             Key: //kills
         11
             Key: // k/d

    RecentMatches: // Needed to turn into a dataTable
        0:
            Playlist //Type of gamemode(solo/duo/squad)
            Kills
            DateCollected
            Platform
            Matches //# of matches on this day
            Scored

     P2: // global Duo stats
         kd:
             ValueDec
             Rank
             Percentile
         winRatio:
             ValueDec
             Rank
             Percentile
         matches:
             ValueInt
             Percentile
         kills:
             valueInt
         kpg: 
             Label //kills per game
             ValueInt
         top1:
             ValueInt
 */
