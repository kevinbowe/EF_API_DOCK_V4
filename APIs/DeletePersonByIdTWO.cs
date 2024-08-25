using System.Transactions;
using Microsoft.AspNetCore.Mvc;

public class DeletePersonByIdTWO : IWebApi
{
	public void Register(WebApplication app)
	{
		app.MapDelete("/DeletePersonByIdTWO/{id}", (int Id, [FromServices] IPersonRepository personRepository) =>
		{
				using (var scope = new TransactionScope())
				{
					var person = personRepository.DeletePersonByIdTWO(Id);
					scope.Complete();
					return Results.Ok(person);
				}
		}).WithMetadata(new EndpointNameMetadata("DeletePersonByIdTWO"));
	}
}
