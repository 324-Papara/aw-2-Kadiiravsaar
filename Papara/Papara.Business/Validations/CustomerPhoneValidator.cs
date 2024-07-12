using FluentValidation;
using Papara.Data.Domain;

namespace Papara.Business.Validations
{
	public class CustomerPhoneValidator : AbstractValidator<CustomerPhone>
	{
		public CustomerPhoneValidator()
		{
			RuleFor(p => p.CountryCode)
				.NotEmpty().WithMessage("Country code is required")
				.MaximumLength(3).WithMessage("Country code must be up to 3 characters long");

			RuleFor(p => p.Phone)	
				.NotEmpty().WithMessage("Phone number is required")
				.MaximumLength(10).WithMessage("Phone number must be up to 10 characters long");
		}
	}
}
