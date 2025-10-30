using Microsoft.EntityFrameworkCore;
using ZadanieApp.Api.Data;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// 1. Налаштування CORS
const string MyAllowSpecificOrigins = "AllowMyFrontend";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          // ВАЖЛИВО: Переконайтеся, що тут правильний URL вашого фронтенду
                          policy.WithOrigins("https://project-crud-vladyslav-skrypnyk2.onrender.com") 
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// *** ПОКРАЩЕНА ЛОГІКА ПОРТУ ***
// Цей блок коду буде виконуватися ТІЛЬКИ на сервері (не локально)
if (!builder.Environment.IsDevelopment())
{
    builder.WebHost.ConfigureKestrel(serverOptions =>
    {
        var portEnv = Environment.GetEnvironmentVariable("PORT");
        if (int.TryParse(portEnv, out int port))
        {
            // Слухаємо на 0.0.0.0 (всі IP) та порту, який дав Onrender
            serverOptions.Listen(IPAddress.Any, port);
        }
    });
}
// Локально (IsDevelopment()) він автоматично використає 'launchSettings.json'
// *** КІНЕЦЬ ЗМІН ***


var app = builder.Build();

// Застосовуємо міграції бази даних при запуску
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    // Цей рядок все ще може викликати збій, якщо ви не використовуєте "Диск"
    dbContext.Database.Migrate(); 
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDefaultFiles();
app.UseStaticFiles();

// 2. Активуємо CORS
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();


