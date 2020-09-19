using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebApi.Models;

namespace WebApi.Service
{
    public interface IService<T>
    {
        IEnumerable<T> GetAll(Models.Filter filter, int page, int size);
        T GetByID(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
