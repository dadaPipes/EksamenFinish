using EksamenFinish.ViewModels.Commands;

namespace EksamenFinish.ViewModels
{
    // Provides a contract for creating ViewModels, and a CommandClass related to TempWorker
    public interface ITempWorkerViewModelFactory
    {
        VM_TempWorker CreateTempWorkerViewModel();
        VM_TempWorkerValidation CreateTempWorkerValidationViewModel();
        VM_TempWorkerCollection CreateTempWorkerCollectionViewModel();

        C_TempWorkerCommands CreateTempWorkerCommands(VM_TempWorker tempWorker);
    }
}
