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
        public PersonNotBornYetException() : base("Invalid date of birth: From the future.")
        {
        }

        public PersonNotBornYetException(string message) : base(message)
        {
        }

        public PersonNotBornYetException(string message, Exception innerException) : base(message, innerException)
        {
        }

        //Helper method
        public static void CheckIfFutureDateOfBirth(DateTime dateOfBirth)
        {
            if (IsFromFuture(dateOfBirth))
            {
                throw new PersonNotBornYetException();
            }
        }

        //helper bool to check if date of birth is from future or not
        private static bool IsFromFuture(DateTime dateOfBirth)
        {
            return dateOfBirth > DateTime.Today;
        }


    }
}
