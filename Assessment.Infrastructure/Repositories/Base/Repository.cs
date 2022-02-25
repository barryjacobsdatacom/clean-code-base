using Assessment.Core.Repositories.Base;
using Assessment.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assessment.Infrastructure.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly EmployeeContext _employeeContext;
        public Repository(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }
        public T Add(T entity)
        {
            _employeeContext.Set<T>().Add(entity);
            _employeeContext.SaveChanges();
            return entity;
        }
        public void Delete(T entity)
        {
            _employeeContext.Set<T>().Remove(entity);
            _employeeContext.SaveChanges();
        }
        public IReadOnlyList<T> GetAll()
        {
            return _employeeContext.Set<T>().ToList();
        }
        public T GetById(int id)
        {
            return _employeeContext.Set<T>().Find(id);
        }
        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }


}
