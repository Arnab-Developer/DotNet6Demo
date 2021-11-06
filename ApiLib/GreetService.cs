namespace Api1Lib;

public class GreetService : IGreetService
{
    string IGreetService.GetGreetMessage(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException(nameof(name));
        }
        return $"Hello {name}";
    }
}