namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SolveAllError : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BuyDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.BuyTutorials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderQuantity = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        TotalCost = c.Int(nullable: false),
                        Pharmacy_Id = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.String(nullable: false),
                        PaymentDate = c.DateTime(nullable: false),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.SubscribeTutorials",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                        PaymentDate = c.DateTime(nullable: false),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubscribeTutorials", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Reviews", "StudentId", "dbo.Students");
            DropIndex("dbo.SubscribeTutorials", new[] { "StudentId" });
            DropIndex("dbo.Reviews", new[] { "StudentId" });
            DropTable("dbo.SubscribeTutorials");
            DropTable("dbo.Reviews");
            DropTable("dbo.Payments");
            DropTable("dbo.Courses");
            DropTable("dbo.BuyTutorials");
            DropTable("dbo.BuyDetails");
        }
    }
}
