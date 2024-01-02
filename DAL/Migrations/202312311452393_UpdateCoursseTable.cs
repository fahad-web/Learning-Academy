namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCoursseTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "Review_ID", "dbo.Reviews");
            DropForeignKey("dbo.Courses", "ReviewId", "dbo.Reviews");
            DropForeignKey("dbo.Reviews", "Course_ID", "dbo.Courses");
            DropIndex("dbo.Courses", new[] { "ReviewId" });
            DropIndex("dbo.Courses", new[] { "Review_ID" });
            DropIndex("dbo.Reviews", new[] { "Course_ID" });
            CreateTable(
                "dbo.ReviewCourses",
                c => new
                    {
                        Review_ID = c.Int(nullable: false),
                        Course_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Review_ID, t.Course_ID })
                .ForeignKey("dbo.Reviews", t => t.Review_ID, cascadeDelete: false)
                .ForeignKey("dbo.Courses", t => t.Course_ID, cascadeDelete: false)
                .Index(t => t.Review_ID)
                .Index(t => t.Course_ID);
            
            AddColumn("dbo.Courses", "Price", c => c.Int(nullable: false));
            DropColumn("dbo.Courses", "UnitPrice");
            DropColumn("dbo.Courses", "ReviewId");
            DropColumn("dbo.Courses", "Review_ID");
            DropColumn("dbo.Reviews", "Course_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reviews", "Course_ID", c => c.Int());
            AddColumn("dbo.Courses", "Review_ID", c => c.Int());
            AddColumn("dbo.Courses", "ReviewId", c => c.Int(nullable: false));
            AddColumn("dbo.Courses", "UnitPrice", c => c.Int(nullable: false));
            DropForeignKey("dbo.ReviewCourses", "Course_ID", "dbo.Courses");
            DropForeignKey("dbo.ReviewCourses", "Review_ID", "dbo.Reviews");
            DropIndex("dbo.ReviewCourses", new[] { "Course_ID" });
            DropIndex("dbo.ReviewCourses", new[] { "Review_ID" });
            DropColumn("dbo.Courses", "Price");
            DropTable("dbo.ReviewCourses");
            CreateIndex("dbo.Reviews", "Course_ID");
            CreateIndex("dbo.Courses", "Review_ID");
            CreateIndex("dbo.Courses", "ReviewId");
            AddForeignKey("dbo.Reviews", "Course_ID", "dbo.Courses", "ID");
            AddForeignKey("dbo.Courses", "ReviewId", "dbo.Reviews", "ID", cascadeDelete: false);
            AddForeignKey("dbo.Courses", "Review_ID", "dbo.Reviews", "ID");
        }
    }
}
