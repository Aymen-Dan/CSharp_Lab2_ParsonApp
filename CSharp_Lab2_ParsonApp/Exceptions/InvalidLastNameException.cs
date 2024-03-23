using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSharp_Lab2_ParsonApp.Exceptions
{
    internal class InvalidLastNameException : Exception
    {
        public InvalidLastNameException() : base("Last name contains invalid characters.")
        {
        }

        public InvalidLastNameException(string message) : base(message)
        {
        }

        public InvalidLastNameException(string message, Exception innerException) : base(message, innerException)
        {
        }

        //Helper method to check if a person's name has only letters (maybe also `, ' and -)
        public static void CheckIfLastNameIsValid(string name)
        {
            if (!IsValidLastName(name))
            {
                throw new InvalidLastNameException();
            }
        }

        //Helper bool to check if an email is in a valid format
        private static bool IsValidLastName(string name)
        {
            //Regular expression pattern to allow letters and ' - 
            string pattern = "^[a-zA-Z-' ]+$";

            //Check if name matches pattern
            return Regex.IsMatch(name, pattern);
        }
    }
}
