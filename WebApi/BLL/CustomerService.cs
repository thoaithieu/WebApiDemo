using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApi.DTO;
using WebApi.Interface.UnitOfWork;
using WebApi.Models;
using WebApi.Models.ViewModel;
using WebApi.Service;

namespace WebApi.BLL
{
    public class CustomerService : IService<CustomerViewModel>
    {
        IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper) { _unitOfWork = unitOfWork; _mapper = mapper; }

        public IEnumerable<CustomerViewModel> GetAll(Models.Filter filter, int page, int size)
        {
            if (size <= 0 || size > 20) size = 20;
            if (page == 0) page = 1;
            return _mapper.Map<List<Customer>, IEnumerable<CustomerViewModel>>(
                   _unitOfWork.CustomerRepository.GetAll()
                   .Where(x => (string.IsNullOrEmpty(filter.Email) || x.Email.ToLower().Contains(filter.Email.ToLower()))
                            && (string.IsNullOrEmpty(filter.Country) || x.Country.ToLower().Contains(filter.Country.ToLower()))
                            && (string.IsNullOrEmpty(filter.City) || x.City.ToLower().Contains(filter.City.ToLower()))
                            && (string.IsNullOrEmpty(filter.Name) || x.FirstName.ToLower().Contains(filter.Name.ToLower()))
                           || (string.IsNullOrEmpty(filter.Name) || x.LastName.ToLower().Contains(filter.Name.ToLower()))
                            )
                   .Skip((page - 1) * size)
                   .Take(size)
                   .ToList());
        }

        public CustomerViewModel GetByID(int id)
        {
            return _mapper.Map<CustomerViewModel>(_unitOfWork.CustomerRepository.GetByID(id));
        }

        public void Insert(CustomerViewModel entity)
        {
            var model = _mapper.Map<Customer>(entity);
            entity.CreateAt = DateTime.Now;
            entity.UpdateAt = DateTime.Now;
            _unitOfWork.CustomerRepository.Insert(model);
            _unitOfWork.Commit();
        }

        public void Update(CustomerViewModel entity)
        {
            entity.UpdateAt = DateTime.Now;
            var modelUpdate = _mapper.Map<Customer>(entity);
            _unitOfWork.CustomerRepository.Update(modelUpdate);
            _unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            _unitOfWork.CustomerRepository.Delete(id);
            _unitOfWork.Commit();
        }
    }
}