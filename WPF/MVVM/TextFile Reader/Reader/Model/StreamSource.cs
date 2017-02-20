// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StreamSource.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the StreamSource type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WpfApplication1.Model
{
    using System.Collections.ObjectModel;
    using BoilerPlate;

    /// <summary>
    /// The stream source.
    /// </summary>
    public static class StreamSource
    {
        /// <summary>
        /// Gets the file path.
        /// </summary>
        public static ObservableCollection<string> FilePath
        {
            get
            {
                return Select();
            }
        }

        /// <summary>
        /// 'Selects' the file(s) to scan.
        /// </summary>
        /// <returns>
        /// "ObservableCollection" of FilePath string(s).
        /// </returns>
        private static ObservableCollection<string> Select()
        {
            var filepath = new ObservableCollection<string>
                               {
                                   "TESTDATA\\The Three Little Pigs.txt"
                               };
            return filepath;
        }
    }
}