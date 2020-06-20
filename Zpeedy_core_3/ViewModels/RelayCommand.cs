using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Zpeedy_core_3
{
    public class RelayCommand : ICommand
    {
        /// <summary>
        /// The action to run
        /// </summary>
        private Action _actionToRun;

        /// <summary>
        /// This event fires when CanExecute value changes.
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => {};

        public RelayCommand(Action action)
        {
            _actionToRun = action;
        }

        /// <summary>
        /// A relay command can always execute
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            _actionToRun();
        }
    }
}
