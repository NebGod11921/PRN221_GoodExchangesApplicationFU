using DataAccessObjects.IRepositories;
using DataAccessObjects.IServices;
using DataAccessObjects.Mappers;
using DataAccessObjects.Repositories;
using DataAccessObjects.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddInfrastructuresServices(this IServiceCollection services, string DatabaseConnection)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddAutoMapper(typeof(MapperConfigurationProfile).Assembly);
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepo, ProductRepo>();
            services.AddScoped<ITransactionRepo, TransactionRepo>();
            services.AddScoped<IPaymentRepo, PaymentRepo>();
            services.AddScoped<ITransactionTypeRepo, TransactionTypeRepo>();
            services.AddScoped<IAddToCartService, CartService>();
            services.AddScoped<ITransactionTypeService, TransactionTypeService>();
           
            services.AddDbContext<AppDbContext>(opts =>
            {
                opts.UseSqlServer(DatabaseConnection);
                opts.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            });
            services.AddAutoMapper(typeof(MapperConfigurationProfile).Assembly);
            return services;
        }
    }
}
