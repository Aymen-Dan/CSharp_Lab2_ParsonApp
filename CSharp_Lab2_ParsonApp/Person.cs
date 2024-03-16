using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CSharp_Lab2_ParsonApp
{
    internal class Person
    {

        //Properties
        private string FirstName { get; }
        private string LastName { get; }
        private string Email { get; }
        private DateTime DateOfBirth { get; }

        //Read-only properties
        public bool IsAdult => CalculateIsAdult();
        public String SunSign => CalculateSunSign();
        public String ChineseSign => CalculateChineseSign();
        public bool IsBirthday => CalculateIsBirthday();


        //Constructors
        public Person(string firstName, string lastName, string email, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            DateOfBirth = dateOfBirth.Date;
        }

        public Person(string firstName, string lastName, DateTime dateOfBirth)
            : this(firstName, lastName, "", dateOfBirth)
        {
        }

        public Person(string firstName, string lastName, string email)
            : this(firstName, lastName, email, DateTime.MinValue)
        {
        }


        //Getters
        internal string GetFirstName() => FirstName;
        internal string GetLastName() => LastName;
        internal string GetEmail() => Email;
        internal DateTime GetDateOfBirth() => DateOfBirth;


        //Helper methods
        private bool CalculateIsAdult()
        {
            int age = DateTime.Today.Year - DateOfBirth.Year;
            if (DateTime.Today < DateOfBirth.AddYears(age))
            {
                age--;
            }

            // Check if age is 18 or older
            return age >= 18;
        }

        private string CalculateSunSign()
        {

            return "Sun Sign!";
        }

        private string CalculateChineseSign()
        {
            return "Chinese Sign!";
        }

        private bool CalculateIsBirthday()
        {
            bool Birthday = DateOfBirth.Month == DateTime.Today.Month && DateOfBirth.Day == DateTime.Today.Day;
            if (Birthday)
            {
                MessageBox.Show("Happy birthday! May you have excellent health and a lot of luck!", "Birthday", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            return true;
        }
    }
}

