WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.ConfigureService();

WebApplication app = builder.Build();
app.ConfigureMiddleware();

app.Run();