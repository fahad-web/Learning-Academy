namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateReviewTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ReviewCourses", "Review_ID", "dbo.Reviews");
            DropForeignKey("dbo.ReviewCourses", "Course_ID", "dbo.Courses");
            DropIndex("dbo.ReviewCourses", new[] { "Review_ID" });
            DropIndex("dbo.ReviewCourses", new[] { "Course_ID" });
            AddColumn("dbo.Reviews", "CourseId", c => c.Int(nullable: false));
            CreateIndex("dbo.Reviews", "CourseId");
            AddForeignKey("dbo.Reviews", "CourseId", "dbo.Courses", "ID", cascadeDelete: false);
            DropTable("dbo.ReviewCourses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ReviewCourses",
                c => new
                    {
                        Review_ID = c.Int(nullable: false),
                        Course_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Review_ID, t.Course_ID });
            
            DropForeignKey("dbo.Reviews", "CourseId", "dbo.Courses");
            DropIndex("dbo.Reviews", new[] { "CourseId" });
            DropColumn("dbo.Reviews", "CourseId");
            CreateIndex("dbo.ReviewCourses", "Course_ID");
            CreateIndex("dbo.ReviewCourses", "Review_ID");
            AddForeignKey("dbo.ReviewCourses", "Course_ID", "dbo.Courses", "ID", cascadeDelete: false);
            AddForeignKey("dbo.ReviewCourses", "Review_ID", "dbo.Reviews", "ID", cascadeDelete: false);
        }
    }
}
