using SoapCore;
using Microsoft.EntityFrameworkCore;

using Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSingleton<IActivityService, ActivityService>();
builder.Services.AddDbContext<ActivityContext>(opt => opt.UseSqlite("Data Source=/db/ActivityDb.db;"), ServiceLifetime.Singleton);

var app = builder.Build();

// Configure app
app.UseSoapEndpoint<IActivityService>("/Activities.asmx", new SoapEncoderOptions());
app.UseHttpsRedirection();
app.UseAuthorization();

app.Run();
