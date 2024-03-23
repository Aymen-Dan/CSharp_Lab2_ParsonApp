using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSharp_Lab2_ParsonApp.Exceptions
{
    internal class InvalidFirstNameException : Exception
    {
        public InvalidFirstNameException() : base("First name contains invalid characters.")
        {
        }

        public InvalidFirstNameException(string message) : base(message)
        {
        }

        public InvalidFirstNameException(string message, Exception innerException) : base(message, innerException)
        {
        }

        //Helper method to check if a person's name has only letters (maybe also `, ' and -)
        public static void CheckIfFirstNameIsValid(string name)
        {
            if (!IsValidFirstName(name))
            {
                throw new InvalidFirstNameException();
            }
        }

        //Helper bool to check if an email is in a valid format
        private static bool IsValidFirstName(string name)
        {
            //Regular expression pattern to allow letters and ' - 
            string pattern = "^[a-zA-Z-' ]+$";

            //Check if name matches pattern
            return Regex.IsMatch(name, pattern);
        }
    }
}
