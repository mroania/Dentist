using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.IData.Patient
{
    public interface IPatientRepository
    {
        Task<int> AddPatient(Dentist.Domain.Patient.Patient patient);
        Task<Dentist.Domain.Patient.Patient> GetPatient(int patientId);
        Task<Dentist.Domain.Patient.Patient> GetPatient(string patientPesel);
        Task EditPatient(Domain.Patient.Patient patient);
    }
}
