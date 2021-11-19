namespace Api1.EndPoints;

internal static class GreetEndpointExtensions
{
    public static void MapGreetEndPoints(this IEndpointRouteBuilder app)
    {
        IGreetEndPoint greetEndPoint = app.ServiceProvider.GetRequiredService<IGreetEndPoint>();
        greetEndPoint.Register(app);
    }
}