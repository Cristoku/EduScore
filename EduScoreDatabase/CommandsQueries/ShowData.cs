using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduScoreDatabase.CommandsQueries
{
    public class ShowData
    {
        private readonly EduScoreContext _context;

        public ShowData(EduScoreContext context)
        {
            _context = context;
        }

        public List<T> GetData<T>() where T : class
        {
            List<T> dataList = new List<T>();

                dataList = _context.Set<T>().ToList();

            return dataList;
        }

    }
}
