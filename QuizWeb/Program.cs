using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using QuizWeb.Data;
using QuizWeb.DatabaseServices;

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

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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