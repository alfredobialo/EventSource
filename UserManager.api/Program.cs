using UserManager.api;

var builder = WebApplication.CreateBuilder(args);

ServiceRegistration.RegisterApplicationServices(builder);

var app = builder.Build();

app = AppFeatures.Use(app);

app.Run();
