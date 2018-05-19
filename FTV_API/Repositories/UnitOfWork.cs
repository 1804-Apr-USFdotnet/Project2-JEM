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
        }

        public IUserRepository Users { get; }
//        public IUserRepository FollowedPlayers { get; private set; }

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