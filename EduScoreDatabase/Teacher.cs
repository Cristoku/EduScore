using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduScoreDatabase
{
    /// <summary>
    /// Represents a Teacher in the school system.
    /// </summary>
    public class Teacher
    {
        /// <summary>
        /// Gets or sets the unique identifier for the teacher.
        /// </summary>
        [Key]
        public int TeacherId { get; set; }

        /// <summary>
        /// Gets or sets the name of the teacher.
        /// </summary>
        [Required]
        public string Name { get; set; }

    }
}
