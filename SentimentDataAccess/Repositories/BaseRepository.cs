using Microsoft.EntityFrameworkCore;
using SentimentModel.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SentimentDataAccess.Repositories
{
    public abstract class BaseRepository<TEntity, TContext> 
        where TEntity : class, IOID, new() 
        where TContext : DbContext, new()
    {
		protected TContext _entities;
		public BaseRepository()
		{
			//_entities = PDI.Resolve<TContext>();
			_entities = new TContext();
		}

		protected DbSet<TEntity> GetDbSet()
		{
			return _entities.Set<TEntity>();
		}

		public void Save()
		{
			_entities.SaveChanges();
		}

		protected virtual long GetOid(TEntity entity)
		{
			if (entity is IOID)
				return ((IOID)entity).OID;
			return -1;
		}

		public virtual TEntity Get(long oid)
		{
			return GetDbSet().Find(oid);
		}

		public virtual IQueryable<TEntity> GetAll()
        {
			return GetDbSet();
        }

		public virtual Int64 Add(TEntity entity)
		{
			GetDbSet().Add(entity);
			Save();
			return entity.OID;
			//return GetOid(entity);
		}

		public virtual void AddRange(List<TEntity> entities)
		{
			GetDbSet().AddRange(entities);
			Save();
			return;
		}

		public virtual void Update(TEntity entity)
		{
			GetDbSet().Update(entity);
			Save();
			return;
		}

		public virtual void UpdateRange(List<TEntity> entities)
		{
			GetDbSet().UpdateRange(entities);
			Save();
			return;
		}

		public virtual void Delete(TEntity entity)
		{
			GetDbSet().Remove(entity);
			Save();
			return;
		}

		public virtual void DeleteRange(List<TEntity> entities)
		{
			GetDbSet().RemoveRange(entities);
			Save();
			return;
		}

		public virtual List<TEntity> GetAllSkipTake(int skip, int take)
		{
			return GetDbSet().OrderBy(x => x.OID).Skip(skip).Take(take).ToList();
		}



	}
}
