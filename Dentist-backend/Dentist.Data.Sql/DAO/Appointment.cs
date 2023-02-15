using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Data.Sql.DAO
{
    public class Appointment
    {
        public Appointment()
        {
            AppointmentTreatments = new List<AppointmentTreatment>();
        }

        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int AssistantId { get; set; }
        public DateTime ApDate { get; set; }
        public DateTime ApTime { get; set; }

        public virtual Assistant Assistant { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Doctor Doctor { get; set; }

        public virtual ICollection<AppointmentTreatment> AppointmentTreatments { get; set; }
    }
}
