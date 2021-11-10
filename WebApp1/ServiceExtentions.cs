namespace WebApp1;

internal static class ServiceExtentions
{
    public static WebApplicationBuilder ConfigureService(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllersWithViews();
        builder.Services.AddHttpClient().Configure<Api1Settings>(builder.Configuration);
        return builder;
    }
}