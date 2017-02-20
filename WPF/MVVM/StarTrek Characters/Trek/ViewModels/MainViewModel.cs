namespace SimpleMVVM.ViewModels
{
    using System.Collections.ObjectModel; // For ObservableCollection class ..
    using System.Windows.Input; // For ICommand interface ..
    using SimpleMVVM.BoilerPlate; // For access to boiler plate classes ..
    using SimpleMVVM.Models; // For access to our StarTrek characters ..

    /// <summary>
    /// This class has the following properties which "notify" when changed
    /// and which can be used for binding to XAML controls:
        /// > AllTrekCharacters
        /// > CurrentlySelectedTrekCharacter
    /// </summary>
    class MainViewModel : ObservableObject
    {
        # region DATA
        /// <summary>
        /// Grab database data
        /// </summary>
        private ObservableCollection<StarTrekCharacter> trekCharactersDataset = Database.Select();

        /// <summary>
        /// Track currently selected character
        /// </summary>
        private StarTrekCharacter currentlySelectedTrekCharacter;

        /// <summary>
        /// Property: Entire Dataset
        /// Raise Property Change: No
        /// </summary>
        public ObservableCollection<StarTrekCharacter> AllTrekCharacters
        {
            get { return this.trekCharactersDataset; }
        }

        /// <summary>
        /// Property: Currently Selected
        /// Raise Property Change: Yes
        /// </summary>
        public StarTrekCharacter CurrentlySelectedTrekCharacter
        {
            get
            {
                // Check if currently selected item is correct to make command button available ...
                this.ControlCommandButtonOKAvailability();

                // Return currently selected item ...
                return this.currentlySelectedTrekCharacter;
            }
            set
            {
                if (this.currentlySelectedTrekCharacter != value)
                {
                    this.currentlySelectedTrekCharacter = value;
                    RaisePropertyChangedEvent();
                }
            }
        }
        #endregion


        #region Command Button
        /// <summary>
        /// Define Command Button property to bind with XAML ..
        /// </summary> 
        bool commandOK = false;
        public ICommand CommandButtonOK
        {
            get;
            private set;
        }

        /// <summary>
        /// Method to Control CommandButton availability ..
        /// </summary>
        void ControlCommandButtonOKAvailability() 
        {
            if (this.currentlySelectedTrekCharacter.Appellation == "Spock")
            {
                this.commandOK = true;
            }
            else
            {
                this.commandOK = false;
            }
        }

        /// <summary>
        /// Something that happens when CommandButton is actually selected ..
        /// </summary>
        void CommandButtonOKSelectedNowDoSomething()
        {
            this.commandOK = false; // disable button ..
            this.CurrentlySelectedTrekCharacter = this.trekCharactersDataset[0]; // reset to 1st in collection - the best item
        }
        #endregion

        /// <summary>
        /// Class Constructor - defaults selected character
        /// </summary>
        public MainViewModel()
        {
            // Initialise to 1st in collection .. 
            this.CurrentlySelectedTrekCharacter = this.trekCharactersDataset[0];

            // Hook up our command button and set it to listen ...
            this.ControlCommandButtonOKAvailability();
            this.CommandButtonOK = new RelayCommand(CommandButtonOKSelectedNowDoSomething, () => this.commandOK);
        }
    }
}
