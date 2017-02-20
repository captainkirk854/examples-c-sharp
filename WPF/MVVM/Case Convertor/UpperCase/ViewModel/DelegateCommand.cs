namespace UpperCase.ViewModel
{
    using System;
    using System.Windows.Input;

    public class DelegateCommand : ICommand
    {
        private readonly Action actionForExecute;

        public DelegateCommand(Action inputAction)
        {
            actionForExecute = inputAction;
        }

        public void Execute(object parameter)
        {
            actionForExecute();
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

#pragma warning disable 67 // Disable event never used warning ..
        public event EventHandler CanExecuteChanged 
        { 
            add 
            {
            } 
            remove 
            {
            } 
        }
#pragma warning restore 67
    }
}
