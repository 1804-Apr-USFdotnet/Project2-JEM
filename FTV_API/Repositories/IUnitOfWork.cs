using System;

namespace Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        ICommentRepository Comments { get; }
        IFollowedPlayerRepository FollowedPlayers { get; }
        
        int Complete();
    }
}