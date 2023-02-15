using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Domain.DomainExceptions
{
    public class InvalidPhoneException : Exception
    {
        public InvalidPhoneException(string phone) : base(ModifyMessage(phone))
        {
        }

        private static string ModifyMessage(string phone)
        {
            return $"Invalid length of phone number {phone}.";
        }
    }
}
