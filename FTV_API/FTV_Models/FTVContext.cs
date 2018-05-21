using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using FTV.DAL.Models;

namespace FTV.DAL
{
    public class FTVContext : DbContext, IDbContext
    {
        public FTVContext()
            : base("name=FTVContext")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<FollowedPlayer> FollowedPlayers { get; set; }

        public override int SaveChanges()
        {
            var addedEntities = ChangeTracker.Entries().Where(E => E.State == EntityState.Added).ToList();

            addedEntities.ForEach(E =>
            {
                E.Property("Created").CurrentValue = DateTime.Now;
                E.Property("Modified").CurrentValue = DateTime.Now;
            });

            var modifiedEntities = ChangeTracker.Entries().Where(E => E.State == EntityState.Modified).ToList();

            modifiedEntities.ForEach(E => { E.Property("Modified").CurrentValue = DateTime.Now; });
            return base.SaveChanges();
        }

        IDbSet<TEntity> IDbContext.Set<TEntity>()
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}