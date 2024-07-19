using AutoMapper;
using BusinessObjects;
using DataAccessObjects.ViewModels.AccountDTOS;
using DataAccessObjects.ViewModels.PaymentDTOS;
using DataAccessObjects.ViewModels.PostDTOs;
using DataAccessObjects.ViewModels.ProductDTOs;
using DataAccessObjects.ViewModels.ReportDTOS;
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

            //Product
            CreateMap<Product, ProductDTos>().ReverseMap();
            CreateMap<Category, ProductCategoryDTOs>().ReverseMap();

            CreateMap<Product, RequestProductDTO>().ReverseMap();
            CreateMap<Product, ResponseProductDTO>().ReverseMap();
            CreateMap<ResponseProductDTO, RequestProductDTO>().ReverseMap();


            //Transaction
            CreateMap<TransactionType, TransactionTypeDTO>().ReverseMap();
            CreateMap<TransactionProduct, TransactionProductDTOs>().ReverseMap();
            CreateMap<Transaction, TransactionDTOs>().ReverseMap(); 
            CreateMap<Transaction, UpdateTransactionDTOs>().ReverseMap();
            CreateMap<PagingTransaction<Transaction>, PagingTransaction<TransactionDTOs>>().ReverseMap();

            //Payment
            CreateMap<Payment, PaymentDTOs>().ReverseMap();

            //Report 
            CreateMap<Report,ReportRequestModels>().ReverseMap();
            CreateMap<Report,ReportResponseModel>().ReverseMap();
        }
    }
}
