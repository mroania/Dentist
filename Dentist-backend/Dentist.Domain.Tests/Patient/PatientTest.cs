using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dentist.Common.Enums;
using Dentist.Domain.DomainExceptions;
using Xunit;

namespace Dentist.Domain.Tests.Patient
{
    public class PatientTest
    {
        public PatientTest()
        {
            //Arrange
            //Act
            //Assert
        }

        [Fact]
        public void CreatePatient_Returns_throws_InvalidBirthDateException()
        {
            Assert.Throws<InvalidBirthDateException>
            (() => new Domain.Patient.Patient("Name", "Surname", Gender.Male, "11111111111", DateTime.UtcNow.AddHours(1), "111111111", "Email", "City", "Street", "11"));
        }

        [Fact]
        public void CreatePatient_Returns_throws_InvalidPhoneException()
        {
            Assert.Throws<InvalidPhoneException>
            (() => new Domain.Patient.Patient("Name", "Surname", Gender.Male, "11111111111", DateTime.UtcNow, "1", "Email", "City", "Street", "11"));
        }

        //Sprawdzanie poprawności działania przy poprawnych danych
        [Fact]
        public void CreatePatient_Returns_Correct_Response()
        {
            var patient = new Domain.Patient.Patient("Name", "Surname", Gender.Male, "11111111111", DateTime.UtcNow, "111111111", "Email", "City", "Street", "11");

            Assert.Equal("Name", patient.PatientName);
            Assert.Equal("Surname", patient.PatientSurname);
            Assert.Equal(Gender.Male, patient.Gender);
            Assert.Equal("11111111111", patient.Pesel);
            Assert.Equal("Email", patient.Email);
            Assert.Equal("City", patient.City);
            Assert.Equal("Street", patient.Street);
            Assert.Equal("11", patient.HouseNumber);
        }

    }
}
