using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Papara.Data.Domain;
using Papara.Data.UnitOfWork;

namespace Papara.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomersController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;

		public CustomersController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}



		[HttpGet("GetAllCustomersWithDetails")]
		public async Task<List<Customer>> GetAllCustomersWithDetails()
		{
			var customers = await _unitOfWork.CustomerRepository.GetAll(
			include: x => x.Include(c => c.CustomerDetail)
						   .Include(c => c.CustomerAddresses)
						   .Include(c => c.CustomerPhones));

			return customers;
		}

		[HttpGet("GetAllCustomers")]
		public async Task<List<Customer>> GetAllCustomers()
		{
			var customers = await _unitOfWork.CustomerRepository.GetAll();
			return customers;
		}


		[HttpGet("GetCustomerByIdWithDetails/{customerId}")]
		public async Task<Customer> GetCustomerByIdWithDetails(long customerId)
		{
			var customersId = await _unitOfWork.CustomerRepository.Get(
					customerId,
					include: x => x.Include(c => c.CustomerDetail
					));
			return customersId;
		}

		[HttpGet("GetCustomerById/{customerId}")]
		public async Task<Customer> GetCustomerById(long customerId)
		{
			var customersId = await _unitOfWork.CustomerRepository.GetById(customerId);
			return customersId;
		}

		[HttpGet("GetCustomersByFirstName")]
		public async Task<List<Customer>> GetCustomersByFirstName(string firstName)
		{
			var customerName = await _unitOfWork.CustomerRepository.Where(c => c.FirstName == firstName);
			return customerName;
		}

		[HttpPost]
		public async Task Post([FromBody] Customer value)
		{
			await _unitOfWork.CustomerRepository.Insert(value);
			await _unitOfWork.CustomerRepository.Insert(value);
			await _unitOfWork.CustomerRepository.Insert(value);
			await _unitOfWork.Complete();
		}

		[HttpPut("{customerId}")]
		public async Task Put(long customerId, [FromBody] Customer value)
		{
			await _unitOfWork.CustomerRepository.Update(value);
			await _unitOfWork.Complete();
		}

		[HttpDelete("{customerId}")]
		public async Task Delete(long customerId)
		{
			await _unitOfWork.CustomerRepository.Delete(customerId);
			await _unitOfWork.Complete();
		}


	}
}
