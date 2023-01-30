#region usings

using System.ComponentModel;
using System.Runtime.CompilerServices;

#endregion

namespace EksamenFinish.ViewModels
{
    public class VM_MainViewModel : INotifyPropertyChanged
    {
       #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion INotifyPropertyChanged Implementation
    }
}

// Help ME please !