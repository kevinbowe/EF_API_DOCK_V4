using Microsoft.AspNetCore.Mvc;

public class GetPersonByID : IWebApi
{
	public void Register(WebApplication app)
	{
		app.MapGet("/GetPersonByID/{id}", (int id, [FromServices] IPersonRepository personRepository) =>
		{
			var person = personRepository.GetPersonByID(id);
			return Results.Ok(person);
		})
		.WithMetadata(new EndpointNameMetadata("GetPersonByID"));
	}
}