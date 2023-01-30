#region Usings

using EksamenFinish.Models;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

#endregion

namespace EksamenFinish.ViewModels
{
    public class VM_TempWorker : IViewModel, INotifyPropertyChanged
    {
        private M_TempWorker _model;

        public VM_TempWorker()
        {
            _model = new M_TempWorker();
        }

        // Used for data binding in the UI layer.

        #region TempWorker Guid Id

        public Guid Id
        {
            get => _model.Id;
            set
            {
                _model.Id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        #endregion TempWorker Guid Id

        #region TempWorker string FirstName

        public string FirstName
        {
            get => _model.FirstName;
            set
            {
                _model.FirstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        #endregion TempWorker string FirstName

        #region TempWorker string LastName

        public string LastName
        {
            get => _model.LastName;
            set
            {
                _model.LastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        #endregion TempWorker string LastName

        #region TempWorker string Address

        public string Address
        {
            get => _model.Address;
            set
            {
                _model.Address = value;
                OnPropertyChanged(nameof(Address));
            }
        }

        #endregion TempWorker string Address

        #region TempWorker string City

        public string City
        {
            get => _model.City;
            set
            {
                _model.City = value;
                OnPropertyChanged(nameof(City));
            }
        }

        #endregion TempWorker string City

        #region TempWorker int ZipCode

        public int ZipCode
        {
            get => _model.ZipCode; set
            {
                _model.ZipCode = value;
                OnPropertyChanged(nameof(ZipCode));
            }
        }

        #endregion TempWorker int ZipCode

        #region TempWorker string PersonalNumber

        public string PersonalNumber
        {
            get => _model.PersonalNumber; set
            {
                _model.PersonalNumber = value;
                OnPropertyChanged(nameof(PersonalNumber));
            }
        }

        #endregion TempWorker string PersonalNumber

        #region TempWorker bool IsActive

        // The value of the TempWorkerIsActive property is based on the values of TempWorkerIsActiveTrue and TempWorkerIsActiveFalse.
        public bool IsActive
        {
            get => _model.IsActive; set
            {
                _model.IsActive = value;
                OnPropertyChanged(nameof(IsActive));
            }
        }

        #region IsActive True

        private bool _IsActiveTrue;

        public bool IsActiveTrue
        {
            get => _IsActiveTrue;
            set
            {
                _IsActiveTrue = value;
                if (value)
                {
                    IsActiveFalse = false;
                    IsActive = true;
                }
                OnPropertyChanged(nameof(IsActiveTrue));
            }
        }

        #endregion IsActive True

        #region IsActive False

        private bool _IsActiveFalse;

        public bool IsActiveFalse
        {
            get => _IsActiveFalse;
            set
            {
                _IsActiveFalse = value;
                if (value)
                {
                    IsActiveTrue = false;
                    IsActive = false;
                }
                OnPropertyChanged(nameof(IsActiveFalse));
            }
        }

        #endregion IsActive False

        #endregion TempWorker bool IsActive

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion INotifyPropertyChanged Implementation
    }
}