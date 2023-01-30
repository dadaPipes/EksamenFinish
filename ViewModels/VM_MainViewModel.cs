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
        // Private field to store an instance of ITempWorkerViewModelFactory
        private readonly ITempWorkerViewModelFactory _tempWorkerViewModelFactory;

        // Default constructor that creates an instance of ViewModelFactory
        public VM_MainViewModel() : this(new ViewModelFactory()) { }

        // Overloaded constructor that takes an instance of ITempWorkerViewModelFactory as a parameter
        public VM_MainViewModel(ITempWorkerViewModelFactory tempWorkerViewModelFactory)
        {
            // Assign the parameter to the private field
            _tempWorkerViewModelFactory = tempWorkerViewModelFactory;

            // Create instances of several view models using the _tempWorkerViewModelFactory object
            TempWorkerViewModel = _tempWorkerViewModelFactory.CreateTempWorkerViewModel();
            TempWorkerValidationViewModel = _tempWorkerViewModelFactory.CreateTempWorkerValidationViewModel();
            TempWorkerCollectionViewModel = _tempWorkerViewModelFactory.CreateTempWorkerCollectionViewModel();
            TempWorkerCommands = _tempWorkerViewModelFactory.CreateTempWorkerCommands(TempWorkerViewModel);
        }

        // Read-only properties to store the instances of the view models
        public VM_TempWorker TempWorkerViewModel { get; }
        public VM_TempWorkerValidation TempWorkerValidationViewModel { get; }
        public VM_TempWorkerCollection TempWorkerCollectionViewModel { get; }
        public C_TempWorkerCommands TempWorkerCommands { get; }

        // Method to return an instance of IViewModel based on the string type parameter
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
                    // Throw an exception if the type is not recognized
                    throw new ArgumentException("Invalid ViewModel type specified.");
            }
        }
    }



}