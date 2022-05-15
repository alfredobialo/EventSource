using Autofac;
using Autofac.Extensions.DependencyInjection;
using MediatR;
using Microsoft.Extensions.Options;
using UserManagement.core.commands;
using UserManagement.core.commands.user;
using UserManagement.core.di;
using UserManagement.core.Services.users.dataStore;
using UserManagement.core.shared;

var builder = WebApplication.CreateBuilder(args);

var appConfig = builder.Configuration.GetSection(nameof(AppConfig));
builder.Services.Configure<AppConfig>(appConfig)
    .AddSingleton(sp => sp.GetService<IOptions<AppConfig>>().Value);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(CreateUserCommand).Assembly);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory(containerBuilder =>
{
    containerBuilder.RegisterModule<AppDiRegistration>();
    //containerBuilder.Build();
}));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
