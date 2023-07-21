using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduScoreDatabase.CommandsQueries
{
    /// <summary>
    /// Represents a class responsible for saving data to the EduScoreContext database context.
    /// </summary>
    public class SavingCommands
    {
        private  EduScoreContext _context;

        /// <summary>
        /// Initializes a new instance of the SavingCommands class using the default EduScoreContext.
        /// </summary>
        public SavingCommands()
        {
            _context = new EduScoreContext();
        }

        /// <summary>
        /// Saves a single entity of type T to the database context.
        /// </summary>
        /// <typeparam name="T">The type of the entity to be saved.</typeparam>
        /// <param name="data">The entity to be saved.</param>
        public void SaveData<T>(T data) where T : class
        {
                _context.Set<T>().Add(data);
                _context.SaveChanges();
        }
        
        /// <summary>
        /// Saves a list of entities of type T to the database context.
        /// </summary>
        /// <typeparam name="T">The type of the entities to be saved.</typeparam>
        /// <param name="dataList">The list of entities to be saved.</param>
        public void SaveData<T>(List<T> dataList) where T : class
        {
                _context.Set<T>().AddRange(dataList);
                _context.SaveChanges();
        }
    }
}
