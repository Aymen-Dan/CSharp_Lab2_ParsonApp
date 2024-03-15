using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CSharp_Lab2_ParsonApp
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        // Properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }

        //Commands
        public ICommand ProceedCommand { get; }

        ///Constructor
        public PersonViewModel()
        {
            ProceedCommand = new RelayCommand(async () => await ProceedAsync(), CanProceed);
        }

        //methods
        private bool CanProceed()
        {
            return !string.IsNullOrEmpty(FirstName)
                && !string.IsNullOrEmpty(LastName)
                && !string.IsNullOrEmpty(Email)
                && DateOfBirth != default;
        }

        private async Task ProceedAsync()
        {
            if (!CanProceed())
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int age = DateTime.Today.Year - DateOfBirth.Year;
            if (DateTime.Today < DateOfBirth.AddYears(age))
            {
                age--;
            }

            if (age < 0 || age > 135)
            {
                MessageBox.Show("Invalid age.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            bool isBirthday = DateOfBirth.Month == DateTime.Today.Month && DateOfBirth.Day == DateTime.Today.Day;
            if (isBirthday)
            {
                MessageBox.Show("Happy birthday!", "Birthday", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            var person = new Person(FirstName, LastName, Email, DateOfBirth);
            await Task.Run(() =>
            {
                //asynchronous calculations
                bool isAdult = person.IsAdult;
                string sunSign = person.SunSign;
                string chineseSign = person.ChineseSign;

                //Print out values
                MessageBox.Show($"FirstName: {person.GetFirstName()}\n" +
                                $"LastName: {person.GetLastName()}\n" +
                                $"Email: {person.GetEmail()}\n" +
                                $"DateOfBirth: {person.GetDateOfBirth()}\n" +
                                $"IsAdult: {isAdult}\n" +
                                $"SunSign: {sunSign}\n" +
                                $"ChineseSign: {chineseSign}\n" +
                                $"IsBirthday: {isBirthday}", "Result", MessageBoxButton.OK, MessageBoxImage.Information);
            });
        }

        //INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
