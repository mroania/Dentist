using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.IData.Appointment
{
    public interface IAppointmentRepository
    {
        Task<int> AddAppointment(Dentist.Domain.Appointment.Appointment appointment);
        Task<Dentist.Domain.Appointment.Appointment> GetAppointment(int appointmentId);
        Task EditAppointment(Domain.Appointment.Appointment appointment);
        Task RemoveAppointment(int appointmentId);
    }
}
