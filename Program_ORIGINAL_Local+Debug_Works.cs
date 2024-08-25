// //		Program_ORIGINAL_Local+Debug_Works.cs
// ////		FAILS - COMPOSE
// ///		WORKS -- Local + Debug
// ///		
// //			USE THIS for Stand alone Database Container w/ Debug
// // $		docker container run --name SqlDockerMac-exp-02 -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=L0ckandK#y' -e 'MSSQL_PID=Developer' -p 1433:1433 -d sql.docker.mac-persondb:latest
// 
// 
// using Microsoft.EntityFrameworkCore;
// 
// var builder = WebApplication.CreateBuilder(args);
// 
// // Add services to the container.
// // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
// 
// builder.Services.AddWebApi(typeof(Program));
// 
// //		This is all about the configuration.
// //		Note the 'appSettings.json' which contains the 
// //		ConnectionStrings for the database.
// var configBuilder = new ConfigurationBuilder()
// 	.SetBasePath(Directory.GetCurrentDirectory())
// 	.AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);
// 
// IConfiguration config = configBuilder.Build();
// //		DEBUG + LOCAL CONNECTION STRING
// // var connectionString = config?["ConnectionStrings:PersonDbLocal"];
// //		COMPOSE CONNECTION STRING -- FAILS
// var connectionString = config?["ConnectionStrings:PersonDb"];
// 
// 
// //		Fetch the Connection string <-- Value named "PersonDB" <-- Key
// // var connectionString = config.GetConnectionString("PersonDB");
// 
// //		Add the DBcontext, using the connection string.
// builder.Services.AddDbContext<PersonContext>(options =>
// {
// 	options.UseSqlServer(connectionString);
// });
// 
// builder.Services.AddTransient<IPersonRepository, PersonRepository>();
// 
// var app = builder.Build();
// 
// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
// 	app.UseSwagger();
// 	app.UseSwaggerUI();
// }
// 
// var summaries = new[]
// {
// 	"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
// };
// 
// app.MapGet("/weatherforecast", () =>
// {
// 	var forecast = Enumerable.Range(1, 5).Select(index =>
// 		new WeatherForecast
// 		(
// 			DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
// 			Random.Shared.Next(-20, 55),
// 			summaries[Random.Shared.Next(summaries.Length)]
// 		))
// 		.ToArray();
// 	return forecast;
// })
// .WithName("GetWeatherForecast")
// .WithOpenApi();
// 
// app.UseHttpsRedirection();
// app.RegisterWebApisAsync();
// 
// 
// await app.RunAsync();
// 
// record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// {
// 	public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// }
