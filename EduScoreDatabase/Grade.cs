using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduScoreDatabase
{
    /// <summary>
    /// Represents a grade entity with its properties.
    /// </summary>
    public class Grade
    {
        /// <summary>
        /// Gets or sets the unique identifier for the grade.
        /// </summary>
        [Key]
        public int GradeId { get; set; }

        /// <summary>
        /// Gets or sets the foreign key for the associated student.
        /// </summary>
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        
        /// <summary>
        /// Gets or sets the associated student for the grade.
        /// </summary>
        public Student Student { get; set; }

        /// <summary>
        /// Gets or sets the foreign key for the associated subject.
        /// </summary>
        [ForeignKey("Subject")]
        public int SubjectId { get; set; }
        
        /// <summary>
        /// Gets or sets the associated subject for the grade.
        /// </summary>
        public Subject Subject { get; set; }

        /// <summary>
        /// Gets or sets the value of the grade.
        /// </summary>
        public int Value { get; set; }
    }
}
