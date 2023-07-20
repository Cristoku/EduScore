using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduScoreDatabase.CommandsQueries
{
    public class SavingCommands
    {
        private  EduScoreContext _context;

        public SavingCommands()
        {
            _context = new EduScoreContext();
        }

        public void SaveData<T>(T data) where T : class
        {
                _context.Set<T>().Add(data);
                _context.SaveChanges();
        }
        
        public void SaveData<T>(List<T> dataList) where T : class
        {
                _context.Set<T>().AddRange(dataList);
                _context.SaveChanges();
        }
    }
}
