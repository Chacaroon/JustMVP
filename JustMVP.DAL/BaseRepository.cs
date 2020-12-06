using JustMVP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace JustMVP.DAL
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly ApplicationContext _context;

        protected virtual IQueryable<T> BaseQuery => _context.Set<T>();

        public BaseRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return BaseQuery.ToList();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return BaseQuery.Where(expression).ToList();
        }

        public T GetById(int id)
        {
            return GetAll(x => x.Id == id).FirstOrDefault();
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            _context.Set<T>().Remove(_context.Set<T>().Find(id));
            _context.SaveChanges();
        }
    }
}
