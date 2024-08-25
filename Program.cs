using Microsoft.EntityFrameworkCore;

//			Program_UPDATE_WORKS.cs
//
//		WORKS -- COMPOSE -- Use --> PersonDb
//		WORKS -- Local with Db Container (below) -- Use --> PersonDbLocal
//		WORKS -- Local API w/ Compose Db (Compose API is not running) -- Use --> PersonDbLocal
//		WORKS -- Local + Debug -- Use --> PersonDbLocal
//		
//			USE THIS for Stand alone Database Container w/ Debug
// $		docker container run --name SqlDockerMac-exp-02 -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=L0ckandK#y' -e 'MSSQL_PID=Developer' -p 1433:1433 -d sql.docker.mac-persondb:latest

var BUILD_ENV = "COMPOSE";  /* COMPOSE | LOCAL */

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddWebApi(typeof(Program));

//		Add the DBcontext, using the connection string.
builder.Services.AddDbContext<PersonContext>(
	options =>
	{
		string? connectionString = string.Empty;
		// //		Use this for Local + Debug ||  "PersonDBLocal" : "Server=localhost,1433
		// if (BUILD_ENV == "LOCAL")
		// 	connectionString = builder.Configuration.GetConnectionString("PersonDbLocal");
		// else
		// //		Use this for Docker Compose ||  "PersonDB" : "Server=db,1433;
		// 	connectionString = builder.Configuration.GetConnectionString("PersonDb");

		if (BUILD_ENV == "COMPOSE")
			//		Use this for Docker Compose ||  "PersonDB" : "Server=db,1433;
			connectionString = builder.Configuration.GetConnectionString("PersonDb");
		else /* BUILD_ENV == LOCAL */ 
			//		Use this for Local + Debug ||  "PersonDBLocal" : "Server=localhost,1433
			connectionString = builder.Configuration.GetConnectionString("PersonDbLocal");

		options.UseSqlServer(connectionString);
	});

builder.Services.AddTransient<IPersonRepository, PersonRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

var summaries = new[]
{
	"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
	var forecast = Enumerable.Range(1, 5).Select(index =>
		new WeatherForecast
		(
			DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
			Random.Shared.Next(-20, 55),
			summaries[Random.Shared.Next(summaries.Length)]
		))
		.ToArray();
	return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.UseHttpsRedirection();
app.RegisterWebApisAsync();

// app.Run();
await app.RunAsync();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
	public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
