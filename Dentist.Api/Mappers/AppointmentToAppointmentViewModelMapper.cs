using Dentist.Api.ViewModels;

namespace Dentist.Api.Mappers
{
    public class AppointmentToAppointmentViewModelMapper
    {
        public static AppointmentViewModel AppointmentToAppointmentViewModel(Domain.Appointment.Appointment appointment)
        {
            var appointmentViewModel = new AppointmentViewModel
            {
                AppointmentId = appointment.AppointmentId,
                PatientId = appointment.PatientId,
                DoctorId = appointment.DoctorId,
                AssistantId = appointment.AssistantId,
                ApDate = appointment.ApDate,
                ApTime = appointment.ApTime
            };
            return appointmentViewModel;
        }
    }
}
