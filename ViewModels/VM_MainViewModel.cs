#region usings

using EksamenFinish.Models;
using EksamenFinish.Services.Commands;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

#endregion

namespace EksamenFinish.ViewModels
{
    public class VM_MainViewModel : INotifyPropertyChanged
    {
        #region Field

        //ViewModel for TempWorker validation
        public VM_TempWorkerValidation TempWorkerValidationViewModel { get; set; }

        //Commands for TempWorker operations
        private C_TempWorkerCommands _tempWorkerCommands;

        //ViewModel for TempWorker collection
        private VM_TempWorkerCollection _tempWorkersCollection;

        //Observable collection for TempWorker data
        private ObservableCollection<VM_TempWorker> _tempWorkers { get; set; }

        #endregion

        public VM_MainViewModel()
        {
            _selectedTempWorker = new VM_TempWorker();
            _tempWorkerCommands = new C_TempWorkerCommands(SelectedTempWorker);
            TempWorkerValidationViewModel = new VM_TempWorkerValidation();
            _tempWorkers = new ObservableCollection<VM_TempWorker>();
            _tempWorkersCollection = new VM_TempWorkerCollection();
        }

        #region Selected TempWorker

        private VM_TempWorker _selectedTempWorker;

        public VM_TempWorker SelectedTempWorker
        {
            get => _selectedTempWorker;
            set
            {
                _selectedTempWorker = value;
                OnPropertyChanged(nameof(SelectedTempWorker));
                OnPropertyChanged(nameof(FirstName));
            }
        }

        #endregion

        public string FirstName
        {
            get => _selectedTempWorker != null ? _selectedTempWorker.FirstName : string.Empty;
            set
            {
                if (_selectedTempWorker != null)
                {
                    _selectedTempWorker.FirstName = value;
                    OnPropertyChanged(nameof(FirstName));
                    OnPropertyChanged(nameof(SelectedTempWorker.FirstName));
                }
            }
        }



        #region TempWorker Collection

        public ObservableCollection<VM_TempWorker> TempWorkers
        {
            get => _tempWorkersCollection.GetTempWorkers(_selectedTempWorker);
            set
            {
                _tempWorkersCollection.TempWorkers = value;
                OnPropertyChanged(nameof(TempWorkers));
            }
        }

        #endregion

        #region TempWorker Properties

        #region TempWorker Id

        private Guid _tempWorkerId;

        public Guid TempWorkerId
        {
            get => _tempWorkerId;
            set
            {
                _tempWorkerId = value;
                OnPropertyChanged(nameof(TempWorkerId));
            }
        }

        #endregion

        #region TempWorker FirstName

        //public string FirstName
        //{
        //    get => _selectedTempWorker != null ? _selectedTempWorker.FirstName : string.Empty;
        //    set
        //    {
        //        if (_selectedTempWorker != null)
        //        {
        //            _selectedTempWorker.FirstName = value;
        //            OnPropertyChanged(nameof(FirstName));
        //            OnPropertyChanged(nameof(SelectedTempWorker.FirstName));
        //        }
        //    }
        //}

        #endregion

        #region TempWorker LastName

        private string _tempWorkerlastName;

        public string TempWorkerLastName
        {
            get => _tempWorkerlastName;
            set
            {
                _tempWorkerlastName = value;
                OnPropertyChanged(nameof(TempWorkerLastName));
                OnPropertyChanged(nameof(ValidateTempWorkerLastName));
                SelectedTempWorker.LastName = value;
                OnPropertyChanged(nameof(SelectedTempWorker));
            }
        }

        #endregion

        #region TempWorker Address

        private string _tempWorkerAddress;

        public string TempWorkerAddress
        {
            get => _tempWorkerAddress;
            set
            {
                _tempWorkerAddress = value;
                OnPropertyChanged(nameof(TempWorkerAddress));
                OnPropertyChanged(nameof(ValidateTempWorkerAddress));
                SelectedTempWorker.Address = value;
                OnPropertyChanged(nameof(SelectedTempWorker));
            }
        }

        #endregion

        #region TempWorker City

        private string _tempWorkerCity;

        public string TempWorkerCity
        {
            get => _tempWorkerCity;
            set
            {
                _tempWorkerCity = value;
                OnPropertyChanged(nameof(TempWorkerCity));
                OnPropertyChanged(nameof(ValidateTempWorkerCity));
                SelectedTempWorker.City = value;
                OnPropertyChanged(nameof(SelectedTempWorker));
            }
        }

        #endregion

        #region TempWorker ZipCode

        private int _tempWorkerZipCode;

        public int TempWorkerZipCode

        {
            get => _tempWorkerZipCode;
            set
            {
                _tempWorkerZipCode = value;
                OnPropertyChanged(nameof(TempWorkerZipCode));
                OnPropertyChanged(nameof(ValidateTempWorkerZipCode));
                SelectedTempWorker.ZipCode = value;
                OnPropertyChanged(nameof(SelectedTempWorker));
            }
        }

        #endregion

        #region TempWorker PersonalNumber

        private string _tempWorkerPersonalNumber;

        public string TempWorkerPersonalNumber

        {
            get => _tempWorkerPersonalNumber;
            set
            {
                _tempWorkerPersonalNumber = value;
                OnPropertyChanged(nameof(TempWorkerPersonalNumber));
                OnPropertyChanged(nameof(ValidateTempWorkerPersonalNumber));
                SelectedTempWorker.PersonalNumber = value;
                OnPropertyChanged(nameof(SelectedTempWorker));
            }
        }

        #endregion

        #region TempWorker IsActive

        #region IsActive

        // The value of the TempWorkerIsActive property is based on the values of TempWorkerIsActiveTrue and TempWorkerIsActiveFalse.
        private bool _tempWorkerIsActive;

        public bool TempWorkerIsActive
        {
            get => _tempWorkerIsActive;
            set
            {
                _tempWorkerIsActive = value;
                OnPropertyChanged(nameof(TempWorkerIsActive));
                SelectedTempWorker.IsActive = value;
                OnPropertyChanged(nameof(SelectedTempWorker));
            }
        }

        #endregion

        #region IsActive True

        private bool _tempWorkerIsActiveTrue;

        public bool TempWorkerIsActiveTrue
        {
            get => _tempWorkerIsActiveTrue;
            set
            {
                _tempWorkerIsActiveTrue = value;
                if (value)
                {
                    TempWorkerIsActiveFalse = false;
                    TempWorkerIsActive = true;
                }
                OnPropertyChanged(nameof(TempWorkerIsActiveTrue));
            }
        }

        #endregion

        #region IsActive False

        private bool _tempWorkerIsActiveFalse;

        public bool TempWorkerIsActiveFalse
        {
            get => _tempWorkerIsActiveFalse;
            set
            {
                _tempWorkerIsActiveFalse = value;
                if (value)
                {
                    TempWorkerIsActiveTrue = false;
                    TempWorkerIsActive = false;
                }
                OnPropertyChanged(nameof(TempWorkerIsActiveFalse));
            }
        }

        #endregion

        #endregion

        #endregion

        #region TempWorker Validation Properties

        #region Validate TempWorkerFirstName

        // The ValidateFirstName property is used to validate the TempWorkerFirstName field in the UI
        public string ValidateTempWorkerFirstName =>
            TempWorkerValidationViewModel.ValidateFirstName(FirstName);

        #endregion

        #region Validate TempWorkerLastName

        public string ValidateTempWorkerLastName =>
            TempWorkerValidationViewModel.ValidateLastName(TempWorkerLastName);

        #endregion

        #region Validate TempWorkerAddress

        public string ValidateTempWorkerAddress =>
            TempWorkerValidationViewModel.ValidateAddress(TempWorkerAddress);

        #endregion

        #region Validate TempWorkerCity

        public string ValidateTempWorkerCity =>
            TempWorkerValidationViewModel.ValidateCity(TempWorkerCity);

        #endregion

        #region Validate TempWorkerPersonalNumber

        public string ValidateTempWorkerPersonalNumber =>
            TempWorkerValidationViewModel.ValidatePersonalNumber(TempWorkerPersonalNumber);

        #endregion

        #region Validate TempWorkerZipCode

        public string ValidateTempWorkerZipCode =>
            TempWorkerValidationViewModel.ValidateZipCode(TempWorkerZipCode.ToString());

        #endregion

        #endregion

        #region TempWorkerCommands

        // The CreateTempWorkerCommand allows for creating a new temp worker by calling the corresponding method in the TempWorkerCommands class
        //public ICommand CreateTempWorkerCommand => _tempWorkerCommands.CreateTempWorkerCommand;

        // The SearchTempWorkerCommand allows for searching for a temp worker by calling the corresponding method in the TempWorkerCommands class
        //public ICommand SearchTempWorkerCommand => _tempWorkerCommands.SearchTempWorkerCommand;

        // The UpdateTempWorkerCommand allows for updating a temp worker by calling the corresponding method in the TempWorkerCommands class
        public ICommand UpdateTempWorkerCommand => _tempWorkerCommands.UpdateTempWorkerCommand;

        // The DeleteTempWorkerCommand allows for deleting a temp worker by calling the corresponding method in the TempWorkerCommands class
        //public ICommand DeleteTempWorkerCommand => _tempWorkerCommands.DeleteTempWorkerCommand;

        #endregion

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion INotifyPropertyChanged Implementation
    }
}