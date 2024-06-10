﻿using DataAccessObjects.IRepositories;
using DataAccessObjects.IServices;
using DataAccessObjects.Repositories;
using DataAccessObjects.Services;
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
            services.AddDbContext<AppDbContext>(opts =>
            {
                opts.UseSqlServer(DatabaseConnection);
                opts.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            });
            return services;
        }
    }
}
