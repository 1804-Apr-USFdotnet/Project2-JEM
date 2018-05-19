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