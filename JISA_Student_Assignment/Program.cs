



using JISA_Student_Assignment.Entities;
using JISA_Student_Assignment.Repository;
using JISA_Student_Assignment.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings:defaultConnection").Value));
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "JISA_Student_Assignment", Version = "v1" });
});
//builder.Services.AddScoped<ApplicationDbContext, ApplicationDbContext>();
builder.Services.AddScoped<IStudentRepository,StudentRepository>();
builder.Services.AddScoped<IStudentService,StudentService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "JISA_Student_Assignment v1"));

app.Run();
