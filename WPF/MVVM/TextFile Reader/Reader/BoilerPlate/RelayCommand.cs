namespace SimpleMVVM.BoilerPlate
{
    using System;
    using System.Windows.Input;

    /// <summary>
    /// Controls the availability of an ICommand entity
    /// </summary>
    public class RelayCommand : ICommand
    {
        /// <summary>
        /// The private action delegate.
        /// </summary>
        private readonly Action privateActionDelegate;

        /// <summary>
        /// The private func delegate.
        /// </summary>
        private readonly Func<bool> privateFunctionalDelegate;

        /// <summary>
        /// Initializes a new instance of the RelayCommand class
        /// </summary>
        /// <param name="actionDelegate">The execute delegate.</param>
        public RelayCommand(Action actionDelegate)
        {
            this.privateActionDelegate = actionDelegate;
        }

        /// <summary>
        /// Initializes a new instance of the RelayCommand class
        /// </summary>
        /// <param name="actionDelegate">The execute delegate.</param>
        /// <param name="functionalDelegate">The functionalDelegate delegate.</param>
        public RelayCommand(Action actionDelegate, Func<bool> functionalDelegate)
        {
            this.privateActionDelegate = actionDelegate;
            this.privateFunctionalDelegate = functionalDelegate;
        }

        /// <summary>
        /// The CanExecuteChanged event handler must be raised by the command implementation when the CanExecute method needs to be reevaluated. 
        /// In XAML, when an instance of ICommand is bound to a control’s Command property through a data-binding, raising the CanExecuteChanged 
        /// event will automatically call the CanExecute method, and the control will be enabled or disabled accordingly.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }
        
        /// <summary>
        /// The method Execute(object) is called when the command is actuated. 
        /// It has one parameter, which can be used to pass additional information 
        /// from the caller to the command.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            this.privateActionDelegate();
        }

        /// <summary>
        /// The method CanExecute(object) returns a Boolean. If the return value is true, it means that the command can be executed. 
        /// The parameter is the same one as for the Execute method. When used in XAML controls that support the Command property, 
        /// the control will be automatically disabled if CanExecute returns false.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns>boolean for CanExecute</returns>
        public bool CanExecute(object parameter)
        {
            return this.privateFunctionalDelegate == null ? true : this.privateFunctionalDelegate();
        }
    }
}