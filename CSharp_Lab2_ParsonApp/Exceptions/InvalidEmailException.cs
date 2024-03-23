using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Lab2_ParsonApp
{
    class InvalidEmailException : Exception
    {
        public InvalidEmailException() : base("Invalid email: Incorrect format.")
        {
        }

        public InvalidEmailException(string message) : base(message)
        {
        }

        public InvalidEmailException(string message, Exception innerException) : base(message, innerException)
        {
        }

        //Helper method
        public static void CheckIfEmailIsValid(string email)
        {
            if (!IsValidEmail(email))
            {
                throw new InvalidEmailException();
            }
        }

        //Helper bool to check if an email is in a valid format
        private static bool IsValidEmail(string email)
        {
            return email.Contains("@") && email.Contains(".");
        }

    }
}
