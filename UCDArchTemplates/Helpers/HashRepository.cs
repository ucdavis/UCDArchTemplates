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

        public Customer GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Customer GetNullableByID(int id)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void EnsurePersistent(Customer entity, bool forceSave)
        {
            throw new NotImplementedException();
        }

        public void Remove(Customer entity)
        {
            throw new NotImplementedException();
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