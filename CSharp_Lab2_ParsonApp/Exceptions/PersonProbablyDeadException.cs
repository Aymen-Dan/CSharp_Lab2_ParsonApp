using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Lab2_ParsonApp
{
    class PersonProbablyDeadException : Exception
    {
        public PersonProbablyDeadException() : base("Invalid date of birth: Unrealistic age")
        {
        }

        public PersonProbablyDeadException(string message) : base(message)
        {
        }

        public PersonProbablyDeadException(string message, Exception innerException) : base(message, innerException)
        {
        }

        //Helper method
        public static void CheckIfFarPastDateOfBirth(DateTime dateOfBirth)
        {
            if (TooOld(dateOfBirth))
            {
                throw new PersonProbablyDeadException();
            }
        }

        //Helper bool to check if a person's date of birth is too far in the past or not
        private static bool TooOld(DateTime dateOfBirth)
        {
            int age = DateTime.Today.Year - dateOfBirth.Year;
            return age > 135;
        }
    }
}

