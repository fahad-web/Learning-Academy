namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SolveBigProblem : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ReviewCourses", "Review_ID", "dbo.Reviews");
            DropForeignKey("dbo.ReviewCourses", "Course_ID", "dbo.Courses");
            DropIndex("dbo.ReviewCourses", new[] { "Review_ID" });
            DropIndex("dbo.ReviewCourses", new[] { "Course_ID" });
            AddColumn("dbo.Courses", "ReviewId", c => c.Int(nullable: false));
            AddColumn("dbo.Courses", "Review_ID", c => c.Int());
            AddColumn("dbo.Reviews", "Course_ID", c => c.Int());
            CreateIndex("dbo.Courses", "ReviewId");
            CreateIndex("dbo.Courses", "Review_ID");
            CreateIndex("dbo.Reviews", "Course_ID");
            AddForeignKey("dbo.Courses", "Review_ID", "dbo.Reviews", "ID");
            AddForeignKey("dbo.Courses", "ReviewId", "dbo.Reviews", "ID", cascadeDelete: false);
            AddForeignKey("dbo.Reviews", "Course_ID", "dbo.Courses", "ID");
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
            
            DropForeignKey("dbo.Reviews", "Course_ID", "dbo.Courses");
            DropForeignKey("dbo.Courses", "ReviewId", "dbo.Reviews");
            DropForeignKey("dbo.Courses", "Review_ID", "dbo.Reviews");
            DropIndex("dbo.Reviews", new[] { "Course_ID" });
            DropIndex("dbo.Courses", new[] { "Review_ID" });
            DropIndex("dbo.Courses", new[] { "ReviewId" });
            DropColumn("dbo.Reviews", "Course_ID");
            DropColumn("dbo.Courses", "Review_ID");
            DropColumn("dbo.Courses", "ReviewId");
            CreateIndex("dbo.ReviewCourses", "Course_ID");
            CreateIndex("dbo.ReviewCourses", "Review_ID");
            AddForeignKey("dbo.ReviewCourses", "Course_ID", "dbo.Courses", "ID", cascadeDelete: false);
            AddForeignKey("dbo.ReviewCourses", "Review_ID", "dbo.Reviews", "ID", cascadeDelete: false);
        }
    }
}
