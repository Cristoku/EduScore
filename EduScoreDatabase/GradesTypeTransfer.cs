using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduScoreDatabase
{
    public class GradesTypeTransfer
    {
        private readonly List<Grade> _grade;

        public GradesTypeTransfer(List<Grade> grade)
        {
            _grade = grade;
        }

        public List<GradeConverted> ConvertGrades()
        {
            List<GradeConverted> grades = new List<GradeConverted>();
            foreach (var grade in _grade)
            {
                string subjectName = "";
                switch (grade.SubjectId)
                {
                    case 1:
                        subjectName = "Matematyka";
                        break;
                    case 2:
                        subjectName = "Język polski";
                        break;
                    case 3:
                        subjectName = "Fizyka";
                        break;
                    case 4:
                        subjectName = "Język Angielski";
                        break;
                    case 5:
                        subjectName = "Język Francuski";
                        break;
                    default:
                        subjectName = "Inny";
                        break;

                }


                grades.Add(new GradeConverted { Przedmiot = subjectName, Ocena = grade.Value });
            }
            return grades;
        }
    }

    public class GradeConverted
    {
        public string Przedmiot { get; set; }
        public int Ocena { get; set; }
    }
}
