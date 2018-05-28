using FTV.DAL;

namespace Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FTVContext _context;

        public UnitOfWork(FTVContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
            Comments = new CommentRepository(_context);
            FollowedPlayers = new FollowedPlayerRepository(_context);
        }

        public IFollowedPlayerRepository FollowedPlayers { get; }
        public ICommentRepository Comments { get; }
        public IUserRepository Users { get; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}