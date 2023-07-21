using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EduScoreDatabase
{
    /// <summary>
    /// Represents a basic implementation of the ICommand interface for command execution.
    /// </summary>
    public class BasicCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;
        
        /// <summary>
        /// Occurs when changes occur that affect whether the command can be executed.
        /// </summary>
        public event EventHandler? CanExecuteChanged;

        /// <summary>
        /// Initializes a new instance of the BasicCommand class with the specified execute action.
        /// </summary>
        /// <param name="execute">The action to be executed when the command is invoked.</param>
        public BasicCommand(Action execute) : this(execute, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the BasicCommand class with the specified execute and canExecute actions.
        /// </summary>
        /// <param name="execute">The action to be executed when the command is invoked.</param>
        /// <param name="canExecute">The function that determines whether the command can be executed.</param>
        public BasicCommand(Action execute, Func<bool> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        /// <summary>
        /// Determines whether the command can be executed.
        /// </summary>
        /// <param name="parameter">The parameter to be passed to the canExecute function (optional).</param>
        /// <returns>True if the command can be executed, otherwise false.</returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke() ?? true;
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="parameter">The parameter to be passed to the execute action (optional).</param>
        public void Execute(object parameter)
        {
            _execute();
        }
    }
}
