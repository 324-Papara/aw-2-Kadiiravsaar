using Papara.Base.Entity;

namespace Papara.Data.Domain
{
	public class CustomerPhone : BaseEntity
	{
		public long CustomerId { get; set; }
		public virtual Customer Customer { get; set; }
		public string CountryCode { get; set; } // TUR
		public string Phone { get; set; }
		public bool IsDefault { get; set; }
	}
}
