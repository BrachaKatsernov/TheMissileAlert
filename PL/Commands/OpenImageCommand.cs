using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PL.ViewModels;

namespace PL.Commands
{
    public class OpenImageCommand : ICommand
    {
        public FallsVM CurrentVM { get; }

        public OpenImageCommand()
        {

        }

        public OpenImageCommand(FallsVM Vm)
        {
            CurrentVM = Vm;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }

            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
       
        public void Execute(object parameter)
        {
            var path = parameter.ToString();
            Process.Start(path);


        }
    }
}
