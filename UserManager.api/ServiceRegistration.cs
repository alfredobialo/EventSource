using Autofac;
using Autofac.Extensions.DependencyInjection;
using MediatR;
using Microsoft.Extensions.Options;
using UserManagement.core.commands.user;
using UserManagement.core.di;
using UserManagement.core.shared;

namespace UserManager.api;

public class ServiceRegistration
{
    public static void RegisterApplicationServices(WebApplicationBuilder builder)
    {
        var appConfig = builder.Configuration.GetSection(nameof(AppConfig));
        builder.Services.Configure<AppConfig>(appConfig)
            .AddSingleton(sp => sp.GetService<IOptions<AppConfig>>().Value);
        // Add services to the container.
        builder.Services.AddControllers();
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
        builder.Services.AddMediatR(typeof(CreateUserCommand).Assembly);
        builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory(containerBuilder =>
        {
            containerBuilder.RegisterModule<AppDiRegistration>();
            //containerBuilder.Build();
        }));
    }
}
