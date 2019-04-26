using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace Správa_projektov_firmy.Commands
{
    /// <summary>
    /// Trieda ktorá slúži na vytvorenie Commandu. Implementuje interface ICommand.
    /// </summary>
    class Command : ICommand
    {
        private Action<object> _execute;
        private Func<object, bool> _enabled;
        /// <summary>
        /// Konštruktor ktorý slúži na vytvorenie Comnndu
        /// </summary>
        /// <param name="execute">Metoda ktorá sa má vykonať </param>
        /// <param name="enabled">Metoda ktorá dovoľuje vykonanie </param>
        public Command(Action<object> execute, Func<object,bool> enabled = null)
        {
            _execute = execute;
            _enabled = enabled;
        }
        /// <summary>
        /// Event ktorý čaká na zmenu 
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        /// <summary>
        /// Overenie spustenia Comnndu
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns>Či je ho možné spustit</returns>
        public bool CanExecute(object parameter)
        {
            if (_enabled == null)
            {
                return true;
            }
            return _enabled.Invoke(parameter);
        }
        /// <summary>
        /// Vykonanie samotného Commandu
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            _execute.Invoke(parameter);
        }
    }
}
