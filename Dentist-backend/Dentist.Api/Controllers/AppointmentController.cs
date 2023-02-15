using System;
using System.Threading.Tasks;
using Dentist.Api.BindingModels;
using Dentist.Api.Validation;
using Dentist.Api.ViewModels;
using Dentist.Api.Mappers;
using Dentist.IServices.Appointment;
using Dentist.Data.Sql;
using Dentist.Data.Sql.DAO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dentist.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]

    public class AppointmentController : Controller
    {
        private readonly DentistDbContext _context;

        public AppointmentController(DentistDbContext context)
        {
            _context = context;
        }

        [HttpGet("{appointmentId:min(1)}", Name = "GetAppointmentById")]
        public async Task<IActionResult> GetAppointmentById(int appointmentId)
        {
            var appointment = await _context.Appointment.FirstOrDefaultAsync(x=>x.AppointmentId==appointmentId);

            if (appointment != null)
            {
                return Ok(new AppointmentViewModel
                {
                    AppointmentId = appointment.AppointmentId,
                    PatientId = appointment.PatientId,
                    DoctorId = appointment.DoctorId,
                    AssistantId = appointment.AssistantId,
                    ApDate = appointment.ApDate,
                    ApTime = appointment.ApTime
                });
            }

            return NotFound();
        }

        [ValidateModel]
        public async Task<IActionResult> Post([FromBody] CreateAppointment createAppointment)
        {
            var appointment = new Appointment
            {
                PatientId = createAppointment.PatientId,
                DoctorId = createAppointment.DoctorId,
                AssistantId = createAppointment.AssistantId,
                ApDate = createAppointment.ApDate,
                ApTime = createAppointment.ApTime
            };

            await _context.AddAsync(appointment);
            await _context.SaveChangesAsync();

            return Created(appointment.AppointmentId.ToString(), new AppointmentViewModel
            {
                AppointmentId = appointment.AppointmentId,
                PatientId = appointment.PatientId,
                DoctorId = appointment.DoctorId,
                AssistantId = appointment.AssistantId,
                ApDate = appointment.ApDate,
                ApTime = appointment.ApTime
            });
        }

        [ValidateModel]
        [HttpPatch("edit/{appointmentId:min(1)}", Name = "EditAppointment")]
        public async Task<IActionResult> EditAppointment([FromBody] EditAppointment editAppointment, int appointmentId)
        {
            var appointment = await _context.Appointment.FirstOrDefaultAsync(x => x.AppointmentId == appointmentId);
            appointment.PatientId = editAppointment.PatientId;
            appointment.DoctorId = editAppointment.DoctorId;
            appointment.AssistantId = editAppointment.AssistantId;
            appointment.ApDate = editAppointment.ApDate;
            appointment.ApTime = editAppointment.ApTime;

            await _context.SaveChangesAsync();
            return NoContent();

            return Ok(new AppointmentViewModel
            {
                AppointmentId = appointment.AppointmentId,
                PatientId = appointment.PatientId,
                DoctorId = appointment.DoctorId,
                AssistantId = appointment.AssistantId,
                ApDate = appointment.ApDate,
                ApTime = appointment.ApTime
            });
        }

        [ValidateModel]
        [HttpDelete("remove/{appointmentId:min(1)}", Name = "RemoveAppointment")]
        public async Task<IActionResult> RemoveAppointment(int appointmentId)
        {
            var outWhile = true;
            do
            {
                var removeAppointmentTreatment = await _context.AppointmentTreatment.FirstOrDefaultAsync(x => x.AppointmentId == appointmentId);
                if (removeAppointmentTreatment != null)
                {
                    _context.AppointmentTreatment.Remove(removeAppointmentTreatment);
                }
                else
                {
                    outWhile = false;
                }
                await _context.SaveChangesAsync();
            } while (outWhile);

            var removeappointment = await _context.Appointment.FirstOrDefaultAsync(x => x.AppointmentId == appointmentId);
            if (removeappointment != null)
            {
                _context.Appointment.Remove(removeappointment);
            }

            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
