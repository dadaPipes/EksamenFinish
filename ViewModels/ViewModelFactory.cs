using EksamenFinish.Models;
using EksamenFinish.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksamenFinish.ViewModels
{
    public class ViewModelFactory : IViewModelFactory
    {
        private VM_TempWorker vm_TempWorker;
        public VM_TempWorker CreateTempWorker()
        {
            return new VM_TempWorker();
        }

        public VM_TempWorkerValidation CreateTempWorkerValidation()
        {
            return new VM_TempWorkerValidation(vm_TempWorker);
        }

        public VM_TempWorkerCollection CreateTempWorkerCollection()
        {
            return new VM_TempWorkerCollection();
        }
        public C_TempWorkerCommands CreateTempWorkerCommands() => new C_TempWorkerCommands(vm_TempWorker);
        
        
    }

}
