using Microsoft.EntityFrameworkCore;
using TwitterClone.Api.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' was not found.");

builder.Services.AddDbContext<TwitterCloneDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddSingleton<UserRepository>();
builder.Services.AddSingleton<TweetRepository>();

var app = builder.Build();

PostgresDatabase.EnsureDatabaseExists(connectionString);

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<TwitterCloneDbContext>();
    db.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
