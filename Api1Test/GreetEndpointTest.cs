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
            // RequestServices needs to be set so the IResult implementation can log.
            RequestServices = new ServiceCollection().AddLogging().BuildServiceProvider(),
            Response =
            {
                // The default response body is Stream.Null which throws away anything that is written to it.
                Body = new MemoryStream(),
            },
        };

    [Fact]
    public async Task Can_GetMessage_ReturnProperMessage()
    {
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