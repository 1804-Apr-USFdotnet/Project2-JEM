using System.Data.Entity.Migrations;

namespace FTV.DAL.Migrations
{
    public partial class ItToldMeToUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("FTV.User", "Password", c => c.String(false, 64));
        }

        public override void Down()
        {
            AlterColumn("FTV.User", "Password", c => c.String(false));
        }
    }
}