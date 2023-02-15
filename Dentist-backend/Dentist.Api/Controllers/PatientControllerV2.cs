using System;
using System.Threading.Tasks;
using Dentist.Api.BindingModels;
using Dentist.Api.Validation;
using Dentist.Api.ViewModels;
using Dentist.Data.Sql;
using Dentist.Api.Mappers;
using Dentist.IServices.Patient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dentist.Api.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/patient")]

    public class PatientControllerV2 : Controller
    {
        private readonly DentistDbContext _context;
        private readonly IPatientService _patientService;

        public PatientControllerV2(DentistDbContext context, IPatientService patientService)
        {
            _context = context;
            _patientService = patientService;
        }

        [HttpGet("{patientId:min(1)}", Name = "GetPatientById")]
        public async Task<IActionResult> GetPatientById(int patientId)
        {
            var patient = await _patientService.GetPatientByPatientId(patientId);

            if (patient != null)
            {
                return Ok(PatientToPatientViewModelMapper.PatientToPatientViewModel(patient));
            }
            return NotFound();
        }

        [HttpGet("pesel/{patientPesel}", Name = "GetPatientByPesel")]
        public async Task<IActionResult> GetPatientByPesel(string patientPesel)
        {
            var patient = await _patientService.GetPatientByPatientPesel(patientPesel);

            if (patient.Pesel != null)
            {
                return Ok(PatientToPatientViewModelMapper.PatientToPatientViewModel(patient));
            }
            return NotFound();
        }

        [ValidateModel]
        public async Task<IActionResult> Post([FromBody] IServices.Requests.CreatePatient createPatient)
        {
            var patient = await _patientService.CreatePatient(createPatient);
            return Created(patient.PatientId.ToString(), PatientToPatientViewModelMapper.PatientToPatientViewModel(patient));
        }

        [ValidateModel]
        [HttpPatch("edit/{patientId:min(1)}", Name = "EditPatient")]
        public async Task<IActionResult> EditPatient([FromBody] IServices.Requests.EditPatient editPatient, int patientId)
        {
            await _patientService.EditPatient(editPatient, patientId);
            return NoContent();
        }
    }
}
