using Microsoft.AspNetCore.Mvc;

public class GetPersons : IWebApi
{
	public void Register(WebApplication app)
	{
		app.MapGet("/GetPersons", ([FromServices] IPersonRepository personRepository) =>
		{
			var persons = personRepository.GetPersons();
			return Results.Ok(persons);
		})
		.WithMetadata(new EndpointNameMetadata("GetPersons"));
	}
}