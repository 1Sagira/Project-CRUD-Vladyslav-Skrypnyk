using Microsoft.EntityFrameworkCore;
using ZadanieApp.Api.Data;
using System.Net;

var builder = WebApplication.CreateBuilder(args);


const string MyAllowSpecificOrigins = "AllowMyFrontend";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                         
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


if (!builder.Environment.IsDevelopment())
{
    builder.WebHost.ConfigureKestrel(serverOptions =>
    {
        var portEnv = Environment.GetEnvironmentVariable("PORT");
        if (int.TryParse(portEnv, out int port))
        {
            
            serverOptions.Listen(IPAddress.Any, port);
        }
    });
}




var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    
    dbContext.Database.Migrate(); 
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDefaultFiles();
app.UseStaticFiles();


app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();


