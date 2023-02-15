using System;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using Dentist.Common.Enums;

namespace Dentist.Api.BindingModels
{
    public class EditPatient
    {
        [Required]
        [Display(Name = "PatientName")]
        public string PatientName { get; set; }

        [Required]
        [Display(Name = "PatientSurame")]
        public string PatientSurname { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public Gender Gender { get; set; }

        [Required]
        [Display(Name = "Pesel")]
        public string Pesel { get; set; }

        [Required]
        [Display(Name = "BirthDate")]
        public DateTime BirthDate { get; set; }

        [Required]
        [Phone]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        [Display(Name = "Street")]
        public string Street { get; set; }

        [Required]
        [Display(Name = "HouseNumber")]
        public string HouseNumber { get; set; }
    }
}
