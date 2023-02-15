using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dentist.Common.Enums;

namespace Dentist.Data.Sql.DAO
{
    public class Assistant
    {
        public Assistant()
        {
            Appointments = new List<Appointment>();
        }

        public int AssistantId { get; set; }
        public string AssistantName { get; set; }
        public string AssistantSurname { get; set; }
        public Gender Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
