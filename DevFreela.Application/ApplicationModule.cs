﻿using DevFreela.Application.Commands.InsertComment;
using DevFreela.Application.Commands.InsertProject;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application
{
    public static class ApplicationModule
    {

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            services.AddHandlers();
            return services;
        }

        private static IServiceCollection AddHandlers(this IServiceCollection services)
        {

            services.AddMediatR(config =>
                config.RegisterServicesFromAssemblyContaining<InsertProjectCommand>());
            

            return services;
        }
    }
}
