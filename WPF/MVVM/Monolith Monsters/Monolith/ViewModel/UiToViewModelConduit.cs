using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfSimpleGraphics.ViewModel.Helpers;
using System.Windows.Input;
using WpfSimpleGraphics.ViewModel.Utils.Visualisation;
using WpfSimpleGraphics;

namespace WpfSimpleGraphics.ViewModel
{
    class UiToViewModelConduit : CommonBase
    {
        public ICommand UIControlHasChangedNowShowSomething
        {
            get
            {
                return new RelayCommand(MainWindow.GetandShowTerrainPoints);
            }
            set
            {
                RaisePropertyChanged("UIControlHasChangedNowShowSomething");
            }
        }
    }
}
