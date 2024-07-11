using Microsoft.EntityFrameworkCore;
using Papara.Data.Configuration;
using Papara.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papara.Data.Context
{

	public class PaparaMsSqlDbContext : DbContext
	{
		public PaparaMsSqlDbContext(DbContextOptions<PaparaMsSqlDbContext> options) : base(options)
		{

		}

		public DbSet<Customer> Customers { get; set; }
		public DbSet<CustomerAddress> CustomerAddresses { get; set; }
		public DbSet<CustomerPhone> CustomerPhones { get; set; }
		public DbSet<CustomerDetail> CustomerDetails { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new CustomerConfiguration());
			modelBuilder.ApplyConfiguration(new CustomerDetailConfiguration());
			modelBuilder.ApplyConfiguration(new CustomerAddressConfiguration());
			modelBuilder.ApplyConfiguration(new CustomerPhoneConfiguration());

		}
	}
}
