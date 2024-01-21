using CondoTec.Management.API.Extensions;
using CondoTec.Management.IoC.Conf;
using CondoTec.Management.IoC.Extensions;
using CondoTec.Management.IoC.Middlewares;

var builder = WebApplication.CreateBuilder(args);

var enviroment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

builder.Configuration
    .AddJsonFile("appsettings.json", true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{enviroment}.json", true, reloadOnChange: true)
    .AddEnvironmentVariables();

var applicationSettings = builder.Configuration.GetSection("Settings").Get<Settings>();

builder.Services.AddSingleton<ISettings>(applicationSettings!);

builder.Logging
    .ClearProviders()
    .AddFilter("Microsoft", LogLevel.Warning)
    .AddFilter("Microsoft", LogLevel.Critical);

// Add services to the container.
builder.Services
    .AddMongo(applicationSettings?.MongoSettings)
    .AddAuth(applicationSettings?.TokenAuth)
    .AddLoggingDependency()
    .AddMediatR()
    .AddRepositories()
    .AddValidators()
    .AddControllers(options => options.Filters.Add(typeof(ValidationAttribute)))
    .AddNewtonsoftJson()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
        options.SuppressInferBindingSourcesForParameters = true;
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Condotec.Management.API"));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
