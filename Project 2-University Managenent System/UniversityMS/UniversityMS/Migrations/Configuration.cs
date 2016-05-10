using UniversityMS.Models;

namespace UniversityMS.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<UniversityMS.Context.UniversityDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(UniversityMS.Context.UniversityDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //


            //context.Designations.AddOrUpdate(

            //  new Designation() { DesignationName = "Professor" },
            //  new Designation() { DesignationName = "Associate Professor" },
            //  new Designation() { DesignationName = "Assistent Professor" },
            //  new Designation() { DesignationName = "Lecturer" },
            //  new Designation() { DesignationName = "Instructor" }

            //  );

            //context.Semesters.AddOrUpdate(

            //    new Semester() { SemesterName = "1st Semester" },
            //    new Semester() { SemesterName = "2nd Semester" },
            //    new Semester() { SemesterName = "3rd Semester" },
            //    new Semester() { SemesterName = "4th Semester" },
            //    new Semester() { SemesterName = "5th Semester" },
            //    new Semester() { SemesterName = "6th Semester" },
            //    new Semester() { SemesterName = "7th Semester" },
            //    new Semester() { SemesterName = "8th Semester" }

            //    );

            //context.Grades.AddOrUpdate(

            //  new Grade() { GradeName = "A+" },
            //  new Grade() { GradeName = "A" },
            //  new Grade() { GradeName = "A-" },
            //  new Grade() { GradeName = "B+" },
            //  new Grade() { GradeName = "B" },
            //  new Grade() { GradeName = "B-" },
            //  new Grade() { GradeName = "C+" },
            //  new Grade() { GradeName = "C" },
            //  new Grade() { GradeName = "C-" },
            //  new Grade() { GradeName = "D+" },
            //  new Grade() { GradeName = "D" },
            //  new Grade() { GradeName = "D-" },
            //  new Grade() { GradeName = "F" }

            //  );


            //context.Rooms.AddOrUpdate(

            //    new Room() { Name = "101" },
            //    new Room() { Name = "102" },
            //    new Room() { Name = "201" },
            //    new Room() { Name = "202" },
            //    new Room() { Name = "301" },
            //    new Room() { Name = "302" },
            //    new Room() { Name = "401" },
            //    new Room() { Name = "402" },
            //    new Room() { Name = "501" },
            //    new Room() { Name = "502" }

            //    );

            //context.Days.AddOrUpdate(

            //    new Day() { Name = "Saturday" },
            //    new Day() { Name = "Sunday" },
            //    new Day() { Name = "Monday" },
            //    new Day() { Name = "Tuesday" },
            //    new Day() { Name = "Wednesday" },
            //    new Day() { Name = "Thursday" },
            //    new Day() { Name = "Friday" }

            //    );

        }
    }
}
