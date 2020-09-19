using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.DTO;
using WebApi.Interface.Repository;

namespace WebApi.Interface.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<Customer> CustomerRepository { get;}
        void Commit();
        void Rollback();
    }
}