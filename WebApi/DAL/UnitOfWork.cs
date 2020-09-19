using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.DTO;
using WebApi.Interface.Repository;
using WebApi.Interface.UnitOfWork;

namespace WebApi.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DB _databaseContext;
        private IRepository<Condition> _conditionRepository;
        private IRepository<Customer> _customerRepository;
        private IRepository<Make> _makeRepository;
        private IRepository<Model> _modelRepository;
        private IRepository<Vehicle> _vehicleRepository;
        private IRepository<VehicleAppraisal> _vehicleAppraisalRepository;
        private IRepository<AppUserRole> _userRoleRepository;
        public UnitOfWork(DB databaseContext)
        { _databaseContext = databaseContext; }

        public IRepository<Condition> ConditionRepository
        {
            get { return _conditionRepository = _conditionRepository ?? new Repository<Condition>(_databaseContext); }
        }
        public IRepository<Customer> CustomerRepository
        {
            get { return _customerRepository = _customerRepository ?? new Repository<Customer>(_databaseContext); }
        }
        public IRepository<Make> MakeRepository
        {
            get { return _makeRepository = _makeRepository ?? new Repository<Make>(_databaseContext); }
        }
        public IRepository<Model> ModelRepository
        {
            get { return _modelRepository = _modelRepository ?? new Repository<Model>(_databaseContext); }
        }
        public IRepository<VehicleAppraisal> VehicleAppraisalRepository
        {
            get { return _vehicleAppraisalRepository = _vehicleAppraisalRepository ?? new Repository<VehicleAppraisal>(_databaseContext); }
        }
        public IRepository<Vehicle> VehicleRepository
        {
            get { return _vehicleRepository = _vehicleRepository ?? new Repository<Vehicle>(_databaseContext); }
        }
       
        public void Commit()
        {
            _databaseContext.SaveChanges();
        }

        public void Rollback()
        { _databaseContext.Dispose(); }
    }
}