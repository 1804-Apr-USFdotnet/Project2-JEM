using System.Collections.Generic;
using FTV.DAL.Models;

namespace Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetFirstUser();
        IEnumerable<User> GetTopFollowedPlayers();
        IEnumerable<User> GetUsersWithFollowedPlayers(int pageIndex, int pageSize);
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