using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using JustMVP.Domain;

namespace JustMVP.DAL
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        public IEnumerable<T> GetAll();
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> expression);
        public T GetById(int id);
        public void Add(T entity);
        public void Update(T entity);
        public void DeleteById(int id);
    }
}
