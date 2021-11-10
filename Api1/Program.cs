WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureService();

WebApplication app = builder.Build();
app.ConfigureMiddleware();
app.MapGreetEndPoints();

app.Run();