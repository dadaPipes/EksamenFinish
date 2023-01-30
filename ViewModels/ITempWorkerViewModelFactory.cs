using EksamenFinish.ViewModels.Commands;

namespace EksamenFinish.ViewModels
{
    public interface ITempWorkerViewModelFactory
    {
        VM_TempWorker CreateTempWorkerViewModel();
        VM_TempWorkerValidation CreateTempWorkerValidationViewModel();
        VM_TempWorkerCollection CreateTempWorkerCollectionViewModel();

        C_TempWorkerCommands CreateTempWorkerCommands(VM_TempWorker tempWorker);
    }
}
