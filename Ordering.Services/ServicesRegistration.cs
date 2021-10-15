using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Domain.Repositories.Interface;
using Ordering.Services.Services.Implementations;
using Ordering.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Services
{
    public static class ServicesRegistration
    {
        public static void AddDomainServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IOrderingService, OrderingService>();
        }
    }
}
