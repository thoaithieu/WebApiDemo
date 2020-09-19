using AutoMapper;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.AutoMapper;
using WebApi.BLL;
using WebApi.DAL;
using WebApi.Interface.Repository;
using WebApi.Interface.UnitOfWork;
using WebApi.Models.ViewModel;
using WebApi.Service;

namespace WebApi.Ninject
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IRepository<>)).To(typeof(Repository<>));
            Bind(typeof(IUnitOfWork)).To(typeof(UnitOfWork));
            Bind<IService<CustomerViewModel>>().To<CustomerService>().InSingletonScope();

            var mapperConfiguration = CreateConfiguration();
            Bind<MapperConfiguration>().ToConstant(mapperConfiguration).InSingletonScope();
            Bind<IMapper>().ToMethod(ctx =>
             new Mapper(mapperConfiguration, type => ctx.Kernel.Get(type)));
        }

        private MapperConfiguration CreateConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                // Add all profiles in current assembly
                cfg.AddProfile(new MappingProfile());
            });

            return config;
        }
    }
}