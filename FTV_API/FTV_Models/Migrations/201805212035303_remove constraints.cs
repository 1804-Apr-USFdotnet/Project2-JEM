namespace FTV.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeconstraints : DbMigration
    {
        public override void Up()
        {
            AlterColumn("FTV.User", "FirstName", c => c.String());
            AlterColumn("FTV.User", "LastName", c => c.String());
            AlterColumn("FTV.User", "Email", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("FTV.User", "Email", c => c.String(nullable: false));
            AlterColumn("FTV.User", "LastName", c => c.String(nullable: false));
            AlterColumn("FTV.User", "FirstName", c => c.String(nullable: false));
        }
    }
}
