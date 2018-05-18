namespace FTV.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FTVContext : DbContext
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
