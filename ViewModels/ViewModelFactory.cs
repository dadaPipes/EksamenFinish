using EksamenFinish.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksamenFinish.ViewModels
{
    // Provides implementation of the methods to create instances of ViewModels, and a CommandClass related to TempWorker
    // Returns new intances of the classes 
    public class ViewModelFactory : ITempWorkerViewModelFactory
    {
        public VM_TempWorker CreateTempWorkerViewModel()
        {
            return new VM_TempWorker();
        }

        public VM_TempWorkerValidation CreateTempWorkerValidationViewModel()
        {
            return new VM_TempWorkerValidation();
        }

        public VM_TempWorkerCollection CreateTempWorkerCollectionViewModel()
        {
            return new VM_TempWorkerCollection();
        }

        public C_TempWorkerCommands CreateTempWorkerCommands(VM_TempWorker tempWorker)
        {
            return new C_TempWorkerCommands(tempWorker);
        }
    }

}
