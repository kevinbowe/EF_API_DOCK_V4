using System.Transactions;
using Microsoft.AspNetCore.Mvc;

public class InsertPerson : IWebApi
{
	public void Register(WebApplication app)
	{
		app.MapPost("/InsertPerson", ([FromBody] Person person,
												[FromServices] IPersonRepository personRepository,
												[FromServices] LinkGenerator linkGenerator) =>
		{
			using (var scope = new TransactionScope())
			{
				//			These values were over-riding the values that were passed to API
				//			The person object now provides all the input data.

				//	person.InsertDte_sys = DateTime.Now;
				//	person.DOB_sys = DateOnly.FromDateTime(DateTime.Today);
				//	person.WorkStartsAt_sys = TimeOnly.FromDateTime(DateTime.Now);
				//	person.CurrentTime_sys = DateTime.Now;

				personRepository.InsertPerson(person);
				scope.Complete();
				return Results.Created($"/InsertPerson/{person}", person);
			}
		})
		.WithMetadata(new EndpointNameMetadata("InsertPerson"));
	}
}