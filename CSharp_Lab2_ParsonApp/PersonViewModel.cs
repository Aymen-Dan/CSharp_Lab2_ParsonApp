using CSharp_Lab2_ParsonApp.Exceptions;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CSharp_Lab2_ParsonApp
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        //Properties
        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged(nameof(FirstName));
                    OnPropertyChanged(nameof(CanProceed));
                }
            }
        }

        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    OnPropertyChanged(nameof(LastName));
                    OnPropertyChanged(nameof(CanProceed));
                }
            }
        }

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged(nameof(Email));
                    OnPropertyChanged(nameof(CanProceed));
                }
            }
        }


        private DateTime _dateOfBirth;
        public DateTime DateOfBirth
        {
            get => _dateOfBirth;
            set
            {
                if (_dateOfBirth != value)
                {
                    _dateOfBirth = value;
                    OnPropertyChanged(nameof(DateOfBirth));
                    OnPropertyChanged(nameof(CanProceed));
                }
            }
        }

        //error property
        private string _errorMessage;
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                if (_errorMessage != value)
                {
                    _errorMessage = value;
                    OnPropertyChanged(nameof(ErrorMessage));
                }
            }
        }

        //Commands
        public ICommand ProceedCommand { get; }

        //helper bool
        public bool InputValid;


        ///constructor
        public PersonViewModel()
        {
            //Validate();
            ProceedCommand = new RelayCommand(async () => await ProceedAsync(), () => CanProceed);
        }

        //methods
        private bool CanProceed =>
            !string.IsNullOrEmpty(FirstName)
            && !string.IsNullOrEmpty(LastName)
            && !string.IsNullOrEmpty(Email)
            && DateOfBirth != default;




        private async Task ProceedAsync()
        {
            /*if (!CanProceed)
            {
                ErrorMessage = "Please fill in all fields.";
                return;
            }*/


            ValidateInputs(); //Validate inputs

            if (!InputValid)
            {
                //ErrorMessage = "NO. BAD.";
                return;
            }


            try
            {

                var person = new Person(FirstName, LastName, Email, DateOfBirth);
                await Task.Run(() =>
                {
                    //asynchronous calculations
                    bool isAdult = person.IsAdult;
                    string sunSign = person.SunSign;
                    string chineseSign = person.ChineseSign;
                    bool isBirthday = person.IsBirthday;



                    //Print out values
                    MessageBox.Show($"First name: {person.GetFirstName()}\n" +
                                $"Last name: {person.GetLastName()}\n" +
                                $"E-mail: {person.GetEmail()}\n" +
                                $"Date of birth: {person.GetDateOfBirth()}\n" +
                                $"You are an adult: {isAdult}\n" +
                                $"Sun sign: {sunSign}\n" +
                                $"Chinese sign: {chineseSign}\n" +
                                $"Today is your birthday: {isBirthday}", "Result", MessageBoxButton.OK, MessageBoxImage.Information);
                });


            }//TO-DO: MOVE TO VALIDATEINPUT() IF POSSIBLE
            catch (ArgumentException ex)
            {
                MessageBox.Show($"An argument error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Invalid date format: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                //Catch everything else
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void ValidateInputs()
        {
            try
            {
                //Is DoB in the future?
                PersonNotBornYetException.CheckIfFutureDateOfBirth(DateOfBirth);
            }
            catch (PersonNotBornYetException ex)
            {
                ErrorMessage = ex.Message;
                return;
            }

            try
            {
                //Is DoB far away in the past?
                PersonProbablyDeadException.CheckIfFarPastDateOfBirth(DateOfBirth);
            }
            catch (PersonProbablyDeadException ex)
            {
                ErrorMessage = ex.Message;
                return;
            }

            try
            {
                //Is email valid? @ . MUST HAVE
                InvalidEmailException.CheckIfEmailIsValid(Email);
            }
            catch (InvalidEmailException ex)
            {
                ErrorMessage = ex.Message;
                return;
            }

            try
            {
                //Is first name valid? 
                InvalidFirstNameException.CheckIfFirstNameIsValid(FirstName);
            }
            catch (InvalidFirstNameException ex)
            {
                ErrorMessage = ex.Message;
                return;
            }

            try
            {
                //Is last name valid? 
                InvalidLastNameException.CheckIfLastNameIsValid(LastName);
            }
            catch (InvalidLastNameException ex)
            {
                ErrorMessage = ex.Message;
                return;
            }

            // Clear error message if no errors
            ErrorMessage = null;
            InputValid = true;
        }


        //INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
