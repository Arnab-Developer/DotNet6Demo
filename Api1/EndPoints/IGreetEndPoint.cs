namespace Api1.EndPoints;

internal interface IGreetEndPoint
{
    public void Register(IEndpointRouteBuilder app);

    public IResult GetMessage(string name);
}