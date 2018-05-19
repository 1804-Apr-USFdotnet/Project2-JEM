using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FTV.DAL;
using FTV.DAL.Models;

namespace Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }

        public FTVContext FTVContext => Context as FTVContext;

        public User GetFirstUser()
        {
            return FTVContext.Users.Find(0);
        }

        public IEnumerable<User> GetTopFollowedPlayers()
        {
//            return FTVContext.Users.
            return null;
        }

        public IEnumerable<User> GetUsersWithFollowedPlayers(int pageIndex = 0, int pageSize = 10)
        {
            return FTVContext.Users
                .Include(c => c.FollowedPlayers)
                .OrderBy(c => c.FollowedPlayers.Count)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }
    }
}