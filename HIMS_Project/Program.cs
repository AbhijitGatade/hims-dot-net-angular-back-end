using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using HIMS_Project.Context;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});

builder.Services.AddDbContext<ProjectDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DBConStr")));
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
