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

    public class AppointmentTreatmentController : Controller
    {
        private readonly DentistDbContext _context;

        public AppointmentTreatmentController(DentistDbContext context)
        {
            _context = context;
        }

        [HttpGet("{appointmentTreatmentId:min(1)}", Name = "GetAppointmentTreatmentById")]
        public async Task<IActionResult> GetAppointmentTreatmentById(int appointmentTreatmentId)
        {
            var appointmentTreatment = await _context.AppointmentTreatment.FirstOrDefaultAsync(x => x.AppointmentTreatmentId == appointmentTreatmentId);

            if (appointmentTreatment != null)
            {
                return Ok(new AppointmentTreatmentViewModel
                {
                    AppointmentTreatmentId = appointmentTreatment.AppointmentTreatmentId,
                    AppointmentId = appointmentTreatment.AppointmentId,
                    TreatmentId = appointmentTreatment.TreatmentId                    
                });
            }

            return NotFound();
        }

        [HttpGet("all", Name = "GetAllAppointmentTreatment")]
        public async Task<IActionResult> GetAllAppointmentTreatment()
        {
            var appointmentTreatment =  _context.AppointmentTreatment.Where(x => x.AppointmentTreatmentId != 0);
            return Ok(appointmentTreatment);
        }

        [ValidateModel]
        [HttpDelete("remove/{appointmentTreatmentId:min(1)}", Name ="RemoveAppointmentTreatment")]
        public async Task<IActionResult> RemoveAppointmentTreatment(int appointmentTreatmentId)
        {
            var appointmentTreatment = await _context.AppointmentTreatment.FirstOrDefaultAsync(x => x.AppointmentTreatmentId == appointmentTreatmentId);

            _context.AppointmentTreatment.Remove(appointmentTreatment);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
