namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationStuCourse : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Student_ID", c => c.Int());
            CreateIndex("dbo.Courses", "Student_ID");
            AddForeignKey("dbo.Courses", "Student_ID", "dbo.Students", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "Student_ID", "dbo.Students");
            DropIndex("dbo.Courses", new[] { "Student_ID" });
            DropColumn("dbo.Courses", "Student_ID");
        }
    }
}
