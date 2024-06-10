using AutoMapper;
using BusinessObjects;
using DataAccessObjects.ViewModels.AccountDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.Mappers
{
    public class MapperConfigurationProfile : Profile
    {
        public MapperConfigurationProfile()
        {
            CreateMap<User, LoginAccountDTOs>().ReverseMap();
            CreateMap<User, RegisterAccountDTOs>().ReverseMap();    
            CreateMap<User, AccountDTOs>().ReverseMap();
        }
    }
}
