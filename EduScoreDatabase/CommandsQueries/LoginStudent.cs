using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduScoreDatabase.CommandsQueries
{
    public class LoginStudent
    {
        private readonly EduScoreContext _context;

        public LoginStudent(EduScoreContext context)
        {
            _context = context;
        }
        public bool LoginUser(string username, string password)
        {
            return _context.Students.Any(u => u.Name == username && u.Password == password);
        }
    }
}
