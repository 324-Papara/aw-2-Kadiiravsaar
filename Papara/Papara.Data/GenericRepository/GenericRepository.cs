using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
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
		public readonly PaparaMsSqlDbContext _context;

		public GenericRepository(PaparaMsSqlDbContext context)
		{
			_context = context;
		}
		
		public async Task Save()
		{
			await _context.SaveChangesAsync();
		}

		public async Task<TEntity> GetById(long id)
		{
			return await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task Insert(TEntity entity)
		{
			entity.IsActive = true;
			entity.InsertDate = DateTime.Now;
			entity.InsertUser = "System";

			await _context.Set<TEntity>().AddAsync(entity);
		}
		public async Task Update(TEntity entity)
		{
			_context.Set<TEntity>().Update(entity);
		}
		public async Task Delete(TEntity entity)
		{
			_context.Set<TEntity>().Remove(entity);

		}
		public async Task Delete(long id)
		{
			var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
			_context.Set<TEntity>().Remove(entity);
		}
		public async Task<List<TEntity>> GetAll()
		{
			return await _context.Set<TEntity>().ToListAsync();
		}


		public IQueryable<TEntity> Query() => _context.Set<TEntity>();

		public async Task<TEntity> Get(long id,
		   Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
		{
			IQueryable<TEntity> queryable = Query();

			if (include != null)
				queryable = include(queryable);

			return await queryable.FirstOrDefaultAsync(x=>x.Id == id);
		}

		public async Task<List<TEntity>> GetAll(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
		{
			IQueryable<TEntity> queryable = Query();

			if (include != null)
				queryable = include(queryable);

			return await queryable.ToListAsync();
		}

		public async Task<List<TEntity>> Where(Expression<Func<TEntity, bool>> filter)
		{
			return await _context.Set<TEntity>().Where(filter).ToListAsync();
		}
	}
}
