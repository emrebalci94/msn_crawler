using Microsoft.EntityFrameworkCore;
using MsnCrawler.Common.DataAccess;
using MsnCrawler.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MsnCrawler.DataAccess.EntityFramework
{
    public class EfBaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private DbSet<TEntity> _table { get; }
        private readonly CrawlerContext _context;
        public EfBaseRepository(CrawlerContext context)
        {
            _context = context;
            _table = _context.Set<TEntity>();
        }

        int Save()
        {
            return _context.SaveChanges();
        }

        public int Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            _table.Remove(entity);
            return Save();
        }

        public int Delete(List<TEntity> entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            _table.RemoveRange(entity);
            return Save();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> expression)
        {
            return _table.SingleOrDefault(expression);
        }

        public IQueryable<TEntity> GetIncludes(params Expression<Func<TEntity, object>>[] includes)
        {
            var query = (IQueryable<TEntity>)_table;
            return includes != null ?
                 includes.Aggregate(query, (current, include) => current.Include(include)) : query; //Aggregate methodu ilgili Queryable a parametreden gelen includeları otomatik basıyo.
        }

        public List<TEntity> GetList()
        {
            return _table.ToList();
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> expression)
        {
            return _table.Where(expression).ToList();
        }

        public IQueryable<TEntity> GetQueryable()
        {
            return _table;
        }

        public IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> where)
        {
            return _table.Where(where);
        }

        public int Insert(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            _table.Add(entity);
            return Save();
        }

        public int Insert(List<TEntity> entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            _table.AddRange(entity);
            return Save();
        }

        public int Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            _table.Update(entity);
            return Save();
        }

        public bool Any(Expression<Func<TEntity, bool>> where)
        {
            return _table.Any(where);
        }

        public bool HasById(int id)
        {
            return Any(p => p.Id == id);
        }

        public TEntity GetById(int id)
        {
            return Get(p => p.Id == id);
        }
    }
}
