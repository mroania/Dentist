using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dentist.IServices.Requests;

namespace Dentist.IServices.Patient
{
    public interface IPatientService
    {
        Task<Dentist.Domain.Patient.Patient> GetPatientByPatientId(int patientId);
        Task<Dentist.Domain.Patient.Patient> GetPatientByPatientPesel(string patientPesel);
        Task<Dentist.Domain.Patient.Patient> CreatePatient(CreatePatient createPatient);
        Task EditPatient(EditPatient createPatient, int patientId);
    }
}
