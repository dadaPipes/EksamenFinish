using EksamenFinish.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace EksamenFinish.ViewModels
{
    //ViewModel for TempWorker collection
    public class VM_TempWorkerCollection : IViewModel, INotifyPropertyChanged
    {
        public VM_TempWorker TempWorker { get; set; }

        private S_TempWorkerRepository s_tempWorkerRepository { get; set; }

        public VM_TempWorkerCollection()
        {
            s_tempWorkerRepository = new S_TempWorkerRepository();
        }

        private ObservableCollection<VM_TempWorker> _tempWorkers;

        public ObservableCollection<VM_TempWorker> TempWorkers
        {
            get { return _tempWorkers; }
            set
            {
                _tempWorkers = value;
                OnPropertyChanged(nameof(TempWorkers));
            }
        }


        /// <summary>
        /// Takes a VM_TempWorker as an argument. Calls the SearchTempWorkers method and returns a List.
        /// The List is used to create an instance of an ObservableCollection and sets it to TempWorkers property.
        /// Notifies TempWorkers property of the change.
        /// </summary>
        
        public void GetTempWorkers(VM_TempWorker vm_tempWorker)
        {
            List<VM_TempWorker> tempWorkers = s_tempWorkerRepository.SearchTempWorkers(vm_tempWorker);
            TempWorkers = new ObservableCollection<VM_TempWorker>(tempWorkers);
            OnPropertyChanged(nameof(TempWorkers));
        }

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion INotifyPropertyChanged Implementation
    }
}