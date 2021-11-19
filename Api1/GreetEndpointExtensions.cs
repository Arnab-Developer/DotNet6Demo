namespace Api1;

internal static class GreetEndpointExtensions
{
    public static void MapGreetEndPoints(this IEndpointRouteBuilder app)
    {
        IGreetEndPoint greetEndPoint = app.ServiceProvider.GetRequiredService<IGreetEndPoint>();
        greetEndPoint.Register(app);
    }
}