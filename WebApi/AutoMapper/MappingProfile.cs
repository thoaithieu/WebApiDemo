using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.DTO;
using WebApi.Models.ViewModel;

namespace WebApi.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerViewModel, Customer>().ReverseMap();
            CreateMap<List<Customer>, List<CustomerViewModel>>().ReverseMap();
        }
    }
}