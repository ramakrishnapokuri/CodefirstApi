using FluentValidation;
using PrasadCodeFirst.Services.Models.Company;
using System.Linq;

namespace PrasadCodeFirst.Services.Models.CompanyValidators.Validators
{
    public class EmployeeModelValidator : AbstractValidator<EmployeeModel>
    {
        public EmployeeModelValidator()
        {
            RuleFor(e => e).Must(e => e != null).WithName("Employee").WithMessage("Employee cannot be null.");

            When(e => e != null, () =>
            {
                RuleFor(e => e.Name).Must(n => !string.IsNullOrWhiteSpace(n)).WithMessage("Employee name is required.");
                RuleFor(e => e.Email).Must(n => !string.IsNullOrWhiteSpace(n)).EmailAddress().WithMessage("Invalid Email.").When(s => !string.IsNullOrWhiteSpace(s.Email));
                RuleFor(e => e.Mobile).Must(n => !string.IsNullOrWhiteSpace(n) && n.Length == 10 && n.All(char.IsDigit)).WithMessage("Invalid mobile number.");
            });
        }
    }
}