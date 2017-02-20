namespace WpfSimpleGraphics.ViewModel.Helpers
{
    using System.ComponentModel;

    class CommonBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                PropertyChangedEventArgs args = new PropertyChangedEventArgs(propertyName);

                //  Raise the PropertyChanged event ..
                handler(this, args);
            }
        }
    }
}