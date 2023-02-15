using FluentValidation;
using Dentist.Api.BindingModels;

namespace Dentist.Api.Validation
{
    public class CreateAppointmentValidator : AbstractValidator<CreateAppointment>
    {
        public CreateAppointmentValidator()
        {
            RuleFor(x => x.PatientId).NotNull();
            RuleFor(x => x.DoctorId).NotNull();
            RuleFor(x => x.AssistantId).NotNull();
            RuleFor(x => x.ApDate).NotNull();
            RuleFor(x => x.ApTime).NotNull();
        }
    }
}
