using System;
using System.Threading.Tasks;
using Dentist.Api.BindingModels;
using Dentist.Api.Validation;
using Dentist.Api.ViewModels;
using Dentist.Data.Sql;
using Dentist.Data.Sql.DAO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dentist.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]

    public class PatientController : Controller
    {
        private readonly DentistDbContext _context;

        public PatientController(DentistDbContext context)
        {
            _context = context;
        }

        [HttpGet("{patientId:min(1)}", Name = "GetPatientById")]
        public async Task<IActionResult> GetPatientById(int patientId)
        {
            var patient = await _context.Patient.FirstOrDefaultAsync(x => x.PatientId == patientId);

            if (patient != null)
            {
                return Ok(new PatientViewModel
                {
                    PatientId = patient.PatientId,
                    PatientName = patient.PatientName,
                    PatientSurname = patient.PatientSurname,
                    Gender = patient.Gender,
                    Pesel = patient.Pesel,
                    BirthDate = DateTime.Now,
                    Phone = patient.Phone,
                    Email = patient.Email,
                    City = patient.City,
                    Street = patient.Street,
                    HouseNumber = patient.HouseNumber
                });
            }

            return NotFound();
        }

        [HttpGet("pesel/{patientPesel}", Name = "GetPatientByPatientPesel")]
        public async Task<IActionResult> GetPatientByPatientPesel(string patientPesel)
        {
            var patient = await _context.Patient.FirstOrDefaultAsync(x => x.Pesel == patientPesel);

            if (patient != null)
            {
                return Ok(new PatientViewModel
                {
                    PatientId = patient.PatientId,
                    PatientName = patient.PatientName,
                    PatientSurname = patient.PatientSurname,
                    Gender = patient.Gender,
                    Pesel = patient.Pesel,
                    BirthDate = DateTime.Now,
                    Phone = patient.Phone,
                    Email = patient.Email,
                    City = patient.City,
                    Street = patient.Street,
                    HouseNumber = patient.HouseNumber
                });
            }

            return NotFound();
        }

        [ValidateModel]
        //        [Consumes("application/x-www-form-urlencoded")]
        //        [HttpPost("create", Name = "CreatePatient")]
        public async Task<IActionResult> Post([FromBody] CreatePatient createPatient)
        {
            var patient = new Patient
            {
                PatientName = createPatient.PatientName,
                PatientSurname = createPatient.PatientSurname,
                Gender = createPatient.Gender,
                Pesel = createPatient.Pesel,
                BirthDate = createPatient.BirthDate,
                Phone = createPatient.Phone,
                Email = createPatient.Email,
                City = createPatient.City,
                Street = createPatient.Street,
                HouseNumber = createPatient.HouseNumber
            };
            await _context.AddAsync(patient);
            await _context.SaveChangesAsync();

            return Created(patient.PatientId.ToString(), new PatientViewModel
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
            });
        }

        [ValidateModel]
        [HttpPatch("edit/{patientId:min(1)}", Name = "EditPatient")]
        public async Task<IActionResult> EditPatient([FromBody] EditPatient editPatient, int patientId)
        {
            var patient = await _context.Patient.FirstOrDefaultAsync(x => x.PatientId == patientId);
            patient.PatientName = editPatient.PatientName;
            patient.PatientSurname = editPatient.PatientSurname;
            patient.Gender = editPatient.Gender;
            patient.Pesel = editPatient.Pesel;
            patient.BirthDate = editPatient.BirthDate;
            patient.Phone = editPatient.Phone;
            patient.Email = editPatient.Email;
            patient.City = editPatient.City;
            patient.Street = editPatient.Street;
            patient.HouseNumber = editPatient.HouseNumber;

            await _context.SaveChangesAsync();
            return NoContent();

            return Ok(new PatientViewModel
            {
                PatientId = patient.PatientId,
                PatientName = patient.PatientName,
                PatientSurname = editPatient.PatientSurname,
                Gender = editPatient.Gender,
                Pesel = editPatient.Pesel,
                BirthDate = editPatient.BirthDate,
                Phone = editPatient.Phone,
                Email = editPatient.Email,
                City = editPatient.City,
                Street = editPatient.Street,
                HouseNumber = editPatient.HouseNumber
            });
        }
    }
}