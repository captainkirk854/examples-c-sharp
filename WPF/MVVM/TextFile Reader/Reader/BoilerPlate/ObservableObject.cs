// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObservableObject.cs" company="">
//   
// </copyright>
// <summary>
//   Houses the common events and methods for observable ViewModel data
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WpfApplication1.BoilerPlate
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices; // For [CallerMemberName] attribute ...

    /// <summary>
    /// Houses the common events and methods for observable ViewModel data
    /// </summary>
    public class ObservableObject : INotifyPropertyChanged
    {
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the property changed event.
        /// Using the [CallerMemberName] attribute automatically tells the compiler to use the correct propertyName.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        public void RaisePropertyChangedEvent([CallerMemberName] string propertyName = null)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}