namespace Api1;

internal static class GreetEndpointExtensions
{
    public static void MapGreetEndPoints(this IEndpointRouteBuilder app) =>
        app.MapGet("greet", GetMessage)
            .WithName("Greet")
            .Produces<string>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status500InternalServerError);

    public static IResult GetMessage(string name, IGreetService greetService)
    {
        try
        {
            return Results.Ok(greetService.GetGreetMessage(name));
        }
        catch (ArgumentNullException)
        {
            return Results.StatusCode(500);
        }
    }
}