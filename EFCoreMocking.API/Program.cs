using EFCoreMocking.API.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connString = "Filename=:memory:";
var conn = new SqliteConnection(connString);
conn.Open();
builder.Services.AddDbContext<EmployeeDBContext>(opt => opt.UseSqlite(conn));
//builder.Services.AddDbContext<EmployeeDBContext>(options =>
//    options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnectionString") ?? throw new InvalidOperationException("Connection string 'EmployeeDBContext' not found.")));


// Add services to the container.

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

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<EmployeeDBContext>();
    context.Database.EnsureCreated();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

