using FitnessTracker.Data;
using FitnessTracker.Data.Repos;
using FitnessTracker.Interfaces;
using FitnessTracker.Services;
using FitnessTracker.Settings;
using MailLibrary;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Starting Up");

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog((hostbuilderContext,loggerConfig)=>
    loggerConfig.WriteTo.Console()
    .ReadFrom.Configuration(hostbuilderContext.Configuration));

    // Add services to the container.
    builder.Services.AddScoped<IUnitOfWork, UnitOfWorkRepository>();
    builder.Services.AddTransient<IExerciseService, ExerciseService>();
    builder.Services.AddTransient<IUserWorkoutService, UserWorkoutService>();
    builder.Services.AddTransient<IMailService, MailService>();
    builder.Services.AddTransient<IChangePasswordService, ChangePasswordService>();


    // Adds AutoMapper to DI container
    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    // adds mailsetting based upon appsettingsection Mailsettings
    builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));

    builder.Services.AddDbContext<DataContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DBAzureConnection"));
    });

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(options =>
    {
        options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
        {
            Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
            In = ParameterLocation.Header,
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey
        });

        options.OperationFilter<SecurityRequirementsOperationFilter>(); //matt frier

    options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "Api",
            Description = "Api"
        });
    });

    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                //ClockSkew = TimeSpan.Zero,
            };
        });


    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {

    }

    if (app.Environment.IsProduction())
    {

    }
    app.UseCors(options =>
    {
        options.WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1");
    });


    //By default, the ASP.NET Core framework logs multiple information-level events per request.
    //Serilog's request logging streamlines this, into a single message per request, including path, method, timings, status code, and exception.
    app.UseSerilogRequestLogging();

    app.UseHttpsRedirection();

    // has to be executed before app.UseAuthorization()
    app.UseAuthentication();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch(Exception ex)
{
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Information("Shutdown complete");
    Log.CloseAndFlush();
}
