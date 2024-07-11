using Papara.Data.Context;
using Papara.Data.Domain;
using Papara.Data.GenericRepository;

namespace Papara.Data.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork, IDisposable
	{
		private readonly PaparaMsSqlDbContext _context;

		public IGenericRepository<Customer> CustomerRepository { get; }
		public IGenericRepository<CustomerDetail> CustomerDetailRepository { get; }
		public IGenericRepository<CustomerAddress> CustomerAddressRepository { get; }
		public IGenericRepository<CustomerPhone> CustomerPhoneRepository { get; }

		//ICustomerRepository CustomerRepository { get; }  => Custom Sorgular eklemek istersem bunu kullanıp (IGenericRepository<Customer> CustomerRepository { get; }) iptal edicem

		public UnitOfWork(PaparaMsSqlDbContext context)
		{
			_context = context;

			//CustomerRepository = new CustomerRepository(_context);
			CustomerRepository = new GenericRepository<Customer>(_context);
			CustomerDetailRepository = new GenericRepository<CustomerDetail>(_context);
			CustomerAddressRepository = new GenericRepository<CustomerAddress>(_context);
			CustomerPhoneRepository = new GenericRepository<CustomerPhone>(_context);


		}
		public void Dispose()
		{
			_context.Dispose();
		}


		public async Task Complete()
		{
			using (var dbTransaction = await _context.Database.BeginTransactionAsync())
			{
				try
				{
					await _context.SaveChangesAsync();
					await dbTransaction.CommitAsync();

				}
				catch (Exception ex)
				{

					await dbTransaction.RollbackAsync();
					Console.WriteLine(ex);
					throw;
				}
			}
		}

	}
}
