namespace FTV.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class readdedconstraints : DbMigration
    {
        public override void Up()
        {
            AlterColumn("FTV.User", "FirstName", c => c.String(nullable: false));
            AlterColumn("FTV.User", "LastName", c => c.String(nullable: false));
            AlterColumn("FTV.User", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("FTV.User", "Email", c => c.String());
            AlterColumn("FTV.User", "LastName", c => c.String());
            AlterColumn("FTV.User", "FirstName", c => c.String());
        }
    }
}
