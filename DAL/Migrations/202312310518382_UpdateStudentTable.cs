namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateStudentTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.BuyTutorials", newName: "BuyCourses");
            DropForeignKey("dbo.SubscribeTutorials", "StudentId", "dbo.Students");
            DropIndex("dbo.SubscribeTutorials", new[] { "StudentId" });
            CreateTable(
                "dbo.SubscribeCourses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Tname = c.String(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
            DropTable("dbo.SubscribeTutorials");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SubscribeTutorials",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                        PaymentDate = c.DateTime(nullable: false),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            DropForeignKey("dbo.SubscribeCourses", "CourseId", "dbo.Courses");
            DropIndex("dbo.SubscribeCourses", new[] { "CourseId" });
            DropTable("dbo.SubscribeCourses");
            CreateIndex("dbo.SubscribeTutorials", "StudentId");
            AddForeignKey("dbo.SubscribeTutorials", "StudentId", "dbo.Students", "ID", cascadeDelete: true);
            RenameTable(name: "dbo.BuyCourses", newName: "BuyTutorials");
        }
    }
}
