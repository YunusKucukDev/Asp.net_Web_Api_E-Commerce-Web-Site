using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Order.Application.Services
{
    public static class ServiceRegistarion
    {
        public static void AddAplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(ServiceRegistarion).Assembly);
        }
    }
}
