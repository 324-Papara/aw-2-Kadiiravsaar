using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Papara.Data.GenericRepository
{
	public interface IGenericRepository<TEntity> where TEntity : class
	{
		Task Save();
		Task<TEntity?> GetById(long Id);
		Task Insert(TEntity entity);
		Task Update(TEntity entity);
		Task Delete(TEntity entity);
		Task Delete(long Id);
		Task<List<TEntity>> GetAll();
	}
}
