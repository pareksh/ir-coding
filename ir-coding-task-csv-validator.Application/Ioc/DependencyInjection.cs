using ir_coding_task_csv_validator.Application.Contract;
using ir_coding_task_csv_validator.Application.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ir_coding_task_csv_validator.Application.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppDependencies(this IServiceCollection services)
        {
            services.AddMediatR(cgf => cgf.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddScoped<IValidatorService,ValidatorService>();

            return services;
        }
    }
}
