﻿using Lab04.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab04.Data
{
    public class SchoolInitializer : System.Data.Entity.DropCreateDatabaseAlways<SchoolContext>
    {
        protected override void Seed(SchoolContext context)
        {
            var students = new List<Student>
            {
            new Student{FirstMidName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2015-09-01")},
            new Student{FirstMidName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2012-09-01")},
            new Student{FirstMidName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2013-09-01")},
            new Student{FirstMidName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2012-09-01")},
            new Student{FirstMidName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("2012-09-01")},
            new Student{FirstMidName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2011-09-01")},
            new Student{FirstMidName="Laura",LastName="Norman",EnrollmentDate=DateTime.Parse("2013-09-01")},
            new Student{FirstMidName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2015-09-01")}
            };

            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();

            var instructors = new List<Instructor>
            {
            new Instructor { FirstMidName = "Kim",     LastName = "Abercrombie", HireDate = DateTime.Parse("1995-03-11"), Office="Smith 17" },
            new Instructor { FirstMidName = "Fadi",    LastName = "Fakhouri",HireDate = DateTime.Parse("2002-07-06"), Office="Smith 18" },
            new Instructor { FirstMidName = "Roger",   LastName = "Harui",HireDate = DateTime.Parse("1998-07-01"), Office="Smith 19" },
            new Instructor { FirstMidName = "Candace", LastName = "Kapoor",HireDate = DateTime.Parse("2001-01-15"), Office="Smith 20" },
            new Instructor { FirstMidName = "Roger",   LastName = "Zheng",HireDate = DateTime.Parse("2004-02-12"), Office="Smith 21" }
            };
            
            instructors.ForEach(s => context.Instructors.Add(s));
            context.SaveChanges();

            var departments = new List<Department>
            {
            new Department { Name = "English",     Budget = 350000, StartDate = DateTime.Parse("2007-09-01"), InstructorID  = instructors.Single( i => i.LastName == "Abercrombie").ID },
            new Department { Name = "Mathematics", Budget = 100000, StartDate = DateTime.Parse("2007-09-01"), InstructorID  = instructors.Single( i => i.LastName == "Fakhouri").ID },
            new Department { Name = "Engineering", Budget = 350000, StartDate = DateTime.Parse("2007-09-01"), InstructorID  = instructors.Single( i => i.LastName == "Harui").ID },
            new Department { Name = "Economics",   Budget = 100000, StartDate = DateTime.Parse("2007-09-01"), InstructorID  = instructors.Single( i => i.LastName == "Kapoor").ID }
            };

            departments.ForEach(s => context.Departments.Add(s));
            context.SaveChanges();

            var courses = new List<Course>
            {
            new Course {CourseID = 1050, Title = "Chemistry", Credits = 3, DepartmentID = departments.Single( s => s.Name == "Engineering").DepartmentID },
            new Course {CourseID = 4022, Title = "Microeconomics", Credits = 3, DepartmentID = departments.Single( s => s.Name == "Economics").DepartmentID },
            new Course {CourseID = 4041, Title = "Macroeconomics", Credits = 3, DepartmentID = departments.Single( s => s.Name == "Economics").DepartmentID },
            new Course {CourseID = 1045, Title = "Calculus",       Credits = 4, DepartmentID = departments.Single( s => s.Name == "Mathematics").DepartmentID },
            new Course {CourseID = 3141, Title = "Trigonometry",   Credits = 4, DepartmentID = departments.Single( s => s.Name == "Mathematics").DepartmentID },
            new Course {CourseID = 2021, Title = "Composition",    Credits = 3, DepartmentID = departments.Single( s => s.Name == "English").DepartmentID },
            new Course {CourseID = 2042, Title = "Literature",     Credits = 4, DepartmentID = departments.Single( s => s.Name == "English").DepartmentID },
            };

            courses.ForEach(s => context.Courses.Add(s));
            context.SaveChanges();

            var enrollments = new List<Enrollment>
            {
            new Enrollment { StudentID = students.Single(s => s.LastName == "Alexander").ID, CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID, Grade = Grade.A },
            new Enrollment { StudentID = students.Single(s => s.LastName == "Alexander").ID, CourseID = courses.Single(c => c.Title == "Microeconomics" ).CourseID, Grade = Grade.C },
            new Enrollment { StudentID = students.Single(s => s.LastName == "Alexander").ID, CourseID = courses.Single(c => c.Title == "Macroeconomics" ).CourseID, Grade = Grade.B },
            new Enrollment { StudentID = students.Single(s => s.LastName == "Alonso").ID, CourseID = courses.Single(c => c.Title == "Calculus" ).CourseID, Grade = Grade.B },
            new Enrollment { StudentID = students.Single(s => s.LastName == "Alonso").ID, CourseID = courses.Single(c => c.Title == "Trigonometry" ).CourseID, Grade = Grade.B },
            new Enrollment { StudentID = students.Single(s => s.LastName == "Alonso").ID, CourseID = courses.Single(c => c.Title == "Composition" ).CourseID, Grade = Grade.B },
            new Enrollment { StudentID = students.Single(s => s.LastName == "Anand").ID, CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID },
            new Enrollment { StudentID = students.Single(s => s.LastName == "Anand").ID, CourseID = courses.Single(c => c.Title == "Microeconomics").CourseID, Grade = Grade.B },
            new Enrollment { StudentID = students.Single(s => s.LastName == "Barzdukas").ID, CourseID = courses.Single(c => c.Title == "Chemistry").CourseID, Grade = Grade.B },
            new Enrollment { StudentID = students.Single(s => s.LastName == "Li").ID, CourseID = courses.Single(c => c.Title == "Composition").CourseID, Grade = Grade.B },
            new Enrollment { StudentID = students.Single(s => s.LastName == "Justice").ID, CourseID = courses.Single(c => c.Title == "Literature").CourseID, Grade = Grade.B }
            };

            enrollments.ForEach(s => context.Enrollments.Add(s));
            context.SaveChanges();

            var courseInstructors = new List<CourseAssignment>
            {
            new CourseAssignment { CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID, InstructorID = instructors.Single(i => i.LastName == "Kapoor").ID },
            new CourseAssignment { CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID, InstructorID = instructors.Single(i => i.LastName == "Harui").ID },
            new CourseAssignment { CourseID = courses.Single(c => c.Title == "Microeconomics" ).CourseID, InstructorID = instructors.Single(i => i.LastName == "Zheng").ID },
            new CourseAssignment { CourseID = courses.Single(c => c.Title == "Macroeconomics" ).CourseID, InstructorID = instructors.Single(i => i.LastName == "Zheng").ID },
            new CourseAssignment { CourseID = courses.Single(c => c.Title == "Calculus" ).CourseID, InstructorID = instructors.Single(i => i.LastName == "Fakhouri").ID },
            new CourseAssignment { CourseID = courses.Single(c => c.Title == "Trigonometry" ).CourseID, InstructorID = instructors.Single(i => i.LastName == "Harui").ID },
            new CourseAssignment { CourseID = courses.Single(c => c.Title == "Composition" ).CourseID, InstructorID = instructors.Single(i => i.LastName == "Abercrombie").ID },
            new CourseAssignment { CourseID = courses.Single(c => c.Title == "Literature" ).CourseID, InstructorID = instructors.Single(i => i.LastName == "Abercrombie").ID }
            };

            courseInstructors.ForEach(s => context.CourseAssignments.Add(s));
            context.SaveChanges();

            base.Seed(context);

        }
    }
}