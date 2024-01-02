namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateSubCourseTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SubscribeCourses", "Student_ID", "dbo.Students");
            DropIndex("dbo.SubscribeCourses", new[] { "Student_ID" });
            RenameColumn(table: "dbo.SubscribeCourses", name: "Student_ID", newName: "StudentId");
            AlterColumn("dbo.SubscribeCourses", "StudentId", c => c.Int(nullable: false));
            CreateIndex("dbo.SubscribeCourses", "StudentId");
            AddForeignKey("dbo.SubscribeCourses", "StudentId", "dbo.Students", "ID", cascadeDelete: false);
            DropColumn("dbo.SubscribeCourses", "Tname");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SubscribeCourses", "Tname", c => c.String(nullable: false));
            DropForeignKey("dbo.SubscribeCourses", "StudentId", "dbo.Students");
            DropIndex("dbo.SubscribeCourses", new[] { "StudentId" });
            AlterColumn("dbo.SubscribeCourses", "StudentId", c => c.Int());
            RenameColumn(table: "dbo.SubscribeCourses", name: "StudentId", newName: "Student_ID");
            CreateIndex("dbo.SubscribeCourses", "Student_ID");
            AddForeignKey("dbo.SubscribeCourses", "Student_ID", "dbo.Students", "ID");
        }
    }
}
