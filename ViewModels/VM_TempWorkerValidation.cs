using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace EksamenFinish.ViewModels
{
    public class VM_TempWorkerValidation : INotifyPropertyChanged
    {
        // //ViewModel for TempWorker validation
        // Responsible for validating the properties of a TempWorker,
        // and returning an error message if the name is invalid.

        #region Field

        private VM_TempWorker vm_tempWorker;

        //The regular expression ^[a-zA-Z]*$ is used to match any string that consists only of letters (uppercase or lowercase).
        private readonly Regex _onlyLetters = new Regex("^[a-zA-Z]*$");

        //Regular expression ^[0-9]*$ to match any string that consists only of digits.
        private readonly Regex _onlyDigits = new Regex("^[0-9]*$");



        #endregion Field

        public VM_TempWorkerValidation(VM_TempWorker vm_tempWorker)
        {
            this.vm_tempWorker = vm_tempWorker;
        }

        public string ValidateFirstName
        {
            get => vm_tempWorker.FirstName;
            set
            {
                // assigns an empty string as default value if firstName is null or empty
                vm_tempWorker.FirstName ??= "";

                if (vm_tempWorker.FirstName == "X Æ A-12")
                {
                    value = "I see you're trying to be unique, but X Æ A-12 is not your name.";
                }
                else if (!_onlyLetters.IsMatch(vm_tempWorker.FirstName))
                {
                    value = "Invalid first name";
                }
                else if (vm_tempWorker.FirstName.Length > 50)
                {
                    value = "First name must be 50 characters or less.";
                }
                else
                {
                    value = "";
                }
                vm_tempWorker.FirstName = value;
                OnPropertyChanged(nameof(vm_tempWorker.FirstName));
            }
        }

        public string ValidateLastName
        {
            get => vm_tempWorker.LastName;
            set
            {
                vm_tempWorker.LastName ??= "";

                if (!_onlyLetters.IsMatch(vm_tempWorker.LastName))
                {
                    value = "Invalid Last name";
                }
                else if (vm_tempWorker.LastName.Length > 50)
                {
                    value = "Last name must be 50 characters or less.";
                }
                else
                {
                    value = "";
                }
                vm_tempWorker.LastName = value;
                OnPropertyChanged(nameof(vm_tempWorker.LastName));
            }
        }

        public string ValidateAddress
        {
            get => vm_tempWorker.Address;

            set

            {
                vm_tempWorker.Address ??= "";

                if (!_onlyLetters.IsMatch(vm_tempWorker.Address))
                {
                    value = "Invalid address";
                }
                else if (vm_tempWorker.Address.Length > 5)
                {
                    value = "Address must be 5 characters or less.";
                }
                else
                {
                    value = "";
                }
                vm_tempWorker.Address = value;
            }
        }

        #region Validate City

        public string ValidateCity(string city)
        {
            city ??= "";

            if (!_onlyLetters.IsMatch(city))
            {
                return "Invalid city name";
            }
            else if (city.Length > 50)
            {
                return "City must be 50 characters or less.";
            }
            else
            {
                return "";
            }
        }

        #endregion Validate City

        #region Validate ZipCode

        public string ValidateZipCode(string zipCode)
        {
            zipCode ??= "";

            if (!_onlyDigits.IsMatch(zipCode))

            {
                return "Must be digits";
            }
            else if (zipCode.Length != 4)
            {
                return "Must be 4 digits";
            }
            else
            {
                return "";
            }
        }

        #endregion Validate ZipCode

        #region Validate PersonalNumber

        public string ValidatePersonalNumber(string personalNumber)
        {
            personalNumber ??= "";

            if (!_onlyDigits.IsMatch(personalNumber))

            {
                return "Must be digits";
            }
            else if (personalNumber.Length != 10)
            {
                return "Must be 10 digits";
            }
            else
            {
                return "";
            }
        }

        #endregion Validate PersonalNumber

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}