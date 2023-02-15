using Dentist.Api.ViewModels;

namespace Dentist.Api.Mappers
{
    public class PatientToPatientViewModelMapper
    {
        public static PatientViewModel PatientToPatientViewModel(Domain.Patient.Patient patient)
        {
            var patientViewModel = new PatientViewModel
            {
                PatientId = patient.PatientId,
                PatientName = patient.PatientName,
                PatientSurname = patient.PatientSurname,
                Gender = patient.Gender,
                Pesel = patient.Pesel,
                BirthDate = patient.BirthDate,
                Phone = patient.Phone,
                Email = patient.Email,
                City = patient.City,
                Street = patient.Street,
                HouseNumber = patient.HouseNumber
            };
            return patientViewModel;
        }

    }
}