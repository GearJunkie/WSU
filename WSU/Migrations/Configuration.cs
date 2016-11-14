namespace WSU.Migrations
{
    using WSU.Models;
    using WSU.DAL;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    internal sealed class Configuration : DbMigrationsConfiguration<SchoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
        protected override void Seed(SchoolContext context)
        {
            var students = new List<Student>
{
new Student { FirstMidName = "Ben", LastName = "Carrington",
EnrollmentDate = DateTime.Parse("2016-09-01") },
new Student { FirstMidName = "Steven", LastName = "Knotek",
EnrollmentDate = DateTime.Parse("2012-09-01") },
new Student { FirstMidName = "Andre", LastName = "Myers",
EnrollmentDate = DateTime.Parse("2013-09-01") },
new Student { FirstMidName = "Paul", LastName = "Olson",
EnrollmentDate = DateTime.Parse("2012-09-01") },
new Student { FirstMidName = "Lori", LastName = "Pack",
EnrollmentDate = DateTime.Parse("2012-09-01") },
new Student { FirstMidName = "Aaron", LastName = "Parker",
EnrollmentDate = DateTime.Parse("2011-09-01") },
new Student { FirstMidName = "Katie", LastName = "Rios",
EnrollmentDate = DateTime.Parse("2013-09-01") },
new Student { FirstMidName = "Oscar", LastName = "Suarez",
EnrollmentDate = DateTime.Parse("2015-09-01") },
new Student { FirstMidName = "Jace", LastName = "Tensmeyer",
EnrollmentDate = DateTime.Parse("2015-09-01") }
};
            students.ForEach(s => context.Students.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();
            var instructors = new List<Instructor>
{
new Instructor { FirstMidName = "Richard", LastName = "Fry",
HireDate = DateTime.Parse("2000-07-07") },
new Instructor { FirstMidName = "Robert", LastName = "Hilton",
HireDate = DateTime.Parse("1998-07-06") },
new Instructor { FirstMidName = "Brian", LastName = "Rague",
HireDate = DateTime.Parse("1998-07-01") },
new Instructor { FirstMidName = "Josh", LastName = "Jensen",
HireDate = DateTime.Parse("2012-01-15") },
new Instructor { FirstMidName = "Yong", LastName = "Zheng",
HireDate = DateTime.Parse("2014-02-12") }
};
            instructors.ForEach(s => context.Instructors.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();
            var departments = new List<Department>
{
new Department{ Name = "English", Budget = 350000,StartDate = DateTime.Parse("2007-09-01"),
InstructorID = instructors.Single( i => i.LastName == "Fry").ID },
new Department { Name = "Mathematics", Budget = 100000,
StartDate = DateTime.Parse("2007-09-01"),
InstructorID = instructors.Single( i => i.LastName == "Hilton").ID },
new Department { Name = "Engineering", Budget = 350000,
StartDate = DateTime.Parse("2007-09-01"),
InstructorID = instructors.Single( i => i.LastName == "Rague").ID },
new Department { Name = "Economics", Budget = 100000,
StartDate = DateTime.Parse("2007-09-01"),
InstructorID = instructors.Single( i => i.LastName == "Jensen").ID }
};
            departments.ForEach(s => context.Departments.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();
            var courses = new List<Course>
{
new Course {CourseID = 1050, Title = "Chemistry", Credits = 3,
DepartmentID = departments.Single( s => s.Name == "Engineering").DepartmentID,
Instructors = new List<Instructor>()
},
new Course {CourseID = 4022, Title = "Microeconomics", Credits = 3,
DepartmentID = departments.Single( s => s.Name == "Economics").DepartmentID,
Instructors = new List<Instructor>()
},
new Course {CourseID = 4041, Title = "Macroeconomics", Credits = 3,
DepartmentID = departments.Single( s => s.Name == "Economics").DepartmentID,
Instructors = new List<Instructor>()
},
new Course {CourseID = 1045, Title = "Calculus", Credits = 4,
DepartmentID = departments.Single( s => s.Name == "Mathematics").DepartmentID,
Instructors = new List<Instructor>()
},
new Course {CourseID = 3141, Title = "Trigonometry", Credits = 4,
DepartmentID = departments.Single( s => s.Name == "Mathematics").DepartmentID,
Instructors = new List<Instructor>()
},
new Course {CourseID = 2021, Title = "Composition", Credits = 3,
DepartmentID = departments.Single( s => s.Name == "English").DepartmentID,
Instructors = new List<Instructor>()},
new Course {CourseID = 2042, Title = "Literature", Credits = 4,
DepartmentID = departments.Single( s => s.Name == "English").DepartmentID,
Instructors = new List<Instructor>()
},
};
            courses.ForEach(s => context.Courses.AddOrUpdate(p => p.CourseID, s));
            context.SaveChanges();
            var officeAssignments = new List<OfficeAssignment>
{
new OfficeAssignment {
InstructorID = instructors.Single( i => i.LastName == "Fry").ID,
Location = "EH 273" },
new OfficeAssignment {
InstructorID = instructors.Single( i => i.LastName == "Hilton").ID,
Location = "TE 202" },
new OfficeAssignment {
InstructorID = instructors.Single( i => i.LastName == "Rague").ID,
Location = "TE 304" },
};
            officeAssignments.ForEach(s => context.OfficeAssignments.AddOrUpdate(p => p.InstructorID,
           s));
            context.SaveChanges();
            AddOrUpdateInstructor(context, "Chemistry", "Fry");
            AddOrUpdateInstructor(context, "Chemistry", "Fry");
            AddOrUpdateInstructor(context, "Microeconomics", "Zheng");
            AddOrUpdateInstructor(context, "Macroeconomics", "Zheng");
            AddOrUpdateInstructor(context, "Calculus", "Hilton");
            AddOrUpdateInstructor(context, "Trigonometry", "Rague");
            AddOrUpdateInstructor(context, "Composition", "Jensen");
            AddOrUpdateInstructor(context, "Literature", "Jensen");
            context.SaveChanges();
            var enrollments = new List<Enrollment>
{
new Enrollment {
StudentID = students.Single(s => s.LastName == "Carrington").ID,
CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID,
Grade = Grade.A
},
new Enrollment {
StudentID = students.Single(s => s.LastName == "Carrington").ID,
CourseID = courses.Single(c => c.Title == "Microeconomics" ).CourseID,Grade = Grade.C
},
new Enrollment {
StudentID = students.Single(s => s.LastName == "Carrington").ID,
CourseID = courses.Single(c => c.Title == "Macroeconomics" ).CourseID,
Grade = Grade.B
},
new Enrollment {
StudentID = students.Single(s => s.LastName == "Rios").ID,
CourseID = courses.Single(c => c.Title == "Calculus" ).CourseID,
Grade = Grade.B
},
new Enrollment {
StudentID = students.Single(s => s.LastName == "Rios").ID,
CourseID = courses.Single(c => c.Title == "Trigonometry" ).CourseID,
Grade = Grade.B
},
new Enrollment {
StudentID = students.Single(s => s.LastName == "Rios").ID,
CourseID = courses.Single(c => c.Title == "Composition" ).CourseID,
Grade = Grade.B
},
new Enrollment {
StudentID = students.Single(s => s.LastName == "Parker").ID,
CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID
},
new Enrollment {
StudentID = students.Single(s => s.LastName == "Parker").ID,
CourseID = courses.Single(c => c.Title == "Microeconomics").CourseID,
Grade = Grade.B
},
new Enrollment {
StudentID = students.Single(s => s.LastName == "Knotek").ID,
CourseID = courses.Single(c => c.Title == "Chemistry").CourseID,
Grade = Grade.B
},
new Enrollment {
StudentID = students.Single(s => s.LastName == "Pack").ID,
CourseID = courses.Single(c => c.Title == "Composition").CourseID,
Grade = Grade.B
},
new Enrollment {StudentID = students.Single(s => s.LastName == "Olson").ID,
CourseID = courses.Single(c => c.Title == "Literature").CourseID,
Grade = Grade.B
}
};
            foreach (Enrollment e in enrollments)
            {
                var enrollmentInDataBase = context.Enrollments.Where(
                s =>
                s.Student.ID == e.StudentID &&
                s.Course.CourseID == e.CourseID).SingleOrDefault();
                if (enrollmentInDataBase == null)
                {
                    context.Enrollments.Add(e);
                }
            }
            context.SaveChanges();
        }
        void AddOrUpdateInstructor(SchoolContext context, string courseTitle, string instructorName)
        {
            var crs = context.Courses.SingleOrDefault(c => c.Title == courseTitle);
            var inst = crs.Instructors.SingleOrDefault(i => i.LastName == instructorName);
            if (inst == null)
                crs.Instructors.Add(context.Instructors.Single(i => i.LastName == instructorName));
        }
    }
}