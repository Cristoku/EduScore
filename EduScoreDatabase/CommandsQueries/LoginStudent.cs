using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduScoreDatabase.CommandsQueries
{
    /// <summary>
    /// Represents a class responsible for student login in the EduScore application.
    /// </summary>
    public class LoginStudent
    {
        private readonly EduScoreContext _context;

        /// <summary>
        /// Initializes a new instance of the LoginStudent class with the specified EduScoreContext.
        /// </summary>
        /// <param name="context">The EduScoreContext database context.</param>
        public LoginStudent(EduScoreContext context)
        {
            _context = context;
        }
        
        /// <summary>
        /// Performs the student login process.
        /// </summary>
        /// <param name="username">The username (student's name) to be used for login.</param>
        /// <param name="password">The password to be used for login.</param>
        /// <returns>True if the login is successful, otherwise false.</returns>
        public bool LoginUser(string username, string password)
        {
            return _context.Students.Any(u => u.Name == username && u.Password == password);
        }
    }
}
