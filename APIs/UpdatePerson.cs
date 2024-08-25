using System.Transactions;
using Microsoft.AspNetCore.Mvc;

public class UpdatePerson : IWebApi
{
	public void Register(WebApplication app)
	{
		app.MapPut("/UpdatePerson", ([FromBody] Person person, [FromServices] IPersonRepository personRepository) =>
		{
			if (person != null)
			{
				using (var scope = new TransactionScope())
				{
					//			These values were over-riding the values that were passed to API
					//			The person object now provides all the input data.

					//	person.InsertDte_sys = DateTime.Now;
					//	person.DOB_sys = DateOnly.FromDateTime(DateTime.Today);
					//	person.WorkStartsAt_sys = TimeOnly.FromDateTime(DateTime.Now);
					//	person.CurrentTime_sys = DateTime.Now;

					personRepository.UpdatePerson(person);
					scope.Complete();
					return Results.Ok();
				}
			}
			return Results.NoContent();
		})
		.WithMetadata(new EndpointNameMetadata("UpdatePerson"));
	}
}