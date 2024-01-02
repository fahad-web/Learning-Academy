namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Photo = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Mentors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Regdate = c.DateTime(nullable: false),
                        Gender = c.String(nullable: false),
                        AddBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Admins", t => t.AddBy, cascadeDelete: true)
                .Index(t => t.AddBy);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Fname = c.String(nullable: false),
                        Lname = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        AddBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Mentors", t => t.AddBy, cascadeDelete: true)
                .Index(t => t.AddBy);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "AddBy", "dbo.Mentors");
            DropForeignKey("dbo.Mentors", "AddBy", "dbo.Admins");
            DropIndex("dbo.Students", new[] { "AddBy" });
            DropIndex("dbo.Mentors", new[] { "AddBy" });
            DropTable("dbo.Students");
            DropTable("dbo.Mentors");
            DropTable("dbo.Admins");
        }
    }
}
