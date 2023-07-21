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
    /// Represents a lesson plan entity with its properties.
    /// </summary>
    public class LessonPlan
    {
        /// <summary>
        /// Gets or sets the unique identifier for the lesson plan.
        /// </summary>
        [Key]
        public int LessonPlanId { get; set; }

        /// <summary>
        /// Gets or sets the foreign key for the associated subject.
        /// </summary>
        [ForeignKey("Subject")]
        public int SubjectId { get; set; }
        
        /// <summary>
        /// Gets or sets the associated subject for the lesson plan.
        /// </summary>
        public Subject Subject { get; set; }

        /// <summary>
        /// Gets or sets the name of the teacher creating the lesson plan.
        /// </summary>
        public string TeacherName { get; set; }
        
        /// <summary>
        /// Gets or sets the content of the lesson plan.
        /// </summary>
        public string Content { get; set; }
    }
}
