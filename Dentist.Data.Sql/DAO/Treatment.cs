using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Data.Sql.DAO
{
    public class Treatment
    {
        public Treatment()
        {
            AppointmentTreatments = new List<AppointmentTreatment>();
        }

        public int TreatmentId { get; set; }
        public string TreatmentName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<AppointmentTreatment> AppointmentTreatments { get; set; }
    }
}
