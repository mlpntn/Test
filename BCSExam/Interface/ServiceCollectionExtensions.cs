using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCSExam.Repository;
using Microsoft.Extensions.DependencyInjection;


namespace BCSExam.Interface
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterRepoServices(this IServiceCollection services)
        {
            services.AddTransient<IGuestRepo, GuestRepo>();
            return services;
        }
    }
}
