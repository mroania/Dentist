using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dentist.Domain.DomainExceptions;

namespace Dentist.Domain.Appointment
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int AssistantId { get; set; }
        public DateTime ApDate { get; set; }
        public DateTime ApTime { get; set; }

        public Appointment(int appointmentId, int patientId, int doctorId, int assistentId, DateTime apDate, DateTime apTime)
        {
            AppointmentId = appointmentId;
            PatientId = patientId;
            DoctorId = doctorId;
            AssistantId = assistentId;
            ApDate = apDate;
            ApTime = apTime;
        }

        public Appointment(int patientId, int doctorId, int assistentId, DateTime apDate, DateTime apTime)
        {
            PatientId = patientId;
            DoctorId = doctorId;
            AssistantId = assistentId;
            ApDate = apDate;
            ApTime = apTime;
        }

        public void EditAppointment(int patientId, int doctorId, int assistantId, DateTime apDate, DateTime apTime)
        {
            PatientId = patientId;
            DoctorId = doctorId;
            AssistantId = assistantId;
            ApDate = apDate;
            ApTime = apTime;
        }

        public void RemoveAppointment(int appointmentId, int patientId, int doctorId, int assistentId, DateTime apDate, DateTime apTime)
        {
            AppointmentId = appointmentId;
            PatientId = patientId;
            DoctorId = doctorId;
            AssistantId = assistentId;
            ApDate = apDate;
            ApTime = apTime;
        }
    }
}
