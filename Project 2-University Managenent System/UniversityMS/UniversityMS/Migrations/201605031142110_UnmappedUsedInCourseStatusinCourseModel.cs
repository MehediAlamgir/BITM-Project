namespace UniversityMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UnmappedUsedInCourseStatusinCourseModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Courses", "CourseStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "CourseStatus", c => c.Boolean(nullable: false));
        }
    }
}
