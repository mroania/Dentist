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
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/appointment")]

    public class AppointmentControllerV2 : Controller
    {
        private readonly DentistDbContext _context;
        private readonly IAppointmentService _appointmentService;

        public AppointmentControllerV2(DentistDbContext context, IAppointmentService appointmentService)
        {
            _context = context;
            _appointmentService = appointmentService;
        }

        [HttpGet("{appointmentId:min(1)}", Name = "GetAppointmentById")]
        public async Task<IActionResult> GetAppointmentById(int appointmentId)
        {
            var appointment = await _appointmentService.GetAppointmentByAppointmentId(appointmentId);

            if (appointment != null)
            {
                return Ok(AppointmentToAppointmentViewModelMapper.AppointmentToAppointmentViewModel(appointment));
            }

            return NotFound();
        }

        [HttpGet("all", Name = "GetAllAppointment")]
        public async Task<IActionResult> GetAllAppointment()
        {
            var appointment = _context.Appointment.Where(x => x.AppointmentId != 0);
            return Ok(appointment);
        }

        [ValidateModel]
        public async Task<IActionResult> Post([FromBody] IServices.Requests.CreateAppointment createAppointment)
        {
            var appointment = await _appointmentService.CreateAppointment(createAppointment);
            return Created(appointment.AppointmentId.ToString(), AppointmentToAppointmentViewModelMapper.AppointmentToAppointmentViewModel(appointment));
        }

        [ValidateModel]
        [HttpPatch("edit/{appointmentId:min(1)}", Name = "EditAppointment")]
        public async Task<IActionResult> EditAppointment([FromBody] IServices.Requests.EditAppointment editAppointment, int appointmentId)
        {
            await _appointmentService.EditAppointment(editAppointment, appointmentId);
            return NoContent();
        }

        [ValidateModel]
        [HttpDelete("remove/{appointmentId:min(1)}", Name = "RemoveAppointment")]
        public async Task<IActionResult> RemoveAppointment(int appointmentId)
        {
            await _appointmentService.RemoveAppointment(appointmentId);
            return NoContent();
        }
    }
}
