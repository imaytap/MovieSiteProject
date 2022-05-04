using Autofac;
using Autofac.Extensions.DependencyInjection;
using DependencyResolvers.Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MovieSiteProject.Core.DependencyResolvers;
using MovieSiteProject.Core.Extensions;
using MovieSiteProject.Core.Utilities.IoC;
using MovieSiteProject.DependencyResolvers;
using MovieSiteProject.Extensions;
using MovieSiteProject.Repository.Concrete.EntityFramework;
using MovieSiteProject.Services.Hubs;

// Configure Services
var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new AutofacProjectModule());
});

builder.Logging.SetMinimumLevel(LogLevel.Trace);

builder.Services.AddDbContext<ProjectDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString(builder.Configuration.GetConnectionString("CurrentDB")));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
}, ServiceLifetime.Transient);

builder.Services.AddControllers();

builder.Services.AddCors();

builder.Services.AddJwtAuthentication(builder.Configuration);

builder.Services.AddDependencyResolvers(
    new CoreModule(),
    new ProjectModule()
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var securitySchema = new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };

    options.AddSecurityDefinition("Bearer", securitySchema);

    var securityRequirement = new OpenApiSecurityRequirement
    {
        {
            securitySchema, new[] {"Bearer"}
        }
    };

    options.AddSecurityRequirement(securityRequirement);
    options.OperationFilter<AddLanguageHeaderParameter>();
    options.OperationFilter<AddRefreshTokenHeaderParameter>();
    options.OperationFilter<AddClientIdHeaderParameter>();
    options.OperationFilter<AddClientNameHeaderParameter>();
    options.SwaggerDoc("v1", new OpenApiInfo() { Title = "WebAPI", Version = "v1", Description = "Swagger page for your API" });
});


// Configure
var app = builder.Build();

ServiceTool.ServiceProvider = app.Services;
app.UseCustomExceptionMiddleware();

app.Use(async (context, next) =>
{
    await next();
    if (context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value))
    {
        context.Request.Path = "/index.html";
        await next();
    }
});

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI");
    options.DocumentTitle = "WebAPI";
});

app.UseCors(builder => builder
    .WithOrigins(app.Configuration.GetSection("AllowedHosts").Get<string>()) 
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseTranslates();


app.UseAuthentication();
app.UseAuthorization();

app.UseRequestUser();

app.MapControllers();

app.UseStaticFiles();
app.UseDefaultFiles();

// app.MapHub<SystemHub>("/systemhub");
app.Run();
