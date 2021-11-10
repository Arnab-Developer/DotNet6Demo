using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace WebApp1.Controllers;

public class HomeController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IOptionsMonitor<Api1Settings> _api1SettingsOptionsAccessor;

    public HomeController(IHttpClientFactory httpClientFactory,
        IOptionsMonitor<Api1Settings> api1SettingsOptionsAccessor)
    {
        ArgumentNullException.ThrowIfNull(httpClientFactory);
        ArgumentNullException.ThrowIfNull(api1SettingsOptionsAccessor);

        _httpClientFactory = httpClientFactory;
        _api1SettingsOptionsAccessor = api1SettingsOptionsAccessor;
    }

    public async Task<IActionResult> Index(string name)
    {
        using HttpClient httpClient = _httpClientFactory.CreateClient();
        string getUrl = $"{_api1SettingsOptionsAccessor.CurrentValue.Api1Url}?name={name}";
        HttpResponseMessage response = await httpClient.GetAsync(getUrl);
        if (response.IsSuccessStatusCode)
        {
            string message = await response.Content.ReadAsStringAsync();
            ViewData["Message"] = message;
        }
        else
        {
            ViewData["Message"] = "Error";
        }
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}