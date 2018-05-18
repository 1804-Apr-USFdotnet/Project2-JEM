using System.Data.Entity.Migrations;

namespace FTV.DAL.Migrations
{
    public partial class updateModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("FTV.Followed Player", "UserId", c => c.Int(false));
            CreateIndex("FTV.Followed Player", "UserId");
            AddForeignKey("FTV.Followed Player", "UserId", "FTV.User", "Id", true);
            DropColumn("FTV.Followed Player", "FollowerId");
        }

        public override void Down()
        {
            AddColumn("FTV.Followed Player", "FollowerId", c => c.Int(false));
            DropForeignKey("FTV.Followed Player", "UserId", "FTV.User");
            DropIndex("FTV.Followed Player", new[] {"UserId"});
            DropColumn("FTV.Followed Player", "UserId");
        }
    }
}