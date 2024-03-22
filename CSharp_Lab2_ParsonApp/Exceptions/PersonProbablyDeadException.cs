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

        //Helper method to check if a person's date of birth is in the future

        //TO-DO: REDO THE CHECK
        public static void CheckIfFarPastDateOfBirth(DateTime dateOfBirth)
        {
            int age = DateTime.Today.Year - dateOfBirth.Year;
            if (age > 135)
            {
                throw new PersonProbablyDeadException();
            }
        }
    }
}

