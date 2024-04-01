
using Microsoft.Extensions.DependencyInjection;
using BlogPost.Application.Profiles;
using MediatR;

using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace BlogPost.Application;
public static class ApplicationServiceRegistration
{
    public static IServiceCollection ConfigureApplicationService(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
        return services;
    }    
}