
using Application;
using Domain.Users;
using Infrastructure;
using Microsoft.OpenApi.Models;
using Persistence;
using Persistence.IdentityConfig;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigurePersistenceServices(builder.Configuration);
builder.Services.ConfigureInfrastructureServices(builder.Configuration);
builder.Services.ConfigureApplicationServices();
builder.Services.AddIdentityServices(builder.Configuration);
builder.Services.AddAuthorization();

builder.Services.ConfigureApplicationCookie(option =>
{
    option.ExpireTimeSpan = TimeSpan.FromMinutes(10);

    option.LoginPath = "/Account/login";
    option.AccessDeniedPath = "/Account/AccessDenied";
    option.SlidingExpiration = true;
});

//builder.Services.AddCors();

AddSwagger(builder.Services);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}

app.UseAuthentication();
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();
//app.MapIdentityApi<User>();
app.Run();
void AddSwagger(IServiceCollection services)
{
    services.AddSwaggerGen(o =>
    {
        o.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
        {
            Description = @"JWT Authorization header using the Bearer scheme. 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      Example: 'Bearer 1234sddsw'",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });

        o.AddSecurityRequirement(new OpenApiSecurityRequirement()
        {
            {
                new OpenApiSecurityScheme()
                {
                    Reference = new OpenApiReference()
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    },
                    Scheme = "oauth2",
                    Name = "Bearer",
                    In = ParameterLocation.Header
                },
                new List<string>()
            }
        });

        o.SwaggerDoc("v1", new OpenApiInfo()
        {
            Version = "v1",
            Title = "My API"
        });
    });
}