using Microsoft.EntityFrameworkCore;
using TaskManager.Infrastructure.Data;
using TaskManager.Infrastructure.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructureData(builder.Configuration, "DefaultConnection");
builder.Services.AddInfrastructureHttp();

var app = builder.Build();

//if (builder.Environment.IsDevelopment() || builder.Environment.IsEnvironment("Internal"))
//{
//    using var scope = app.Services.CreateScope();
//    await using var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
//    await dbContext.Database.MigrateAsync();
//}

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
