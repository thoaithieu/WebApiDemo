using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApi.DTO;
using WebApi.Interface.Repository;
using WebApi.Models;

namespace WebApi.DAL
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DB context) : base(context) { }
    }
}