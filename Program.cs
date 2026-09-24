using Microsoft.EntityFrameworkCore;
using Naruto_Universe.Data;
using Naruto_Universe.Exceptions;
using Naruto_Universe.Repository;
using Naruto_Universe.Service;
using Naruto_Universe.Service.Misc;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();

builder.Services.AddDbContextPool<AppDbContext>(opt => 
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
    );

// Register dependencies
builder.Services.AddScoped<IDBInitializer, DBInitializer>();
builder.Services.AddScoped<IDBSaveService, DBSaveService>();
builder.Services.AddScoped<ICharacterRepository, CharacterRepository>();
builder.Services.AddScoped<ICharacterService, CharacterService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

await SeedDatabase();

async Task SeedDatabase()
{
    using (var scope = app.Services.CreateScope())
    {
        var dbInitializer = scope.ServiceProvider.GetRequiredService<IDBInitializer>();
        await dbInitializer.InitializeDbAsync();
    }

}

app.UseExceptionHandler();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
