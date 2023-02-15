using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dentist.IServices.Requests;

namespace Dentist.IServices.Appointment
{
    public interface IAppointmentService
    {
        Task<Dentist.Domain.Appointment.Appointment> GetAppointmentByAppointmentId(int appointmentId);
        Task<Dentist.Domain.Appointment.Appointment> CreateAppointment(CreateAppointment createAppointment);
        Task EditAppointment(EditAppointment editAppointment, int appointmentId);
        Task RemoveAppointment(int appointmentId);
    }
}
