using System.Data.Entity;
using FTV.DAL;
using FTV.DAL.Models;

namespace Repositories
{
    public class FollowedPlayerRepository : Repository<FollowedPlayer>, IFollowedPlayerRepository
    {
        public FollowedPlayerRepository(DbContext context) : base(context)
        {
        }

        public FTVContext FTVContext => Context as FTVContext;
    }
}