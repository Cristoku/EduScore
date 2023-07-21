using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduScoreDatabase
{
    /// <summary>
    /// Represents a student entity with its properties.
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Gets or sets the unique identifier for the student.
        /// </summary>
        [Key]
        public int StudentId { get; set; }

        /// <summary>
        /// Gets or sets the name of the student.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the password for the student.
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the collection of grades associated with the student.
        /// </summary>
        public ICollection<Grade> Grades { get; set; }
    }
}
