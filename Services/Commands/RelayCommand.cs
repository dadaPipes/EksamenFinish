using System;
using System.Windows.Input;

namespace EksamenFinish.Services.Commands
{
    public class RelayCommand : ICommand
    {
        private bool isExecuting;
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute();
        }

        public void Execute(object parameter)
        {
            if (isExecuting) return;

            isExecuting = true;
            _execute();
            isExecuting = false;
        }
    }
}