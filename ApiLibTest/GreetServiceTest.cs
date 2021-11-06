namespace ApiLibTest;

public class GreetServiceTest
{
    [Fact]
    public void Can_GetGreetMessage_ReturnProperMessage()
    {
        IGreetService greetService = new GreetService();
        string msg = greetService.GetGreetMessage("Jon");
        Assert.Equal("Hello Jon", msg);
    }

    [Fact]
    public void Can_GetGreetMessage_ThrowExceptionWithNull()
    {
        IGreetService greetService = new GreetService();
#pragma warning disable CS8625
        ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => greetService.GetGreetMessage(null));
#pragma warning restore CS8625
        Assert.Equal("Value cannot be null. (Parameter 'name')", ex.Message);
    }

    [Fact]
    public void Can_GetGreetMessage_ThrowExceptionWithEmptyString()
    {
        IGreetService greetService = new GreetService();
        ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => greetService.GetGreetMessage(string.Empty));
        Assert.Equal("Value cannot be null. (Parameter 'name')", ex.Message);
    }

    [Fact]
    public void Can_GetGreetMessage_ThrowExceptionWithBlankString()
    {
        IGreetService greetService = new GreetService();
        ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => greetService.GetGreetMessage(""));
        Assert.Equal("Value cannot be null. (Parameter 'name')", ex.Message);
    }

    [Fact]
    public void Can_GetGreetMessage_ThrowExceptionWithWhiteSpace()
    {
        IGreetService greetService = new GreetService();
        ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => greetService.GetGreetMessage(" "));
        Assert.Equal("Value cannot be null. (Parameter 'name')", ex.Message);
    }
}