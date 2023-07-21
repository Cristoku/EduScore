using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduScoreDatabase.CommandsQueries
{
    /// <summary>
    /// Represents a class responsible for removing data from the EduScoreContext database context.
    /// </summary>
    public class RemovingCommands
    {
        private EduScoreContext _context;

        /// <summary>
        /// Initializes a new instance of the RemovingCommands class using the default EduScoreContext.
        /// </summary>
        public RemovingCommands()
        {
            _context = new EduScoreContext();
        }

        /// <summary>
        /// Removes a single entity of type T from the database context.
        /// </summary>
        /// <typeparam name="T">The type of the entity to be removed.</typeparam>
        /// <param name="data">The entity to be removed.</param>
        public void RemoveData<T>(T data) where T : class
        {
                _context.Set<T>().Remove(data);
                _context.SaveChanges();
        }

        /// <summary>
        /// Removes a grade from the database context by its ID.
        /// </summary>
        /// <param name="id">The ID of the grade to be removed.</param>
        /// <returns>True if the grade is found and removed, otherwise false.</returns>
        public bool RemoveGradeById(int id)
        {
            var dataToRemove = _context.Set<Grade>().FirstOrDefault(item => item.GradeId == id);

            if (dataToRemove == null)
            {
                return false;
            }

            _context.Set<Grade>().Remove(dataToRemove);
            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Removes a subject from the database context by its ID.
        /// </summary>
        /// <param name="id">The ID of the subject to be removed.</param>
        /// <returns>True if the subject is found and removed, otherwise false.</returns>
        public bool RemoveSubjectById(int id)
        {
            var dataToRemove = _context.Set<Subject>().FirstOrDefault(item => item.SubjectId == id);

            if (dataToRemove == null)
            {
                return false;
            }

            _context.Set<Subject>().Remove(dataToRemove);
            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Removes a lesson plan from the database context by its ID.
        /// </summary>
        /// <param name="id">The ID of the lesson plan to be removed.</param>
        /// <returns>True if the lesson plan is found and removed, otherwise false.</returns>
        public bool RemoveLessonById(int id)
        {
            var dataToRemove = _context.Set<LessonPlan>().FirstOrDefault(item => item.LessonPlanId == id);

            if (dataToRemove == null)
            {
                return false;
            }

            _context.Set<LessonPlan>().Remove(dataToRemove);
            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Removes a list of entities of type T from the database context.
        /// </summary>
        /// <typeparam name="T">The type of the entities to be removed.</typeparam>
        /// <param name="dataList">The list of entities to be removed.</param>
        public void RemoveData<T>(List<T> dataList) where T : class
        {
            using (var context = _context)
            {
                context.Set<T>().RemoveRange(dataList);
                context.SaveChanges();
            }
        }
    }
}
