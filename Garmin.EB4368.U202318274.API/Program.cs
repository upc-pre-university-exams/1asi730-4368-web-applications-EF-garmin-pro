using Cortex.Mediator.DependencyInjection;
using Garmin.EB4368.U202318274.API.Audit.Application.Internal.CommandServices;
using Garmin.EB4368.U202318274.API.Audit.Application.Internal.QueryServices;
using Garmin.EB4368.U202318274.API.Audit.Domain.Repositories;
using Garmin.EB4368.U202318274.API.Audit.Domain.Services;
using Garmin.EB4368.U202318274.API.Audit.Infrastructure.Persistence.EFC.Repositories;
using Garmin.EB4368.U202318274.API.Sales.Application.ACL;
using Garmin.EB4368.U202318274.API.Sales.Application.Internal.CommandServices;
using Garmin.EB4368.U202318274.API.Sales.Application.Internal.QueryServices;
using Garmin.EB4368.U202318274.API.Sales.Domain.Repositories;
using Garmin.EB4368.U202318274.API.Sales.Domain.Services;
using Garmin.EB4368.U202318274.API.Sales.Infrastructure.Persistence.EFC.Repositories;
using Garmin.EB4368.U202318274.API.Sales.Interfaces.ACL;
using Garmin.EB4368.U202318274.API.Shared.Domain.Exceptions;
using Garmin.EB4368.U202318274.API.Shared.Domain.Repositories;
using Garmin.EB4368.U202318274.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using Garmin.EB4368.U202318274.API.Shared.Infrastructure.Mediator.Cortex.Configuration;
using Garmin.EB4368.U202318274.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using Garmin.EB4368.U202318274.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add ASP.NET Core MVC with Kebab Case Route Naming Convention
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));
builder.Services.AddEndpointsApiExplorer();

// Add CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllPolicy",
        policy => policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// Add Configuration for Entity Framework Core
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (connectionString == null) throw new InvalidOperationException("Connection string not found.");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (builder.Environment.IsDevelopment())
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    else if (builder.Environment.IsProduction())
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Error);
});

// Add Swagger/OpenAPI support
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "eb4368u202318274.API",
        Version = "v1",
        Description = "eb4368u202318274 Platform API",
        TermsOfService = new Uri("https://eb4368u202318274.com/tos"),
        Contact = new OpenApiContact
        {
            Name = "u202318274 Studios",
            Email = "u202318274@upc.com"
        },
        License = new OpenApiLicense
        {
            Name = "Apache 2.0",
            Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
        },
    });
    options.EnableAnnotations();
});

// Dependency Injection

// Shared Bounded Context
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Bounded Context
builder.Services.AddScoped<IQuoteRequestRepository, QuoteRequestRepository>();
builder.Services.AddScoped<IQuoteRequestCommandService, QuoteRequestCommandService>();
builder.Services.AddScoped<IQuoteRequestQueryService, QuoteRequestQueryService>();

// ACL
builder.Services.AddScoped<ISalesContextFacade, SalesContextFacade>();

builder.Services.AddScoped<IQuoteRequestStateRepository, QuoteRequestStateRepository>();
builder.Services.AddScoped<IQuoteRequestStateCommandService, QuoteRequestStateCommandService>();
builder.Services.AddScoped<IQuoteRequestStateQueryService, QuoteRequestStateQueryService>();


// Add Mediator for CQRS
builder.Services.AddCortexMediator(
    configuration: builder.Configuration,
    handlerAssemblyMarkerTypes: new[] { typeof(Program) }, configure: options =>
    {
        options.AddOpenCommandPipelineBehavior(typeof(LoggingCommandBehavior<>));
//options.AddDefaultBehaviors();
    });

var app = builder.Build();

// Verify if the database exists and create it if it doesn't
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();

    context.Database.EnsureCreated();
}

// Use Swagger for API documentation if in development mode
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Apply CORS Policy
app.UseCors("AllowAllPolicy");

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();