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
            if (!CanProceed)
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {

                //TO-DO: REMAKE THIS AS SEPARATE ERROR CLASS
                /* int age = DateTime.Today.Year - DateOfBirth.Year;
                 if (DateTime.Today < DateOfBirth.AddYears(age))
                 {
                     age--;
                 }

                 if (age < 0 || age > 135)
                 {
                     MessageBox.Show("Invalid age.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                     return;
                 }*/

                //TO-DO: MAKE SURE ERROR MESSAGE DISAPPEARS IF THE ERROR HAS BEEN CORRECTED
                //TO-DO: maybe MOVE TO SEPARATE METHOD (?)
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
                    //Is email valid? REMEMBER ITS myemail@domain.com
                    InvalidEmailException.CheckEmailIsValid(Email);
                }
                catch (InvalidEmailException ex)
                {
                    ErrorMessage = ex.Message;
                    return;
                }



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


            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"An argument error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Invalid date format: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            /*catch (Exception ex)
            {
                //Catch everything else
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }*/
        }


        //INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
