using EksamenFinish.Models;
using EksamenFinish.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EksamenFinish.ViewModels
{
    //ViewModel for TempWorker collection
    public class VM_TempWorkerCollection : VM_MainViewModel
    {
        public ObservableCollection<VM_TempWorker> TempWorkers { get; set; }
        private S_TempWorkerRepository s_tempWorkerRepository { get; set; }

        public VM_TempWorkerCollection()
        {
            TempWorkers = new ObservableCollection<VM_TempWorker>();
            s_tempWorkerRepository = new S_TempWorkerRepository();
        }

        public ObservableCollection<VM_TempWorker> GetTempWorkers(VM_TempWorker vm_tempWorker)
        {
            List<VM_TempWorker> tempWorkers = s_tempWorkerRepository.SearchTempWorkers(vm_tempWorker);
            return new ObservableCollection<VM_TempWorker>(tempWorkers);
        }
    }
}