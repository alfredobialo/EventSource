using UserManager.api;

var webApp = WebApplication
    .CreateBuilder(args)
    .RegisterApplicationServices()
    .Build();

var app = webApp;

app = AppFeatures.Use(app);

app.Run();
