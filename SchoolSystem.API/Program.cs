using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SchoolSystem.API.Domain.Repositories;
using SchoolSystem.API.Mapper;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<SchoolDbContext>(options=> {
    options.UseInMemoryDatabase("SchoolDB.db");
});


builder.Services.AddScoped<IStudentsRepository, StudentsRepository>();

builder.Services.AddMediatR(
    confing => confing.RegisterServicesFromAssemblies(
    Assembly.GetExecutingAssembly()));

var AutoMapConfig = new AutoMapper.MapperConfiguration(config =>
{
    config.AddProfile(new StudentMappingProfile());
});
var mapper = AutoMapConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
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
