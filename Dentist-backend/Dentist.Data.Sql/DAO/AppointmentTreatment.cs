using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Data.Sql.DAO
{
    public class AppointmentTreatment
    {
        public int AppointmentTreatmentId { get; set; }
        public int AppointmentId { get; set; }
        public int TreatmentId { get; set; }

        public virtual Treatment Treatment { get; set; }
        public virtual Appointment Appointment { get; set; }
    }
}
