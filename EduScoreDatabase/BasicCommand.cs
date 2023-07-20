﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EduScoreDatabase
{
    public class BasicCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;
        public event EventHandler? CanExecuteChanged;

        public BasicCommand(Action execute) : this(execute, null)
        {
        }

        public BasicCommand(Action execute, Func<bool> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke() ?? true;
        }

        public void Execute(object parameter)
        {
            _execute();
        }
    }
}
