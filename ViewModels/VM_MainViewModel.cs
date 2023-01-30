#region usings

using EksamenFinish.ViewModels.Commands;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

#endregion

namespace EksamenFinish.ViewModels
{
    public class VM_MainViewModel
    {
        private readonly ITempWorkerViewModelFactory _tempWorkerViewModelFactory;

        public VM_MainViewModel() : this(new ViewModelFactory()) { }

        public VM_MainViewModel(ITempWorkerViewModelFactory tempWorkerViewModelFactory)
        {
            _tempWorkerViewModelFactory = tempWorkerViewModelFactory;
            TempWorkerViewModel = _tempWorkerViewModelFactory.CreateTempWorkerViewModel();
            TempWorkerValidationViewModel = _tempWorkerViewModelFactory.CreateTempWorkerValidationViewModel();
            TempWorkerCollectionViewModel = _tempWorkerViewModelFactory.CreateTempWorkerCollectionViewModel();
            TempWorkerCommands = _tempWorkerViewModelFactory.CreateTempWorkerCommands(TempWorkerViewModel);
        }
        public VM_TempWorker TempWorkerViewModel { get; }
        public VM_TempWorkerValidation TempWorkerValidationViewModel { get; }
        public VM_TempWorkerCollection TempWorkerCollectionViewModel { get; }
        public C_TempWorkerCommands TempWorkerCommands { get; }

        public IViewModel CreateViewModel(string type)
        {
            switch (type)
            {
                case "TempWorkerValidation":
                    return TempWorkerValidationViewModel;
                case "TempWorker":
                    return TempWorkerViewModel;
                case "TempWorkerCollection":
                    return TempWorkerCollectionViewModel;
                case "TempWorkerCommands":
                    return TempWorkerCommands;
                default:
                    throw new ArgumentException("Invalid ViewModel type specified.");
            }
        }
    }


}