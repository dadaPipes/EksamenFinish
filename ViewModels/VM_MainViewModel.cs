#region usings

using EksamenFinish.Models;
using EksamenFinish.Services;
using EksamenFinish.Services.Commands;
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

        private M_TempWorker m_tempWorker;
        private ObservableCollection<M_TempWorker> s_tempWorkers;
        private VM_TempWorkerValidation vm_tempWorkerValidation;
        private S_TempWorkerRepository s_tempWorkerRepository;
        private C_TempWorkerCommands c_tempWorkerCommands;

        #endregion Field

        public VM_MainViewModel()
        {
            m_tempWorker = new M_TempWorker();
            s_tempWorkerRepository = new S_TempWorkerRepository();
            s_tempWorkers = new ObservableCollection<M_TempWorker>(s_tempWorkerRepository.SearchWorkers(m_tempWorker));
            TempWorkers = s_tempWorkers;
            vm_tempWorkerValidation = new VM_TempWorkerValidation();
            c_tempWorkerCommands = new C_TempWorkerCommands(s_tempWorkerRepository, m_tempWorker, s_tempWorkers);
        }

        #region TempWorkerList

        public ObservableCollection<M_TempWorker> TempWorkers
        {
            get => s_tempWorkers;
            set
            {
                if (s_tempWorkers == value) return;
                s_tempWorkers = value;
                OnPropertyChanged(nameof(TempWorkers));
            }
        }

        #endregion

        #region TempWorker

        private M_TempWorker _selectedTempWorker;
        public M_TempWorker SelectedTempWorker
        {
            get { return _selectedTempWorker; }
            set
            {
                m_tempWorker = value;
                OnPropertyChanged(nameof(SelectedTempWorker));

                //update individual properties of TextBoxes
                TempWorkerFirstName = _selectedTempWorker.FirstName;
                TempWorkerLastName = _selectedTempWorker.LastName;
                TempWorkerAddress = _selectedTempWorker.Address;
                TempWorkerCity = _selectedTempWorker.City;
                TempWorkerZipCode = _selectedTempWorker.ZipCode;
                TempWorkerPersonalNumber = _selectedTempWorker.PersonalNumber;
                TempWorkerIsActiveTrue = _selectedTempWorker.IsActive;
                TempWorkerIsActiveFalse = !_selectedTempWorker.IsActive;
            }
        }

        #endregion TempWorker

        #region TempWorkerProperties

        #region TempWorkerFirstName

        public string TempWorkerFirstName
        {
            get => m_tempWorker.FirstName;
            set
            {
                m_tempWorker.FirstName = value;
                OnPropertyChanged(nameof(TempWorkerFirstName));
                OnPropertyChanged(nameof(ValidateFirstName));
            }
        }

        #endregion

        #region TempWorkerLastName

        public string TempWorkerLastName
        {
            get => m_tempWorker.LastName;
            set
            {
                m_tempWorker.LastName = value;
                OnPropertyChanged(nameof(TempWorkerLastName));
                OnPropertyChanged(nameof(ValidateLastName));
            }
        }

        #endregion

        #region TempWorkerAddress

        public string TempWorkerAddress
        {
            get => m_tempWorker.Address;
            set
            {
                m_tempWorker.Address = value;
                OnPropertyChanged(nameof(TempWorkerAddress));
                OnPropertyChanged(nameof(ValidateAddress));
            }
        }

        #endregion

        #region TempWorkerCity

        public string TempWorkerCity
        {
            get => m_tempWorker.City;
            set
            {
                m_tempWorker.City = value;
                OnPropertyChanged(nameof(TempWorkerCity));
                OnPropertyChanged(nameof(ValidateCity));
            }
        }

        #endregion

        #region TempWorkerZipCode

        public string TempWorkerZipCode
        {
            get => m_tempWorker.ZipCode;
            set
            {
                m_tempWorker.ZipCode = value;
                OnPropertyChanged(nameof(TempWorkerZipCode));
                OnPropertyChanged(nameof(ValidateZipCode));
            }
        }

        #endregion

        #region TempWorkerPersonalNumber

        public string TempWorkerPersonalNumber
        {
            get => m_tempWorker.PersonalNumber;
            set
            {
                m_tempWorker.PersonalNumber = value;
                OnPropertyChanged(nameof(TempWorkerPersonalNumber));
                OnPropertyChanged(nameof(ValidatePersonalNumber));
            }
        }

        #endregion

        #region IsActive

        public bool TempWorkerIsActive
        {
            get => m_tempWorker.IsActive;
            set
            {
                m_tempWorker.IsActive = value;
                OnPropertyChanged(nameof(TempWorkerIsActive));
            }
        }

        private bool _isActiveTrue;

        public bool TempWorkerIsActiveTrue
        {
            get => _isActiveTrue;
            set
            {
                _isActiveTrue = value;
                if (value)
                    TempWorkerIsActive = true;
            }
        }

        private bool _isActiveFalse;

        public bool TempWorkerIsActiveFalse
        {
            get => _isActiveFalse;
            set
            {
                _isActiveFalse = value;
                if (value)
                    TempWorkerIsActive = false;
            }
        }

        #endregion IsActive

        #endregion TempWorkerProperties

        #region TempWorkerValidationProperties

        #region ValidateFirstName

        public string ValidateFirstName =>
        vm_tempWorkerValidation.ValidateFirstName(TempWorkerFirstName);

        #endregion

        #region ValidateLastName

        public string ValidateLastName =>
        vm_tempWorkerValidation.ValidateLastName(TempWorkerLastName);

        #endregion

        #region Validate Address

        public string ValidateAddress =>
        vm_tempWorkerValidation.ValidateAddress(TempWorkerAddress);

        #endregion

        #region ValidateCity

        public string ValidateCity =>
        vm_tempWorkerValidation.ValidateCity(TempWorkerCity);

        #endregion

        #region ValidateZipCode

        public string ValidateZipCode =>
        vm_tempWorkerValidation.ValidateZipCode(TempWorkerZipCode);

        #endregion

        #region ValidatePersonalNumber

        public string ValidatePersonalNumber =>
        vm_tempWorkerValidation.ValidatePersonalNumber(TempWorkerPersonalNumber);

        #endregion

        #endregion

        #region VM_TempWorkerValidation

        public VM_TempWorkerValidation VM_TempWorkerValidation
        {
            get { return vm_tempWorkerValidation; }
            set { vm_tempWorkerValidation = value; }
        }

        #endregion

        #region S_TempWorkerRepository

        public S_TempWorkerRepository S_TempWorkerRepository
        {
            get { return s_tempWorkerRepository; }
            set { s_tempWorkerRepository = value; }
        }

        #endregion TempWorkerRepository

        #region TempWorkerCommands

        public C_TempWorkerCommands CommandErrors
        {
            get { return c_tempWorkerCommands; }
            set { c_tempWorkerCommands = value; }
        }

        public ICommand CreateTempWorkerCommand => c_tempWorkerCommands.CreateTempWorkerCommand;
        public ICommand SearchTempWorkerCommand => c_tempWorkerCommands.SearchTempWorkerCommand;
        public ICommand UpdateTempWorkerCommand => c_tempWorkerCommands.UpdateTempWorkerCommand;

        //public ICommand GetTempWorkerCommand => c_tempWorkerCommands.GetTempWorkerCommand;
        //public ICommand DeleteTempWorkerCommand => c_tempWorkerCommands.DeleteTempWorkerCommand;

        #endregion TempWorkerCommands

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion INotifyPropertyChanged Implementation
    }
}