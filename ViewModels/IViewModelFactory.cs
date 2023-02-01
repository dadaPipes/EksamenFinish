using EksamenFinish.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksamenFinish.ViewModels
{
    public interface IViewModelFactory
    {

        VM_TempWorker CreateTempWorker();
        VM_TempWorkerValidation CreateTempWorkerValidation();
        VM_TempWorkerCollection CreateTempWorkerCollection();

        C_TempWorkerCommands CreateTempWorkerCommands();
    }

}
