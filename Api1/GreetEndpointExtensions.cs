namespace Api1;

internal static class GreetEndpointExtensions
{
    public static void MapGreetEndPoints(this WebApplication app) =>
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
        })
        .WithName("Greet")
        .Produces<string>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status500InternalServerError);
}