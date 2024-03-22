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
        internal string GetDateOfBirth() => DateOfBirth.ToString("dd/MM/yyyy");


        //Helper methods
        private bool CalculateIsAdult()
        {
            int age = DateTime.Today.Year - DateOfBirth.Year;
            if (DateTime.Today < DateOfBirth.AddYears(age))
            {
                age--;
            }

            //check if age is 18 or older
            return age >= 18;
        }

        private string CalculateSunSign()
        {
            int month = DateOfBirth.Month;
            int day = DateOfBirth.Day;

            if ((month == 3 && day >= 21) || (month == 4 && day <= 19))
            {
                return "Aries";
            }
            else if ((month == 4 && day >= 20) || (month == 5 && day <= 20))
            {
                return "Taurus";
            }
            else if ((month == 5 && day >= 21) || (month == 6 && day <= 20))
            {
                return "Gemini";
            }
            else if ((month == 6 && day >= 21) || (month == 7 && day <= 22))
            {
                return "Cancer";
            }
            else if ((month == 7 && day >= 23) || (month == 8 && day <= 22))
            {
                return "Leo";
            }
            else if ((month == 8 && day >= 23) || (month == 9 && day <= 22))
            {
                return "Virgo";
            }
            else if ((month == 9 && day >= 23) || (month == 10 && day <= 22))
            {
                return "Libra";
            }
            else if ((month == 10 && day >= 23) || (month == 11 && day <= 21))
            {
                return "Scorpio";
            }
            else if ((month == 11 && day >= 22) || (month == 12 && day <= 21))
            {
                return "Sagittarius";
            }
            else if ((month == 12 && day >= 22) || (month == 1 && day <= 19))
            {
                return "Capricorn";
            }
            else if ((month == 1 && day >= 20) || (month == 2 && day <= 18))
            {
                return "Aquarius";
            }
            else //February 19 to March 20
            {
                return "Pisces";
            }
        }

        private string CalculateChineseSign()
        {
            //Start from 1900 y
            int startYear = 1900;

            //calculate the offset from the start year
            int offset = DateOfBirth.Year - startYear;

            //animal signs of the Chinese zodiac cycle
            string[] animalSigns = { "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat", "Monkey", "Rooster", "Dog", "Pig" };

            //Calculate index
            int index = (offset + 12) % 12;

            //Return the animal sign
            return animalSigns[index];
        }

        private bool CalculateIsBirthday()
        {
            bool Birthday = DateOfBirth.Month == DateTime.Today.Month && DateOfBirth.Day == DateTime.Today.Day;
            if (Birthday)
            {
                MessageBox.Show("Happy birthday! May you have excellent health and a lot of luck!", "Birthday", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            return Birthday;
        }
    }
}

