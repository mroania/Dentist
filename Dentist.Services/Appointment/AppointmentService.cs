using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dentist.IServices.Appointment;
using Dentist.IServices.Requests;
using Dentist.IData.Appointment;


namespace Dentist.Services.Appointment
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public Task<Domain.Appointment.Appointment> GetAppointmentByAppointmentId(int appointmentId)
        {
            return _appointmentRepository.GetAppointment(appointmentId);
        }

        public async Task<Domain.Appointment.Appointment> CreateAppointment(CreateAppointment createAppointment)
        {
            var appointment = new Domain.Appointment.Appointment(createAppointment.PatientId, createAppointment.DoctorId, createAppointment.AssistantId, createAppointment.ApDate, createAppointment.ApTime);
            appointment.AppointmentId = await _appointmentRepository.AddAppointment(appointment);
            return appointment;
        }

        public async Task EditAppointment(EditAppointment editAppointment, int appointmentId)
        {
            var appointment = await _appointmentRepository.GetAppointment(appointmentId);
            appointment.EditAppointment(editAppointment.PatientId, editAppointment.DoctorId, editAppointment.AssistantId, editAppointment.ApDate, editAppointment.ApTime);
            await _appointmentRepository.EditAppointment(appointment);
        }

        public async Task RemoveAppointment(int appointmentId)
        {
            await _appointmentRepository.RemoveAppointment(appointmentId);
        }
    }
}
