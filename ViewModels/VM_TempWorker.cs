#region Usings

using EksamenFinish.Models;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

#endregion

namespace EksamenFinish.ViewModels
{
    public class VM_TempWorker : INotifyPropertyChanged
    {
        private M_TempWorker _model;

        public VM_TempWorker()
        {
            _model = new M_TempWorker();
        }

        // Used for data binding in the UI layer.

        public Guid Id
        {
            get => _model.Id;
            set
            {
                _model.Id = value;
                OnPropertyChanged(nameof(Id));
                
            }
        }

        public string FirstName
        {
            get => _model.FirstName;
            set
            {
                _model.FirstName = value;
                OnPropertyChanged(nameof(FirstName));
            }

        }

        public string LastName
        {
            get => _model.LastName;
            set
            { 
                _model.LastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        public string FullName => FirstName + " " + LastName;

        public string City
        {
            get => _model.City;
            set
            {
                _model.City = value;
                OnPropertyChanged(nameof(City));
            }
        }

        public string Address
        {
            get => _model.Address;
            set { 
                _model.Address = value;
                OnPropertyChanged(nameof(Address));
            }
        }

        public int ZipCode
        {
            get => _model.ZipCode; set
            {
                _model.ZipCode = value;
                OnPropertyChanged(nameof(ZipCode));
            }
        }



        public string PersonalNumber
        {
            get => _model.PersonalNumber; set
            {
                _model.PersonalNumber = value;
                OnPropertyChanged(nameof(PersonalNumber));
            }
        }

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