﻿using Autofac;
using Autofac.Extensions.DependencyInjection;
using MediatR;
using Microsoft.Extensions.Options;
using Serilog;
using SixLabors.ImageSharp.Web.DependencyInjection;
using UserManagement.core.commands.user;
using UserManagement.core.di;
using UserManagement.core.shared;
using UserManager.api.filters;

namespace UserManager.api;

public static class ServiceRegistrationExtension
{
    public static WebApplicationBuilder RegisterApplicationServices(this WebApplicationBuilder builder)
    {
        var appConfig = builder.Configuration.GetSection(nameof(AppConfig));
        builder.Services.Configure<AppConfig>(appConfig)
            .AddSingleton(sp => sp.GetService<IOptions<AppConfig>>()?.Value);
        // Add services to the container.
        builder.Services.AddControllers(opts =>
        {
            opts.Filters.Add(typeof(LogRequestHeaderActionFilter));
        });
        /*builder.Services.AddSignalR(opt =>
        {
            
        });*/

        builder.Logging.AddSerilog(dispose:true);
       
        builder.Services.AddLocalization();
        builder.Services.AddCors(opt =>
        {
            opt.AddPolicy("angularClientPolicy", policyBuilder =>
            {
                policyBuilder.AllowAnyOrigin();
                policyBuilder.AllowAnyHeader().AllowAnyMethod();
            });
        });
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddMediatR(opt =>
        {
            opt.RegisterServicesFromAssembly(typeof(CreateUserCommand).Assembly);
        });
        builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory(containerBuilder =>
        {
            containerBuilder.RegisterModule<AppDiRegistration>();
            //containerBuilder.Build();
        }));

        return builder;
    }
}
