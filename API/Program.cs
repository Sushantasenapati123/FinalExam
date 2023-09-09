using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using FstMonthExam.IRepository.Factory;
using FstMonthExam.Repository.Factory;
using Exam.Irepository.ISport;
using Exam.Repository.PatientRepo;
using Exam.Web.DiContaner;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register your services
//builder.Services.AddScoped<SpotInterface, PatientRepositary>();
//builder.Services.AddScoped<IConnectionFactory, ConnectionFactory>();
builder.Services.AddControllersWithViews();
builder.Services.AddCustomContainer(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
