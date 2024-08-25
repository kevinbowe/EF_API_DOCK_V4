using System.Transactions;
using Microsoft.AspNetCore.Mvc;

public class DeletePersonById : IWebApi
{
	public void Register(WebApplication app)
	{
		app.MapDelete("/DeletePersonById/{id}", (int Id, [FromServices] IPersonRepository personRepository) =>
		{
			using (var scope = new TransactionScope())
			{
				personRepository.DeletePersonById(Id);
				scope.Complete();
				return Results.Ok();
			}
		}).WithMetadata(new EndpointNameMetadata("DeletePersonById"));
	}
}