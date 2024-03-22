using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Lab2_ParsonApp
{
    class InvalidEmailException : Exception
    {
        //TO-DO: DON'T FORGET TO CHANGE
        public InvalidEmailException() : base("Invalid email: NOT myemail@domain.com")
        {
        }

        public InvalidEmailException(string message) : base(message)
        {
        }

        public InvalidEmailException(string message, Exception innerException) : base(message, innerException)
        {
        }

        //Helper method to check if a person's date of birth is in the future

        //TO-DO: REDO THE CHECK
        public static void CheckEmailIsValid(string email)
        {
            if (email != "myemail@domain.com")
            {
                throw new InvalidEmailException();
            }
        }
    }
}
