using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Domain.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.RepositoryImplementaion
{
    public static class RepositoriesRegistration
    {
        public static void AddReposServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IOrderingRepository, OrderingReopsitory>();
        }
    }
}
