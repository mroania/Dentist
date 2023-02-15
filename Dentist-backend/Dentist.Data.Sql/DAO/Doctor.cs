using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dentist.Common.Enums;

namespace Dentist.Data.Sql.DAO
{
    public class Doctor
    {
        public Doctor()
        {
            Appointments = new List<Appointment>();
        }

        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string DoctorSurname { get; set; }
        public Gender Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Specialization { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
