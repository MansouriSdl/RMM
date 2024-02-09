using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RMM.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RMM.DI
{
    public static class RegistrationInfrastracture
    {
        public static IServiceCollection AddRegistrationInfra(this IServiceCollection Services, IConfiguration config)
        {
            Services.AddDbContext<ReportingDbContext>(o =>
            o.UseSqlServer(config.GetConnectionString("RMMConnectionString")));
            return Services;
           
        }
    }
}