using FluentValidation;
using Papara.Data.Domain;

namespace Papara.Business.Validations
{
	public class CustomerDetailValidator : AbstractValidator<CustomerDetail>
	{
		public CustomerDetailValidator()
		{
			RuleFor(d => d.FatherName)
				.NotEmpty().WithMessage("Father's name is required")
				.MaximumLength(50).WithMessage("Father's name must be to 50 characters long "); 
			
			RuleFor(d => d.MotherName)
				.NotEmpty().WithMessage("Mother's name is required")
				.MaximumLength(50).WithMessage("Mother's name must be to 50 characters long "); 

			RuleFor(d => d.EducationStatus)
				.NotEmpty().WithMessage("Education status is required")
				.MaximumLength(50).WithMessage("Education must be to 50 characters long "); 
			
			RuleFor(d => d.MonthlyIncome)
				.NotEmpty().WithMessage("Monthly income is required")
				.MaximumLength(50).WithMessage("Monthl income must be to 50 characters long "); 
			
			RuleFor(d => d.Occupation)
				.NotEmpty().WithMessage("Occupation is required")
				.MaximumLength(50).WithMessage("Occupation must be to 50 characters long ");
		}
	}
}
