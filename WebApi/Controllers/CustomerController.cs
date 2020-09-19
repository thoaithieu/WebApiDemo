using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using WebApi.DAL;
using WebApi.DTO;
using WebApi.Interface.Repository;
using WebApi.Models;
using WebApi.Models.ViewModel;
using WebApi.Service;

namespace WebApi.Controllers
{
    public class CustomerController : ApiController
    {
        private readonly IService<CustomerViewModel> _customerService;

        public CustomerController(IService<CustomerViewModel> CustomerSerivce)
        {
            _customerService = CustomerSerivce;
        }

        [HttpGet]
        public IEnumerable<CustomerViewModel> GetCustomers([FromUri] Filter filter, int page = 1, int size = 20) => _customerService.GetAll(filter, page, size);

        [HttpGet]
        public CustomerViewModel GetCustomer(int id) => _customerService.GetByID(id);

        [HttpPost]
        public bool Insert(CustomerViewModel customerViewModel)
        {
            if (ModelState.IsValid)
            {
                customerViewModel = new CustomerViewModel();
                _customerService.Insert(customerViewModel);
            }
            return true;
        }

        [HttpPut]
        public bool Update(int id, CustomerViewModel customerViewModel)
        {
            if (id != customerViewModel.Id)
            {
                return false;
            }
            _customerService.Update(customerViewModel);
            return true;
        }

        [HttpDelete]
        public bool DeleteCustomer(int id)
        {
            try
            {
                _customerService.Delete(id);
                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}
