using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dentist.IServices.Patient;
using Dentist.IServices.Requests;
using Dentist.IData.Patient;

namespace Dentist.Services.Patient
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public Task<Domain.Patient.Patient> GetPatientByPatientId(int patientId)
        {
            return _patientRepository.GetPatient(patientId);
        }

        public Task<Domain.Patient.Patient> GetPatientByPatientPesel(string patientPesel)
        {
            return _patientRepository.GetPatient(patientPesel);
        }

        public async Task<Domain.Patient.Patient> CreatePatient(CreatePatient createPatient)
        {
            var patient = new Domain.Patient.Patient(createPatient.PatientName, createPatient.PatientSurname, createPatient.Gender, createPatient.Pesel, createPatient.BirthDate, createPatient.Phone, createPatient.Email, createPatient.City, createPatient.Street, createPatient.HouseNumber);
            patient.PatientId = await _patientRepository.AddPatient(patient);
            return patient;
        }

        public async Task EditPatient(EditPatient editPatient, int patientId)
        {
            var patient = await _patientRepository.GetPatient(patientId);
            patient.EditPatient(editPatient.PatientName, editPatient.PatientSurname, editPatient.Gender, editPatient.Pesel, editPatient.BirthDate, editPatient.Phone, editPatient.Email, editPatient.City, editPatient.Street, editPatient.HouseNumber);
            await _patientRepository.EditPatient(patient);
        }
    }
}
