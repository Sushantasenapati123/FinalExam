using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Exam.Irepository.ISport;
using Exam.Repository.PatientRepo;
//using Exam.Web.DiContaner;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
//builder.Services.AddCustomContainer(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
     //pattern: "{controller=Home}/{action=Index}/{id?}");
     pattern: "{controller=Final}/{action=EntryForm}/{id?}");
app.Run();
