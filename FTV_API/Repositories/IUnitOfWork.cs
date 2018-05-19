using System;

namespace Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
//        IFollowedPlayerRepository FollowedPlayers { get; }
        int Complete();
    }
}