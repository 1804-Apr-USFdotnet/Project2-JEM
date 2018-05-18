using System.Data.Entity;
using FTV.DAL.Models;

namespace FTV.DAL
{
    public class FTVContext : DbContext
    {
        public FTVContext()
            : base("name=FTVContext")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<FollowedPlayer> FollowedPlayers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}