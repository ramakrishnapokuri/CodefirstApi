using FluentValidation;
using PrasadCodeFirst.Services.Models.Company;

namespace PrasadCodeFirst.Services.Models.CompanyValidators.Validators
{
    public class EmployerModelValidator : AbstractValidator<EmployerModel>
    {
        public EmployerModelValidator()
        {
            RuleFor(e => e).Must(e => e != null).WithName("Employer").WithMessage("Employer cannot be null.");

            When(e => e != null, () =>
            {
                RuleFor(e => e.Name).Must(n => !string.IsNullOrWhiteSpace(n)).WithMessage("Employer Name is required.");
                RuleFor(e => e.Email).Must(n => !string.IsNullOrWhiteSpace(n)).EmailAddress().WithMessage("Invalid Email.").When(s => !string.IsNullOrWhiteSpace(s.Email));
            });
        }
    }
}