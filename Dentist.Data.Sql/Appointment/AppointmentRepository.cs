using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dentist.IData.Appointment;
using Microsoft.EntityFrameworkCore;

namespace Dentist.Data.Sql.Appointment
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly DentistDbContext _context;

        public AppointmentRepository(DentistDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAppointment(Domain.Appointment.Appointment appointment)
        {
            var appointmentDAO = new DAO.Appointment
            {
                PatientId = appointment.PatientId,
                DoctorId = appointment.DoctorId,
                AssistantId = appointment.AssistantId,
                ApDate = appointment.ApDate,
                ApTime = appointment.ApTime,
            };

            await _context.AddAsync(appointmentDAO);
            await _context.SaveChangesAsync();
            return appointmentDAO.AppointmentId;
        }

        public async Task<Domain.Appointment.Appointment> GetAppointment(int appointmentId)
        {
            var appointment = await _context.Appointment.FirstOrDefaultAsync(x => x.AppointmentId == appointmentId);
            return new Domain.Appointment.Appointment(appointment.AppointmentId,
                appointment.PatientId,
                appointment.DoctorId,
                appointment.AssistantId,
                appointment.ApDate,
                appointment.ApTime);
        }

        public async Task EditAppointment(Domain.Appointment.Appointment appointment)
        {
            var editAppointment = await _context.Appointment.FirstOrDefaultAsync(x => x.AppointmentId == appointment.AppointmentId);
            editAppointment.PatientId = appointment.PatientId;
            editAppointment.DoctorId = appointment.DoctorId;
            editAppointment.AssistantId = appointment.AssistantId;
            editAppointment.ApDate = appointment.ApDate;
            editAppointment.ApTime = appointment.ApTime;

            await _context.SaveChangesAsync();
        }

        public async Task RemoveAppointment(int appointmentId)
        {
            var removeAppointmentTreatments = _context.AppointmentTreatment.Where(x => x.AppointmentId == appointmentId);
            _context.AppointmentTreatment.RemoveRange(removeAppointmentTreatments);

            var removeappointment = await _context.Appointment.FirstOrDefaultAsync(x => x.AppointmentId == appointmentId);
            if (removeappointment != null)
            {
                _context.Appointment.Remove(removeappointment);
            }

            await _context.SaveChangesAsync();
        }

    }
}
