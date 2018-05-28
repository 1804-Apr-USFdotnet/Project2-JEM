using System.Data.Entity;
using FTV.DAL;
using FTV.DAL.Models;

namespace Repositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(DbContext context) : base(context)
        {
        }

        public FTVContext FTVContext => Context as FTVContext;
    }
}