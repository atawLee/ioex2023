using MarketApp.Server.Database.Context;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();


var connection = builder.Configuration.GetConnectionString("Default");  
builder.Services.AddDbContext<CornMarketContext>(option =>  
{  
    option.UseMySql(connection, ServerVersion.AutoDetect(connection));  
});  
  
builder.Services.AddSwaggerGen(c =>  
{  
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CornMarket", Version = "v1" });  
});  
  
var app = builder.Build();  
app.UseSwagger();  
app.UseSwaggerUI(x =>  
{  
    x.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");  
  
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();