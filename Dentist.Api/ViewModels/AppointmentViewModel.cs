namespace Dentist.Api.ViewModels
{
    public class AppointmentViewModel
    {
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int AssistantId { get; set; }
        public DateTime ApDate { get; set; }
        public DateTime ApTime { get; set; }
    }
}
