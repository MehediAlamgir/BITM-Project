namespace UniversityMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateAllTableMV1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClassRoomAllocations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        RoomId = c.Int(nullable: false),
                        DayId = c.Int(nullable: false),
                        StartTime = c.Double(nullable: false),
                        EndTime = c.Double(nullable: false),
                        RoomStatus = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId)
                .ForeignKey("dbo.Days", t => t.DayId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .ForeignKey("dbo.Rooms", t => t.RoomId)
                .Index(t => t.CourseId)
                .Index(t => t.DayId)
                .Index(t => t.DepartmentId)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseCode = c.String(nullable: false, maxLength: 100),
                        CourseName = c.String(nullable: false),
                        CourseCredit = c.Double(nullable: false),
                        CourseDescription = c.String(nullable: false),
                        CourseAssignTo = c.String(),
                        CourseStatus = c.Boolean(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        SemesterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .ForeignKey("dbo.Semesters", t => t.SemesterId)
                .Index(t => t.DepartmentId)
                .Index(t => t.SemesterId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeptCode = c.String(nullable: false, maxLength: 7),
                        DeptName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Semesters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SemesterName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Days",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClassSchedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseCode = c.String(),
                        CourseName = c.String(),
                        Schedule = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CourseAssigns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                        CreditTaken = c.Double(nullable: false),
                        CreditLeft = c.Double(nullable: false),
                        CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseID)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .ForeignKey("dbo.Teachers", t => t.TeacherId)
                .Index(t => t.CourseID)
                .Index(t => t.DepartmentId)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeacherName = c.String(nullable: false),
                        TeacherAddress = c.String(nullable: false),
                        TeacherEmail = c.String(nullable: false),
                        TeacherContactNo = c.String(nullable: false, maxLength: 14),
                        DesignationId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        CreditTaken = c.Double(nullable: false),
                        CreditLeft = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .ForeignKey("dbo.Designations", t => t.DesignationId)
                .Index(t => t.DepartmentId)
                .Index(t => t.DesignationId);
            
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DesignationName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EnrollCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegistrationNo = c.String(nullable: false),
                        CourseId = c.Int(nullable: false),
                        EnrollDate = c.DateTime(nullable: false),
                        CourseGrade = c.String(),
                        Student_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .Index(t => t.CourseId)
                .Index(t => t.Student_Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        ContactNo = c.String(nullable: false, maxLength: 14),
                        Date = c.DateTime(nullable: false),
                        Address = c.String(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        StudentRegNo = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GradeName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EnrollCourses", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Students", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.EnrollCourses", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.CourseAssigns", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Teachers", "DesignationId", "dbo.Designations");
            DropForeignKey("dbo.Teachers", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.CourseAssigns", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.CourseAssigns", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.ClassRoomAllocations", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.ClassRoomAllocations", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.ClassRoomAllocations", "DayId", "dbo.Days");
            DropForeignKey("dbo.ClassRoomAllocations", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Courses", "SemesterId", "dbo.Semesters");
            DropForeignKey("dbo.Courses", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.EnrollCourses", new[] { "Student_Id" });
            DropIndex("dbo.Students", new[] { "DepartmentId" });
            DropIndex("dbo.EnrollCourses", new[] { "CourseId" });
            DropIndex("dbo.CourseAssigns", new[] { "TeacherId" });
            DropIndex("dbo.Teachers", new[] { "DesignationId" });
            DropIndex("dbo.Teachers", new[] { "DepartmentId" });
            DropIndex("dbo.CourseAssigns", new[] { "DepartmentId" });
            DropIndex("dbo.CourseAssigns", new[] { "CourseID" });
            DropIndex("dbo.ClassRoomAllocations", new[] { "RoomId" });
            DropIndex("dbo.ClassRoomAllocations", new[] { "DepartmentId" });
            DropIndex("dbo.ClassRoomAllocations", new[] { "DayId" });
            DropIndex("dbo.ClassRoomAllocations", new[] { "CourseId" });
            DropIndex("dbo.Courses", new[] { "SemesterId" });
            DropIndex("dbo.Courses", new[] { "DepartmentId" });
            DropTable("dbo.Grades");
            DropTable("dbo.Students");
            DropTable("dbo.EnrollCourses");
            DropTable("dbo.Designations");
            DropTable("dbo.Teachers");
            DropTable("dbo.CourseAssigns");
            DropTable("dbo.ClassSchedules");
            DropTable("dbo.Rooms");
            DropTable("dbo.Days");
            DropTable("dbo.Semesters");
            DropTable("dbo.Departments");
            DropTable("dbo.Courses");
            DropTable("dbo.ClassRoomAllocations");
        }
    }
}
