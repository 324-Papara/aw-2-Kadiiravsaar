using FluentValidation;
using Papara.Data.Domain;

namespace Papara.Business.Validations
{
	public class CustomerAddressValidator : AbstractValidator<CustomerAddress>
	{
		public CustomerAddressValidator()
		{
			RuleFor(a => a.Country)
				.NotEmpty().WithMessage("Country is required")
				.MaximumLength(50).WithMessage("Country must be to 50 characters long ");

			RuleFor(a => a.City)
				.NotEmpty().WithMessage("City is required")
				.MaximumLength(50).WithMessage("City must be to 50 characters long ");

			RuleFor(a => a.AddressLine)
				.NotEmpty().WithMessage("Address line is required")
				.MaximumLength(250).WithMessage("Address line must be to 250 characters long ");

			RuleFor(a => a.ZipCode)
				.NotEmpty().WithMessage("Zip code is required")
				.MaximumLength(6).WithMessage("Zip code must be to 250 characters long ");
		}
	}
}
