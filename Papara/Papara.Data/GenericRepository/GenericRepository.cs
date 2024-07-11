using Microsoft.EntityFrameworkCore;
using Papara.Base.Entity;
using Papara.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Papara.Data.GenericRepository
{
	public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
	{
		public readonly PaparaMsSqlDbContext dbContext;

		public GenericRepository(PaparaMsSqlDbContext dbContext)
		{
			this.dbContext = dbContext;
		}



		public async Task Save()
		{
			await dbContext.SaveChangesAsync();
		}

		public async Task<TEntity> GetById(long id)
		{
			return await dbContext.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task Insert(TEntity entity)
		{
			entity.IsActive = true;
			entity.InsertDate = DateTime.Now;
			entity.InsertUser = "System";

			await dbContext.Set<TEntity>().AddAsync(entity);
		}
		public async Task Update(TEntity entity)
		{
			dbContext.Set<TEntity>().Update(entity);
		}

		public async Task Delete(TEntity entity)
		{
			dbContext.Set<TEntity>().Remove(entity);

		}

		public async Task Delete(long id)
		{
			var entity = await dbContext.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
			dbContext.Set<TEntity>().Remove(entity);
		}

		public async Task<List<TEntity>> GetAll()
		{
			return await dbContext.Set<TEntity>().ToListAsync();
		}

	

	}
}
