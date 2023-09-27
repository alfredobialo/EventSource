using Serilog;
using UserManager.api;
var webApp = WebApplication
    .CreateBuilder(args)
    .RegisterApplicationServices()
    .Build();

var app = webApp;

app = UseMiddleware.Use(app);

Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Seq( "http://localhost:5341",apiKey:"v3LuQpVOGUKAXPuTPyUQ")
    .WriteTo.Console()
    .WriteTo.File("logs/log.txt")
    .CreateLogger();
app.Run();
