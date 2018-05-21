namespace FTV.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCommentTableAndAddedDateTimeValues : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "FTV.Comment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Body = c.String(maxLength: 400),
                        UserId = c.Int(nullable: false),
                        Created = c.DateTime(),
                        Modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("FTV.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            AddColumn("FTV.Followed Player", "Created", c => c.DateTime());
            AddColumn("FTV.Followed Player", "Modified", c => c.DateTime());
            AddColumn("FTV.User", "Created", c => c.DateTime());
            AddColumn("FTV.User", "Modified", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropForeignKey("FTV.Comment", "UserId", "FTV.User");
            DropIndex("FTV.Comment", new[] { "UserId" });
            DropColumn("FTV.User", "Modified");
            DropColumn("FTV.User", "Created");
            DropColumn("FTV.Followed Player", "Modified");
            DropColumn("FTV.Followed Player", "Created");
            DropTable("FTV.Comment");
        }
    }
}
