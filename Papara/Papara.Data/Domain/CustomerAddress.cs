using Papara.Base.Entity;

namespace Papara.Data.Domain
{
	public class CustomerAddress : BaseEntity
	{
		public long CustomerId { get; set; }
		public virtual Customer Customer { get; set; }

		public string Country { get; set; }
		public string City { get; set; }
		public string AddressLine { get; set; }
		public string ZipCode { get; set; }
		public bool IsDefault { get; set; }
	}
}
