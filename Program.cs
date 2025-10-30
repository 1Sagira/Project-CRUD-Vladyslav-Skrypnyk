using Microsoft.EntityFrameworkCore;
using ZadanieApp.Api.Data;

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

Console.Write("http://localhost:5000");

app.UseDefaultFiles();
app.UseStaticFiles();


app.UseCors(MyAllowSpecificOrigins);
