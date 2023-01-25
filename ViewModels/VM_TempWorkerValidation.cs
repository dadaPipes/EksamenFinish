﻿using System.Text.RegularExpressions;

namespace EksamenFinish.ViewModels
{
    public class VM_TempWorkerValidation
    {
        //The regular expression ^[a-zA-Z]*$ is used to match any string that consists only of letters (uppercase or lowercase).
        private readonly Regex _onlyLetters = new Regex("^[a-zA-Z]*$");

        //Regular expression ^[0-9]*$ to match any string that consists only of digits.
        private readonly Regex _onlyDigits = new Regex("^[0-9]*$");

        #region ValidateFirstName

        public string ValidateFirstName(string firstName)
        {
            firstName = firstName ?? ""; // assigns an empty string as default value if firstName is null or empty
            
            if (firstName == "X Æ A-12")
            {
                return "I see you're trying to be unique, but X Æ A-12 is not your name.";
            }
            else if (!_onlyLetters.IsMatch(firstName))
            {
                return "Invalid first name";
            }
            else if (firstName.Length > 50)
            {
                return "First name must be 50 characters or less.";
            }
            else
            {
                return "";
            }
        }

        #endregion ValidateFirstName

        #region ValidateLastName

        public string ValidateLastName(string lastName)
        {
            lastName = lastName ?? "";

            if (!_onlyLetters.IsMatch(lastName))
            {
                return "Invalid Last name";
            }
            else if (lastName.Length > 50)
            {
                return "Last name must be 50 characters or less.";
            }
            else
            {
                return "";
            }
        }

        #endregion ValidateLastName

        #region ValidateAddress

        public string ValidateAddress(string address)
        {
            address = address ?? "";

            if (!_onlyLetters.IsMatch(address))
            {
                return "Invalid address";
            }
            else if (address.Length > 5)
            {
                return "Address must be 5 characters or less.";
            }
            else
            {
                return "";
            }
        }

        #endregion ValidateAddress

        #region ValidateCity

        public string ValidateCity(string city)
        {
            city = city ?? "";

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

        #endregion ValidateCity

        #region ValidateZipCode

        public string ValidateZipCode(string zipCode)
        {
            zipCode = zipCode ?? "";

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

        #endregion ValidateZipCode

        #region ValidatePersonalNumber

        public string ValidatePersonalNumber(string personalNumber)
        {
            personalNumber = personalNumber ?? "";

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

        #endregion ValidatePersonalNumber
    }
}