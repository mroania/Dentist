using System;
using Dentist.Common.Enums;

namespace Dentist.Api.ViewModels
{
    public class PatientViewModel
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string PatientSurname { get; set; }
        public Gender Gender { get; set; }
        public string Pesel { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
    }
}
