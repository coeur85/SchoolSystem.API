using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.API.Domain.Queries.Students;
using SchoolSystem.API.Domain.Repositories;
using SchoolSystem.API.Mapper;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddJsonOptions(options => {
    options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<SchoolDbContext>(options =>
{
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

//builder.Services.AddFluentValidationAutoValidation(); auto validate 
//builder.Services.AddScoped<IValidator<GetOneStudentQuery>, GetOneStudentQueryValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<GetOneStudentQueryValidator>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(x => { x.DocExpansion(DocExpansion.None); });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
