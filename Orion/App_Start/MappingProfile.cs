using AutoMapper;
using Orion.Controllers.Api;
using Orion.Dtos;
using Orion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orion.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Book, BookDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();

            Mapper.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id,opt=> opt.Ignore());
            Mapper.CreateMap<BookDto, Book>().ForMember(b => b.Id, opt => opt.Ignore());
        }

    }
}