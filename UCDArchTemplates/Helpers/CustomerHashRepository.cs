using System;
using System.Collections.Generic;
using System.Linq;
using UCDArch.Core.PersistanceSupport;
using UCDArchTemplates.Models;

namespace UCDArchTemplates.Helpers
{
    public class CustomerHashRepository : IRepository<Customer>
    {
        private readonly IList<Customer> _customers;

        public CustomerHashRepository()
        {
            _customers = Customer.GetAll();
        }

        public Customer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Customer GetNullableById(int id)
        {
            return Queryable.First();
        }

        public IList<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public IList<Customer> GetAll(string propertyName, bool ascending)
        {
            throw new NotImplementedException();
        }

        public void EnsurePersistent(Customer entity)
        {
            
        }

        public void EnsurePersistent(Customer entity, bool forceSave)
        {
            
        }

        public void EnsurePersistent(Customer entity, bool forceSave, bool flushChanges)
        {

        }

        public void Remove(Customer entity)
        {
            
        }

        public void Remove(Customer entity, bool flushChanges)
        {

        }

        public IQueryable<Customer> Queryable
        {
            get
            {
                return _customers.AsQueryable();
            }
        }

        public IDbContext DbContext
        {
            get { throw new NotImplementedException(); }
        }
    }
}