namespace WpfSimpleGraphics.ViewModel.Helpers
{
    using System;
    using System.Windows.Input;

    class RelayCommand : ICommand
    {
        private readonly Action actionToRelay;

        public RelayCommand(Action actionToHandle)
        {
            actionToRelay = actionToHandle;
            actionToRelay(); // Execute the action ...
        }

        public void Execute(object parameter)
        {
            actionToRelay();
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged
        {
            add{ }
            remove{ }
        }
    }
}
