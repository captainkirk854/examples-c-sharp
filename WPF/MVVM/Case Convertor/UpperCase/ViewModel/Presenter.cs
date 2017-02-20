namespace UpperCase.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using UpperCase.Model;

    public class Presenter : ObservableObject
    {
        private readonly TextConverter _textConverter = new TextConverter(s => s.ToUpper());
        private string nameOfXamlProperty = "SomeText";

        private string _someText;
        public string SomeText
        {
            get 
            { 
                return _someText; 
            }
            set
            {
                _someText = value;
                RaisePropertyChangedEvent(nameOfXamlProperty); // This method is from ObservableObject class
            }
        }

        private readonly ObservableCollection<string> _history = new ObservableCollection<string>();
        public IEnumerable<string> History
        {
            get 
            { 
                return _history; 
            }
        }

        public ICommand ConvertTextCommand
        {
            get 
            { 
                return new DelegateCommand(ConvertText); 
            }
        }

        private void ConvertText()
        {
            AddToHistory(_textConverter.ConvertText(SomeText));
            SomeText = String.Empty;
        }

        private void AddToHistory(string item)
        {
            if (!_history.Contains(item))
            {
                _history.Add(item);
            }
        }
    }
}
