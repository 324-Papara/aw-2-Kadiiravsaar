using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

		[HttpGet]
		public async Task<List<Customer>> GetAll()
		{
			var entityList = await _unitOfWork.CustomerRepository.GetAll();
			return entityList;
		}

		[HttpGet("{customerId}")]
		public async Task<Customer> Get(long customerId)
		{
			var entity = await _unitOfWork.CustomerRepository.GetById(customerId);
			return entity;
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
