using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduScoreDatabase
{
using System;
using System.Linq;

public class ExampleData
{
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

            dbContext.Subjects.AddRange(subject1, subject2, subject3);

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

            dbContext.Grades.AddRange(grade1, grade2, grade3);

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

            dbContext.LessonPlans.AddRange(lessonPlan1, lessonPlan2);

            var teacher1 = new Teacher
            {
                Name = "Adam Nowak"
            };
            var teacher2 = new Teacher
            {
                Name = "Maria Kowalska"
            };

            dbContext.Teachers.AddRange(teacher1, teacher2);

            dbContext.SaveChanges();
        }
    }
}



}
