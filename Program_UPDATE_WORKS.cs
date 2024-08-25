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
// //		Add the DBcontext, using the connection string.
// builder.Services.AddDbContext<PersonContext>(
// 	options =>
// 	{
// 		var connectionString = builder.Configuration.GetConnectionString("PersonDb");
// 		options.UseSqlServer(connectionString);
// 	});
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
// /*Add*/ 
// app.UseHttpsRedirection();
// /*ADD*/ 
// app.RegisterWebApisAsync();
// 
// 
// // app.Run();
// /*ADD*/ 
// await app.RunAsync();
// 
// record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// {
// 	public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// }
