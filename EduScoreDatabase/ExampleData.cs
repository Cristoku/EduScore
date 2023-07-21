using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduScoreDatabase
{
using System;
using System.Linq;

/// <summary>
/// Represents a class responsible for seeding sample data in the database.
/// </summary>
public class ExampleData
{
    /// <summary>
    /// Seeds sample data into the specified EduScoreContext database context if no data exists.
    /// </summary>
    /// <param name="dbContext">The EduScoreContext database context.</param>
    public void SeedData(EduScoreContext dbContext)
    {
        if (!dbContext.Students.Any())
        {
            var student1 = new Student
            {
                Name = "JanKowalski",
                Password = "password1" 
            };
            var student2 = new Student
            {
                Name = "AnnaNowak",
                Password = "password2" 
            };

            dbContext.Students.AddRange(student1, student2);

            var subject1 = new Subject
            {
                Name = "Matematyka"
            };
            var subject2 = new Subject
            {
                Name = "Język Polski"
            };
            var subject3 = new Subject
            {
                Name = "Fizyka"
            };
            var subject4 = new Subject
            {
                Name = "Język Angielski"
            };
            var subject5 = new Subject
            {
                Name = "Język Francuski"
            };

            dbContext.Subjects.AddRange(subject1, subject2, subject3, subject4, subject5);

            var grade1 = new Grade
            {
                Student = student1,
                Subject = subject1,
                Value = 4
            };
            var grade2 = new Grade
            {
                Student = student1,
                Subject = subject2,
                Value = 5
            };
            var grade3 = new Grade
            {
                Student = student2,
                Subject = subject1,
                Value = 3
            };
            var grade4 = new Grade
            {
                Student = student1,
                Subject = subject1,
                Value = 3
            };
            var grade5 = new Grade
            {
                Student = student1,
                Subject = subject2,
                Value = 5
            };
            var grade6 = new Grade
            {
                Student = student1,
                Subject = subject3,
                Value = 2
            };

            dbContext.Grades.AddRange(grade1, grade2, grade3, grade4, grade5, grade6);

            var lessonPlan1 = new LessonPlan
            {
                Subject = subject1,
                TeacherName = "Adam Nowak",
                Content = "Lesson plan for Matematyka"
            };
            var lessonPlan2 = new LessonPlan
            {
                Subject = subject2,
                TeacherName = "Maria Kowalska",
                Content = "Lesson plan for Język Polski"
            };
            var lessonPlan3 = new LessonPlan
            {
                Subject = subject3,
                TeacherName = "Sebastian Krakus",
                Content = "Lesson plan for Język Polski"
            };
            var lessonPlan4 = new LessonPlan
            {
                Subject = subject4,
                TeacherName = "Dawid Kragula",
                Content = "Lesson plan for Język Polski"
            };

            dbContext.LessonPlans.AddRange(lessonPlan1, lessonPlan2,lessonPlan3,lessonPlan4);

            var teacher1 = new Teacher
            {
                Name = "Adam Nowak"
            };
            var teacher2 = new Teacher
            {
                Name = "Maria Kowalska"
            };
            var teacher3 = new Teacher
            {
                Name = "Dawid Kragula"
            };
            var teacher4 = new Teacher
            {
                Name = "Sebastian Krakus"
            };

            dbContext.Teachers.AddRange(teacher1, teacher2, teacher3, teacher4);

            dbContext.SaveChanges();
        }
    }
}

}
