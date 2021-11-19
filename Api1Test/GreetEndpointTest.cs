// Got the unit test idea from https://github.com/dotnet/aspnetcore/issues/37502

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Moq;
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
        Mock<IGreetService> greetServiceMock = new();
        greetServiceMock.Setup(s => s.GetGreetMessage(It.IsAny<string>())).Returns("Hello Test User");

        IGreetEndPoint greetEndPoint = new GreetEndPoint(greetServiceMock.Object);
        IResult result = greetEndPoint.GetMessage("Test User");
        HttpContext mockHttpContext = CreateMockHttpContext();
        await result.ExecuteAsync(mockHttpContext);
        mockHttpContext.Response.Body.Position = 0;
        using StreamReader reader = new(mockHttpContext.Response.Body, Encoding.UTF8);

        Assert.Equal("\"Hello Test User\"", reader.ReadToEnd());
        Assert.Equal(200, mockHttpContext.Response.StatusCode);
    }

    [Fact]
    public async Task Can_GetMessage_ThrowException()
    {
        Mock<IGreetService> greetServiceMock = new();
        greetServiceMock.Setup(s => s.GetGreetMessage(string.Empty)).Throws<ArgumentNullException>();

        IGreetEndPoint greetEndPoint = new GreetEndPoint(greetServiceMock.Object);
        IResult result = greetEndPoint.GetMessage(string.Empty);
        HttpContext mockHttpContext = CreateMockHttpContext();
        await result.ExecuteAsync(mockHttpContext);
        mockHttpContext.Response.Body.Position = 0;
        using StreamReader reader = new(mockHttpContext.Response.Body, Encoding.UTF8);

        Assert.Equal(500, mockHttpContext.Response.StatusCode);
    }
}