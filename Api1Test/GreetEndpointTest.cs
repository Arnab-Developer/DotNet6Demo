using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Result;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Api1Test;

public class GreetEndpointTest
{
    private static HttpContext CreateMockHttpContext() =>
        new DefaultHttpContext
        {
            RequestServices = new ServiceCollection().AddLogging().BuildServiceProvider(),
            Response =
            {
                Body = new MemoryStream()
            },
        };

    [Fact]
    public async Task Can_GetMessage_ReturnProperMessage()
    {
        // Got the unit test idea from https://github.com/dotnet/aspnetcore/issues/37502

        IGreetService greetService = new GreetService();
        IResult result = GreetEndpointExtensions.GetMessage("Test User", greetService);
        HttpContext mockHttpContext = CreateMockHttpContext();
        await result.ExecuteAsync(mockHttpContext);
        mockHttpContext.Response.Body.Position = 0;
        using (StreamReader reader = new StreamReader(mockHttpContext.Response.Body, Encoding.UTF8))
        {
            Assert.Equal("\"Hello Test User\"", reader.ReadToEnd());
        }

        Assert.Equal(200, mockHttpContext.Response.StatusCode);
    }

    [Fact]
    public void Can_GetMessage_ThrowException()
    {

    }
}