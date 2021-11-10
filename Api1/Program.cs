using Microsoft.AspNetCore.Mvc;

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
        return Results.Ok(greetService.GetGreetMessage(name));
    }
    catch (ArgumentNullException)
    {
        return Results.StatusCode(500);
    }
});

app.Run();