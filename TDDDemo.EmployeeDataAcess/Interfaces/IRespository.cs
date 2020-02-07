namespace TDDDemo.Employee.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    public interface IRepository<TEntity> where TEntity : class
    {
        
        void Add(TEntity entity);
        void Delete(TEntity entity);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
    }
}
