using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Lab2_ParsonApp
{
    //Future date of birth exception
    class PersonNotBornYetException : Exception
    {
        //default message constructor

        //TO-DO: COME UP WITH BETTER ERROR TEXT
        public PersonNotBornYetException() : base("Invalid date of birth: From the future.")
        {
        }

        public PersonNotBornYetException(string message) : base(message)
        {
        }

        public PersonNotBornYetException(string message, Exception innerException) : base(message, innerException)
        {
        }

        //Helper method to check if a person's date of birth is in the future
        public static void CheckIfFutureDateOfBirth(DateTime dateOfBirth)
        {
            if (dateOfBirth > DateTime.Today)
            {
                throw new PersonNotBornYetException();
            }
        }

    }
}
