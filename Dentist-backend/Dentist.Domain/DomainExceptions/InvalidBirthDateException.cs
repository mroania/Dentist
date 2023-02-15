using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Domain.DomainExceptions
{
    public class InvalidBirthDateException : Exception
    {
        public InvalidBirthDateException(DateTime birthDate) : base(ModifyMessage(birthDate))
        {
        }

        private static string ModifyMessage(DateTime birthDate)
        {
            return $"Invalid birth date {birthDate}.";
        }
    }
}
