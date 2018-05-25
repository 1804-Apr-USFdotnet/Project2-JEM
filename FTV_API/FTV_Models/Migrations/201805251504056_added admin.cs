namespace FTV.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedadmin : DbMigration
    {
        public override void Up()
        {
            AddColumn("FTV.User", "Admin", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("FTV.User", "Admin");
        }
    }
}
