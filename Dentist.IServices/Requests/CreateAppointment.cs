using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.IServices.Requests
{
    public class CreateAppointment
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int AssistantId { get; set; }
        public DateTime ApDate { get; set; }
        public DateTime ApTime { get; set; }
    }
}
