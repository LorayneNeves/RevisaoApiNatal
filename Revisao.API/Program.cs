using Microsoft.Extensions.Options;
using Revisao.Application.AutoMapper;
using Revisao.Application.Interfaces;
using Revisao.Application.Services;
using Revisao.Data.AutoMapper;
using Revisao.Data.Providers.MongoDb.Configuration;
using Revisao.Data.Providers.MongoDb.Interfaces;
using Revisao.Data.Providers.MongoDb;
using Revisao.Data.Repositories;
using Revisao.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDbSettings"));

builder.Services.AddSingleton<IMongoDbSettings>(serviceProvider =>
       serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);

builder.Services.AddAutoMapper(typeof(DomainToApplication), typeof(ApplicationToDomain));
builder.Services.AddAutoMapper(typeof(DomainToCollection), typeof(CollectionToDomain));

builder.Services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));

builder.Services.AddScoped<ICartaRepository, CartaRepository>();
builder.Services.AddScoped<ICartaService, CartaService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
