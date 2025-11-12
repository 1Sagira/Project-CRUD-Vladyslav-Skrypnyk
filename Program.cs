using Microsoft.EntityFrameworkCore;
using ZadanieApp.Api.Data;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Define CORS policy
const string MyAllowSpecificOrigins = "AllowMyFrontend";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          // Allowing the specific frontend origin
                          policy.WithOrigins("https://project-crud-vladyslav-skrypnyk2.onrender.com")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});

// Add DbContext with SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Controllers and Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Run database migrations on startup
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    // Ensure the database is created and migrations are applied
    dbContext.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Custom configuration for production environment (Render)
if (!builder.Environment.IsDevelopment())
{
    // Configure Kestrel to listen on the PORT environment variable (standard for Render/Heroku)
    app.Urls.Add($"http://*:{Environment.GetEnvironmentVariable("PORT")}");
}

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseRouting(); // Must be before UseCors and UseAuthorization

// Apply CORS policy
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();

