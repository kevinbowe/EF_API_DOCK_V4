public static class WebApiSetup
{
	public static void AddWebApi(this IServiceCollection services, Type markerType)
	{
		services.RegisterImplementationsOf<IWebApi>(markerType);
		services.RegisterImplementationsOf<IWebApiAsync>(markerType);
	}

	public static void RegisterWebApisAsync(this WebApplication app)
	{

		//		The APIs registered below all share the same service SCOPE.
		//		There will be 4x APIs with the same SCOPE.
		//				GetPersonById -- GerPersons -- InsertPersons -- UpdatePerson
		using (var scope = app.Services.CreateScope())
		{
			var scopedProvider = scope.ServiceProvider;

			//		This will return all of the APIs that have the type IWebApi.
			//		This can be found in each API class definition, like this;
			//			public class GetPersonByID : IWebApi
			//		IWebApi defines this:  void Register(WebApplication app);
			var webApis = scopedProvider.GetServices<IWebApi>();
			foreach (var webApi in webApis)
			{
				webApi.Register(app);
			}

			//		This will return all of the IWebApiAsync APIs like above.
			//		In this case there are NO async APIs defined.
			//		The Task.WhenAll(~) creates a task that will complete when all
			//			of the supplied tasks have completed.

			//... var asyncWebApis = scopedProvider.GetServices<IWebApiAsync>();
			//... await Task.WhenAll(asyncWebApis.Select(x => x.RegisterAsync(app)));
		}
	}
}