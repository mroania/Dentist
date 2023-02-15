using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dentist.Common.Enums;

namespace Dentist.Data.Sql.DAO
{
    public class Patient
    {
        public Patient()
        {
            Appointments = new List<Appointment>();
        }

        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string PatientSurname { get; set; }
        public Gender Gender { get; set; }
        public string Pesel { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
