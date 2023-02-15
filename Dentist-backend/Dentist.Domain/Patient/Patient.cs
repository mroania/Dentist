using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dentist.Common.Enums;
using Dentist.Domain.DomainExceptions;

namespace Dentist.Domain.Patient
{
    public class Patient
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

        public Patient(int id, string patientName, string patientSurname, Gender gender, string pesel, DateTime birthDate, string phone, string email, string city, string street, string houseNumber)
        {
            PatientId = id;
            PatientName = patientName;
            PatientSurname = patientSurname;
            Gender = gender;
            Pesel = pesel;
            BirthDate = birthDate;
            Phone = phone;
            Email = email;
            City = city;
            Street = street;
            HouseNumber = houseNumber;
        }

        public Patient(string patientName, string patientSurname, Gender gender, string pesel, DateTime birthDate, string phone, string email, string city, string street, string houseNumber)
        {
            if (birthDate >= DateTime.UtcNow)
                throw new InvalidBirthDateException(birthDate);
            if (phone.Length < 9 || phone.Length > 9)
                throw new InvalidPhoneException(phone);
            PatientName = patientName;
            PatientSurname = patientSurname;
            Gender = gender;
            Pesel = pesel;
            BirthDate = birthDate;
            Phone = phone;
            Email = email;
            City = city;
            Street = street;
            HouseNumber = houseNumber;
        }

        public void EditPatient(string patientName, string patientSurname, Gender gender, string pesel, DateTime birthDate, string phone, string email, string city, string street, string houseNumber)
        {
            if (birthDate >= DateTime.UtcNow)
                throw new InvalidBirthDateException(birthDate);
            if (phone.Length < 9 || phone.Length > 9)
                throw new InvalidPhoneException(phone);
            PatientName = patientName;
            PatientSurname = patientSurname;
            Gender = gender;
            Pesel = pesel;
            BirthDate = birthDate;
            Phone = phone;
            Email = email;
            City = city;
            Street = street;
            HouseNumber = houseNumber;
        }
    }
}
