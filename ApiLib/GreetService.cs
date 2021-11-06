namespace Api1Lib;

public class GreetService : IGreetService
{
    string IGreetService.GetGreetMessage(string name) => $"Hello {name}";
}