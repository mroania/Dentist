using FluentValidation;
using Dentist.Api.BindingModels;

namespace Dentist.Api.Validation
{
    public class EditAppointmentValidator : AbstractValidator<EditAppointment>
    {
        public EditAppointmentValidator()
        {
            RuleFor(x => x.PatientId).NotNull();
            RuleFor(x => x.DoctorId).NotNull();
            RuleFor(x => x.AssistantId).NotNull();
            RuleFor(x => x.ApDate).NotNull();
            RuleFor(x => x.ApTime).NotNull();
        }
    }
}
