namespace Api1.EndPoints;

internal class GreetEndPoint : IGreetEndPoint
{
    private readonly IGreetService _greetService;

    public GreetEndPoint(IGreetService greetService)
    {
        ArgumentNullException.ThrowIfNull(nameof(greetService));
        _greetService = greetService;
    }

    public void Register(IEndpointRouteBuilder app) =>
        app.MapGet("greet", GetMessage)
            .WithName("Greet")
            .Produces<string>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status500InternalServerError);

    public IResult GetMessage(string name)
    {
        try
        {
            return Results.Ok(_greetService.GetGreetMessage(name));
        }
        catch (ArgumentNullException)
        {
            return Results.StatusCode(500);
        }
    }
}