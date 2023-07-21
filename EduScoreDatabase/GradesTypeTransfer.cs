using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduScoreDatabase
{
    /// <summary>
    /// Represents a class responsible for converting a list of Grade objects into a list of GradeConverted objects.
    /// </summary>
    public class GradesTypeTransfer
    {
        private readonly List<Grade> _grade;

        /// <summary>
        /// Initializes a new instance of the GradesTypeTransfer class with the provided list of Grade objects.
        /// </summary>
        /// <param name="grade">The list of Grade objects to be converted.</param>
        public GradesTypeTransfer(List<Grade> grade)
        {
            _grade = grade;
        }

        /// <summary>
        /// Converts the list of Grade objects into a list of GradeConverted objects.
        /// </summary>
        /// <returns>The list of converted GradeConverted objects.</returns>
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

    /// <summary>
    /// Represents a class containing the converted grade data with subject name and grade value.
    /// </summary>
    public class GradeConverted
    {
        /// <summary>
        /// Gets or sets the name of the subject associated with the grade.
        /// </summary>
        public string Przedmiot { get; set; }
        
        /// <summary>
        /// Gets or sets the grade value for the subject.
        /// </summary>
        public int Ocena { get; set; }
    }
}
