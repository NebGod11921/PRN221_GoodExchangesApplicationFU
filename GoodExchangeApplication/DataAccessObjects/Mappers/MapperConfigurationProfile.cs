using AutoMapper;
using BusinessObjects;
using DataAccessObjects.ViewModels.AccountDTOS;
using DataAccessObjects.ViewModels.PostDTOs;
using DataAccessObjects.ViewModels.ProductDTOs;
using DataAccessObjects.ViewModels.ProductDTOs;
using DataAccessObjects.ViewModels.TransactionDTOs;
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
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Post, PostDTO>().ReverseMap();

            //
            CreateMap<Product, ProductDTos>().ReverseMap();


            CreateMap<Product, RequestProductDTO>().ReverseMap();
            CreateMap<Product, ResponseProductDTO>().ReverseMap();
            CreateMap<ResponseProductDTO, RequestProductDTO>().ReverseMap();


            //Transaction
            CreateMap<TransactionType, TransactionTypeDTO>().ReverseMap();

        }
    }
}
