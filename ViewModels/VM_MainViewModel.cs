using EksamenFinish.ViewModels.Commands;

namespace EksamenFinish.ViewModels
{
    public class VM_MainViewModel
    {
        public VM_TempWorker vm_TempWorker { get; set; }
        public VM_TempWorkerValidation vm_TempWorkerValidation { get; set; }
        public VM_TempWorkerCollection vm_TempWorkerCollection { get; set; }
        public C_TempWorkerCommands c_TempWorkerCommands { get; set; }


        // Default constructor that creates an instance of ViewModelFactory
        public VM_MainViewModel() : this(new ViewModelFactory()) { }

        public VM_MainViewModel(IViewModelFactory factory)
        {
            vm_TempWorker = factory.CreateTempWorker();
            vm_TempWorkerValidation = factory.CreateTempWorkerValidation();
            vm_TempWorkerCollection = factory.CreateTempWorkerCollection();
            c_TempWorkerCommands = factory.CreateTempWorkerCommands();
        }

    }
}