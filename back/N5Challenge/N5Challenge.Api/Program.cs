using Microsoft.EntityFrameworkCore;
using N5Challenge.DataAccess;
using N5Challenge.DataAccess.Interfaces;
using N5Challenge.DataAccess.Repositories;
using N5Challenge.Services.Elasticsearch;
using N5Challenge.Services.Interfaces;
using N5Challenge.Services.Kafka;
using N5Challenge.Services.Services;
using N5Challenge.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var corsKey = "N5ChallengeCors";
var connectionString = Environment.GetEnvironmentVariable("DB_CNN_STRING");
builder.Services.AddDbContext<SqlDbContext>(opt => opt.UseSqlServer(connectionString, m => m.MigrationsAssembly("N5Challenge.DataAccess")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(corsKey,
                      policy =>
                      {
                          policy.AllowAnyOrigin()
                                .AllowAnyMethod()
                                .AllowAnyHeader();
                      });
});

builder.Services
    .InjectDependencies()
    .AddTransient<IUnitOfWork, UnitOfWork>()
    .AddTransient<IPermissionRepository, PermissionRepository>()
    .AddTransient<IPermissionTypeRepository, PermissionTypeRepository>()
    .AddTransient<IPermissionService, PermissionService>()
    .AddTransient<IPermissionTypeService, PermissionTypeService>()
    .AddMediatR(x => x.RegisterServicesFromAssemblyContaining(typeof(Program)))
    .AddSingleton<IKafkaProducer, KafkaProducer>()
    .AddSingleton<IElasticsearchService, ElasticsearchService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(corsKey);

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }