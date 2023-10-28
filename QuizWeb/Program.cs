using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using QuizWeb.Data;
using QuizWeb.DatabaseServices;
using Microsoft.Extensions.Logging;
using Microsoft.CodeAnalysis.Options;
using Microsoft.AspNetCore.Identity;
using QuizWeb.Models;
using System.Security.Principal;
using QuizWeb.IdentityServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMvc();

var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//add database
builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseSqlite(ConnectionString);
});
builder.Services.AddScoped<IDatabaseServices, DatabaseServices>();
builder.Services.AddScoped<IIdentityServices, IdentityServices>();

builder.Services.AddIdentity<User, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<DatabaseContext>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//add role in database
SetRoleOnDatabase.CreateRoleOnDatabase(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.UseDefaultFiles();

app.MapControllers();

app.Run();