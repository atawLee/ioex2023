using System.Text;
using MarketApp.Server.Database.Context;
using MarketApp.Server.Repository;
using MarketApp.Server.Repository.Interface;
using MarketApp.Server.Repository.Policy;
using MarketApp.Server.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IBuyerRepository, BuyerRepository>();
builder.Services.AddScoped<ISalesRepository, SalesRepository>();
builder.Services.AddScoped<IMarketRepository, MarketRepository>();

builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<BuyerService>();
builder.Services.AddScoped<MarketService>();
builder.Services.AddScoped<SalesService>();


var connection = builder.Configuration.GetConnectionString("Default");  
builder.Services.AddDbContext<CornMarketContext>(option =>  
{  
    option.UseMySql(connection, ServerVersion.AutoDetect(connection));  
});  
  
builder.Services.AddSwaggerGen(c =>  
{  
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CornMarket", Version = "v1" });  
});  

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"])),
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(Polices.User, Polices.UserPolicy());
    options.AddPolicy(Polices.Seller, Polices.SellerPolicy());
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

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();