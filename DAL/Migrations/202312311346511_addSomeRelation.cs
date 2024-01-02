namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSomeRelation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        TotalCost = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: false)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: false)
                .Index(t => t.CourseId)
                .Index(t => t.StudentId);
            
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
            
            AddColumn("dbo.Mentors", "Email", c => c.String(nullable: false));
            AddColumn("dbo.Mentors", "Username", c => c.String(nullable: false));
            AddColumn("dbo.Mentors", "Password", c => c.String(nullable: false));
            AddColumn("dbo.Students", "Username", c => c.String(nullable: false));
            AddColumn("dbo.BuyDetails", "CourseId", c => c.Int(nullable: false));
            AddColumn("dbo.Courses", "CourseName", c => c.String(nullable: false));
            AddColumn("dbo.Courses", "Discription", c => c.String(nullable: false));
            AddColumn("dbo.Courses", "MentorsId", c => c.Int(nullable: false));
            AddColumn("dbo.SubscribeCourses", "Student_ID", c => c.Int());
            AlterColumn("dbo.Reviews", "Description", c => c.String(nullable: false));
            CreateIndex("dbo.Courses", "MentorsId");
            CreateIndex("dbo.SubscribeCourses", "Student_ID");
            CreateIndex("dbo.BuyDetails", "OrderId");
            CreateIndex("dbo.BuyDetails", "CourseId");
            CreateIndex("dbo.Payments", "StudentId");
            AddForeignKey("dbo.Courses", "MentorsId", "dbo.Mentors", "ID", cascadeDelete: true);
            AddForeignKey("dbo.SubscribeCourses", "Student_ID", "dbo.Students", "ID");
            AddForeignKey("dbo.BuyDetails", "CourseId", "dbo.Courses", "ID", cascadeDelete: true);
            AddForeignKey("dbo.BuyDetails", "OrderId", "dbo.OrderCourses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Payments", "StudentId", "dbo.Students", "ID", cascadeDelete: true);
            DropColumn("dbo.BuyDetails", "ProductId");
            DropColumn("dbo.Courses", "ProductName");
            DropColumn("dbo.Courses", "Quantity");
            DropTable("dbo.BuyCourses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.BuyCourses",
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
            
            AddColumn("dbo.Courses", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.Courses", "ProductName", c => c.String());
            AddColumn("dbo.BuyDetails", "ProductId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Payments", "StudentId", "dbo.Students");
            DropForeignKey("dbo.BuyDetails", "OrderId", "dbo.OrderCourses");
            DropForeignKey("dbo.BuyDetails", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.OrderCourses", "StudentId", "dbo.Students");
            DropForeignKey("dbo.OrderCourses", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.SubscribeCourses", "Student_ID", "dbo.Students");
            DropForeignKey("dbo.ReviewCourses", "Course_ID", "dbo.Courses");
            DropForeignKey("dbo.ReviewCourses", "Review_ID", "dbo.Reviews");
            DropForeignKey("dbo.Courses", "MentorsId", "dbo.Mentors");
            DropIndex("dbo.ReviewCourses", new[] { "Course_ID" });
            DropIndex("dbo.ReviewCourses", new[] { "Review_ID" });
            DropIndex("dbo.Payments", new[] { "StudentId" });
            DropIndex("dbo.BuyDetails", new[] { "CourseId" });
            DropIndex("dbo.BuyDetails", new[] { "OrderId" });
            DropIndex("dbo.OrderCourses", new[] { "StudentId" });
            DropIndex("dbo.OrderCourses", new[] { "CourseId" });
            DropIndex("dbo.SubscribeCourses", new[] { "Student_ID" });
            DropIndex("dbo.Courses", new[] { "MentorsId" });
            AlterColumn("dbo.Reviews", "Description", c => c.String());
            DropColumn("dbo.SubscribeCourses", "Student_ID");
            DropColumn("dbo.Courses", "MentorsId");
            DropColumn("dbo.Courses", "Discription");
            DropColumn("dbo.Courses", "CourseName");
            DropColumn("dbo.BuyDetails", "CourseId");
            DropColumn("dbo.Students", "Username");
            DropColumn("dbo.Mentors", "Password");
            DropColumn("dbo.Mentors", "Username");
            DropColumn("dbo.Mentors", "Email");
            DropTable("dbo.ReviewCourses");
            DropTable("dbo.OrderCourses");
        }
    }
}
