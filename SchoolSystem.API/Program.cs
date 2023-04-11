using Microsoft.EntityFrameworkCore;
using SchoolSystem.API.Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSingleton<IStudentsRepository,StudentsRepository>();

builder.Services.AddDbContext<SchoolDbContext>(options=> {
    options.UseSqlite("SchoolDB.db");
});


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
