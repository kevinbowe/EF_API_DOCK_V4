using System.Transactions;
using Microsoft.AspNetCore.Mvc;

public class DeletePerson : IWebApi
{
	public void Register(WebApplication app)
	{
		app.MapPut("/DeletePerson", ([FromBody] Person person, [FromServices] IPersonRepository personRepository) =>
		{
			if (person != null)
			{
				using (var scope = new TransactionScope())
				{
					person.InsertDte_sys = DateTime.Now;
					person.DOB_sys = DateOnly.FromDateTime(DateTime.Today);
					person.WorkStartsAt_sys = TimeOnly.FromDateTime(DateTime.Now);
					person.CurrentTime_sys = DateTime.Now;

					personRepository.DeletePerson(person);
					scope.Complete();
					return Results.Ok();
				  }
			}
			return Results.NoContent();
		})
		.WithMetadata(new EndpointNameMetadata("DeletePerson"));
	}
}