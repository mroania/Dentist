using FluentValidation;
using Dentist.Api.BindingModels;

namespace Dentist.Api.Validation
{
    public class CreatePatientValidator: AbstractValidator<CreatePatient>
    {
        public CreatePatientValidator()
        {
            RuleFor(x => x.PatientName).NotNull();
            RuleFor(x => x.PatientSurname).NotNull();
            RuleFor(x => x.Gender).NotNull();
            RuleFor(x => x.Pesel).NotNull();
            RuleFor(x => x.BirthDate).NotNull();
            RuleFor(x => x.Phone).NotNull();
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.City).NotNull();
            RuleFor(x => x.Street).NotNull();
            RuleFor(x => x.HouseNumber).NotNull();
        }
    }

}