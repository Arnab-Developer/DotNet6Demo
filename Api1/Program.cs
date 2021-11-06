WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient(typeof(IGreetService), typeof(GreetService));

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("greet", (string name, IGreetService greetService) =>
{
    try
    {
        return greetService.GetGreetMessage(name);
    }
    catch (ArgumentNullException)
    {
        return "Name can't be blank";
    }
});

app.Run();