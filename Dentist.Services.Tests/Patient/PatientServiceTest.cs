using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dentist.Common.Enums;
using Dentist.Domain.DomainExceptions;
using Dentist.IData.Patient;
using Dentist.IServices.Requests;
using Dentist.IServices.Patient;
using Dentist.Services.Patient;
using Xunit;
using Moq;


namespace Dentist.Services.Tests.Patient
{
    public class PatientServiceTest
    {
        private readonly IPatientService _patientService;
        private readonly Mock<IPatientRepository> _patientRepositoryMock;

        public PatientServiceTest()
        {
            //Arrange
            _patientRepositoryMock = new Mock<IPatientRepository>();
            _patientService = new PatientService(_patientRepositoryMock.Object);
        }

        [Fact]
        public void CreatePatient_Returns_throws_InvalidBirthDateException()
        {
            var patient = new CreatePatient
            {
                PatientName = "Name",
                PatientSurname = "Surname",
                Gender = Gender.Male,
                Pesel = "11111111111",
                BirthDate = DateTime.UtcNow.AddHours(1),
                Phone = "111111111",
                Email = "Email",
                City = "City",
                Street = "Street",
                HouseNumber = "11"
            };
            Assert.ThrowsAsync<InvalidBirthDateException>(() => _patientService.CreatePatient(patient));
        }

        [Fact]
        public void CreatePatient_Returns_throws_InvalidPhoneException()
        {
            var patient = new CreatePatient
            {
                PatientName = "Name",
                PatientSurname = "Surname",
                Gender = Gender.Male,
                Pesel = "11111111111",
                BirthDate = DateTime.UtcNow,
                Phone = "1111111111111111111",
                Email = "Email",
                City = "City",
                Street = "Street",
                HouseNumber = "11"
            };
            Assert.ThrowsAsync<InvalidPhoneException>(() => _patientService.CreatePatient(patient));
        }

        [Fact]
        public async Task CreatePatient_Returns_Correct_Response()
        {
            var patient = new CreatePatient
            {
                PatientName = "Name",
                PatientSurname = "Surname",
                Gender = Gender.Male,
                Pesel = "11111111111",
                BirthDate = DateTime.UtcNow,
                Phone = "111111111",
                Email = "Email",
                City = "City",
                Street = "Street",
                HouseNumber = "11"
            };

            int expectedResult = 0;
            _patientRepositoryMock.Setup(x=>x.AddPatient
                (new Domain.Patient.Patient(
                    patient.PatientName,
                    patient.PatientSurname,
                    patient.Gender,
                    patient.Pesel,
                    patient.BirthDate,
                    patient.Phone,
                    patient.Email,
                    patient.City,
                    patient.Street,
                    patient.HouseNumber))).Returns(Task.FromResult(expectedResult));

            //Act
            var result = await _patientService.CreatePatient(patient);

            //Assert
            Assert.IsType<Domain.Patient.Patient>(result);
            Assert.NotNull(result);
            Assert.Equal(expectedResult, result.PatientId);
        }
    }
}
