using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduScoreDatabase
{
    /// <summary>
    /// Represents a subject entity with its properties.
    /// </summary>
    public class Subject
    {
        /// <summary>
        /// Gets or sets the unique identifier for the subject.
        /// </summary>
        [Key]
        public int SubjectId { get; set; }

        /// <summary>
        /// Gets or sets the name of the subject.
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}
