using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduScoreDatabase.CommandsQueries
{
    /// <summary>
    /// Represents a class responsible for retrieving data from the EduScoreContext database context.
    /// </summary>
    public class ShowData
    {
        private readonly EduScoreContext _context;

        /// <summary>
        /// Initializes a new instance of the ShowData class with the specified EduScoreContext.
        /// </summary>
        /// <param name="context">The EduScoreContext database context.</param>
        public ShowData(EduScoreContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves a list of data of type T from the database context.
        /// </summary>
        /// <typeparam name="T">The type of data to be retrieved.</typeparam>
        /// <returns>A list of data of type T.</returns>
        public List<T> GetData<T>() where T : class
        {
            List<T> dataList = new List<T>();

                dataList = _context.Set<T>().ToList();

            return dataList;
        }

    }
}
