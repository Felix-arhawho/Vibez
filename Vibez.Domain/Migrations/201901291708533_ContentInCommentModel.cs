namespace Vibez.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContentInCommentModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comment", "Content", c => c.String());
            DropColumn("dbo.Comment", "comment");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comment", "comment", c => c.String());
            DropColumn("dbo.Comment", "Content");
        }
    }
}
