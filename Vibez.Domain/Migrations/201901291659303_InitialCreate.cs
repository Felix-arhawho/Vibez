namespace Vibez.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        Likes = c.Int(nullable: false),
                        Dislikes = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        comment = c.String(),
                        postId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Post", t => t.postId, cascadeDelete: true)
                .Index(t => t.postId);
            
            CreateTable(
                "dbo.Image",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Url = c.String(),
                        Extension = c.String(),
                        postId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Post", t => t.postId, cascadeDelete: true)
                .Index(t => t.postId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Image", "postId", "dbo.Post");
            DropForeignKey("dbo.Comment", "postId", "dbo.Post");
            DropForeignKey("dbo.Post", "CategoryId", "dbo.Category");
            DropIndex("dbo.Image", new[] { "postId" });
            DropIndex("dbo.Comment", new[] { "postId" });
            DropIndex("dbo.Post", new[] { "CategoryId" });
            DropTable("dbo.Image");
            DropTable("dbo.Comment");
            DropTable("dbo.Post");
            DropTable("dbo.Category");
        }
    }
}
