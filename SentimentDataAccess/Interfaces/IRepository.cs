using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SentimentDataAccess.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
		TEntity Get(long oid);
		IQueryable<TEntity> GetAll();

		Int64 Add(TEntity entity);
		void AddRange(List<TEntity> entities);
		void Update(TEntity entity);
		void UpdateRange(List<TEntity> entities);
		void Delete(TEntity entity);
		void DeleteRange(List<TEntity> entities);

		List<TEntity> GetAllSkipTake(int skip, int take);

	}
}
