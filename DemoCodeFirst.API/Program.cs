using DemoCodeFirst.Business.Services.CitySvc;
using DemoCodeFirst.Business.Services.CountrySvc;
using DemoCodeFirst.Business.Services.StateSvc;
using DemoCodeFirst.Data.EF;
using DemoCodeFirst.Data.Repository.CityRepo;
using DemoCodeFirst.Data.Repository.CountryRepo;
using DemoCodeFirst.Data.Repository.GenericRepo;
using DemoCodeFirst.Data.Repository.StateRepo;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// ConnectDB
builder.Services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DemoCodeFirst")));

// Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
    c.SwaggerDoc("v1", new() { Title = "DemoCodeFirst", Version = "v1", Description = "APIs for DemoCodeFirst" });
    var securityScheme = new OpenApiSecurityScheme()
    {
        Description = "JWT Authorization header using the Bearer scheme. " +
                        "\n\nEnter 'Bearer' [space] and then your token in the text input below. " +
                            "\n\nExample: 'Bearer 12345abcde'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        Reference = new OpenApiReference()
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };
    c.AddSecurityDefinition("Bearer", securityScheme);
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            securityScheme,
            new string[]{ }
        }
    });
});

// Add DI (Dependency Injection)
// Services
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<IStateService, StateService>();

// Repositories
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient<ICityRepo, CityRepo>();
builder.Services.AddTransient<ICountryRepo, CountryRepo>();
builder.Services.AddTransient<IStateRepo, StateRepo>();

// Firebase


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "DemoCodeFirst.API v1");
    c.RoutePrefix = string.Empty;

});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
