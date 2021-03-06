﻿using InsuranceOffer.Model.Models;
using InsuranceOffer.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceOffer.Data.Repositories
{
   public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

    }

    public interface ICustomerRepository : IRepository<Customer>
    {
    }

}
