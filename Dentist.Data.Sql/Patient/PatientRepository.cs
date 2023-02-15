using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dentist.IData.Patient;
using Microsoft.EntityFrameworkCore;

namespace Dentist.Data.Sql.Patient
{
    public class PatientRepository : IPatientRepository
    {
        private readonly DentistDbContext _context;

        public PatientRepository(DentistDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddPatient(Domain.Patient.Patient patient)
        {
            var patientDAO = new DAO.Patient
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

            await _context.AddAsync(patientDAO);
            await _context.SaveChangesAsync();
            return patientDAO.PatientId;
        }

        public async Task<Domain.Patient.Patient> GetPatient(int patientId)
        {
            var patient = await _context.Patient.FirstOrDefaultAsync(x=>x.PatientId == patientId);
            return new Domain.Patient.Patient(patient.PatientId,
                patient.PatientName,
                patient.PatientSurname,
                patient.Gender,
                patient.Pesel,
                patient.BirthDate,
                patient.Phone,
                patient.Email,
                patient.City,
                patient.Street,
                patient.HouseNumber);
        }

        public async Task<Domain.Patient.Patient> GetPatient(string patientPesel)
        {
            var patient = await _context.Patient.FirstOrDefaultAsync(x => x.Pesel == patientPesel);
            return new Domain.Patient.Patient(patient.PatientId,
                patient.PatientName,
                patient.PatientSurname,
                patient.Gender,
                patient.Pesel,
                patient.BirthDate,
                patient.Phone,
                patient.Email,
                patient.City,
                patient.Street,
                patient.HouseNumber);
        }

        public async Task EditPatient(Domain.Patient.Patient patient)
        {
            var editPatient = await _context.Patient.FirstOrDefaultAsync(x => x.PatientId == patient.PatientId);
            editPatient.PatientName = patient.PatientName;
            editPatient.PatientSurname = patient.PatientSurname;
            editPatient.Gender = patient.Gender;
            editPatient.Pesel = patient.Pesel;
            editPatient.BirthDate = patient.BirthDate;
            editPatient.Phone = patient.Phone;
            editPatient.Email = patient.Email;
            editPatient.City = patient.City;
            editPatient.Street = patient.Street;
            editPatient.HouseNumber = patient.HouseNumber;

            await _context.SaveChangesAsync();
        }
    }
}
