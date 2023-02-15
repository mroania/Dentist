using System;
using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace Dentist.Api.BindingModels
{
    public class EditAppointment
    {
        [Required]
        [Display(Name = "PatientId")]
        public int PatientId { get; set; }

        [Required]
        [Display(Name = "DoctorId")]
        public int DoctorId { get; set; }

        [Required]
        [Display(Name = "AssistantId")]
        public int AssistantId { get; set; }

        [Required]
        [Display(Name = "ApDate")]
        public DateTime ApDate { get; set; }

        [Required]
        [Display(Name = "ApTime")]
        public DateTime ApTime { get; set; }
    }
}
