namespace FTV.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ItToldMeToUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("FTV.User", "Password", c => c.String(nullable: false, maxLength: 64));
        }
        
        public override void Down()
        {
            AlterColumn("FTV.User", "Password", c => c.String(nullable: false));
        }
    }
}
