using Microsoft.EntityFrameworkCore;
using Naruto_Universe.Data;
using Naruto_Universe.Service.Misc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContextPool<AppDbContext>(opt => 
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
    );

// Register dependencies
builder.Services.AddScoped<IDBInitializer, DBInitializer>();
builder.Services.AddScoped<IDBSaveService, DBSaveService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
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

app.UseHttpsRedirection();

app.Run();
