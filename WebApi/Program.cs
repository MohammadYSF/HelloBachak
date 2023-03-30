using Entity.Context;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using DataAccess;
using Business.Auth;

var builder = WebApplication.CreateBuilder(args);


var configSection = builder.Configuration.GetSection(nameof(JwtSettings));
var settings = new JwtSettings();

configSection.Bind(settings);

builder.Services.AddSingleton<IConfiguration>(provider => builder.Configuration);
builder.Services.AddTransient<ITokenService, TokenService>();
builder.Services.AddOptions();
builder.Services.Configure<JwtSettings>(configSection);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("HelloBachakDbConnectionString") 
?? throw new InvalidOperationException("Connection String \" HelloBachackDbConnectionString \" not found");

builder.Services.AddDbContext<HelloBachakContext>(opt=>opt.UseNpgsql(connectionString));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthentication();    
app.UseAuthorization();
// app.MapControllerRoute(
//     name:"default",
//     pattern:"{controller=Home}/{action=Index}/{id?}"
// );
app.MapControllers();

app.Run();
