using BI.Core;
using Collaborator.Repositories.Personal;
using Collaborator.Repositories.Personal.Contracts;
using Collaborator.Services.Personal;
using Collaborator.Services.Personal.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<DbSession>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Collaborator

//Personal
builder.Services.AddScoped<IGetAllByActiveRepository, GetAllByActiveRepository>();
builder.Services.AddScoped<IGetAllByActiveService, GetAllByActiveService>();

var app = builder.Build();

// IConfiguration Configuration = app.Configuration;

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