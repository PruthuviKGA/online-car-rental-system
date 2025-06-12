using Microsoft.EntityFrameworkCore;
using backend.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<CarRentalDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions => sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 5,
            maxRetryDelay: TimeSpan.FromSeconds(5),
            errorNumbersToAdd: null)
    ));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Database initialization with retry logic
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<CarRentalDbContext>();
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
    
    var retries = 0;
    const int maxRetries = 10;
    
    while (retries < maxRetries)
    {
        try
        {
            await context.Database.MigrateAsync();
            await DbSeeder.SeedAsync(context);
            logger.LogInformation("✅ Database setup completed successfully!");
            break;
        }
        catch (Exception ex)
        {
            retries++;
            logger.LogWarning($"⏳ Database setup attempt {retries}/{maxRetries} failed: {ex.Message}");
            
            if (retries >= maxRetries)
            {
                logger.LogError("❌ Max database setup retries reached. Application will exit.");
                throw;
            }
            await Task.Delay(5000);
        }
    }
}

app.Run();