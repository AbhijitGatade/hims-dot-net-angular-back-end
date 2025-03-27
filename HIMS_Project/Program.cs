using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using HIMS_Project.Context;
using HIMS_Project.Services;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});

builder.Services.AddDbContext<ProjectDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DBConStr")));
builder.Services.AddScoped< IPatientService, PatientService >();

var app = builder.Build();


app.UseStaticFiles();
app.UseRouting();
if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();
app.UseCors(o=>o.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.Run();
