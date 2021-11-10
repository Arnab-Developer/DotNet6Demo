namespace Api1;

internal static class ServiceExtentions
{
    public static IServiceCollection ConfigureService(this IServiceCollection services) =>
        services
            .AddEndpointsApiExplorer()
            .AddSwaggerGen()
            .AddTransient(typeof(IGreetService), typeof(GreetService));
}