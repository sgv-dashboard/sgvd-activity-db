using SoapCore;
using Microsoft.EntityFrameworkCore;

using Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSingleton<IActivityService, ActivityService>();
builder.Services.AddDbContext<ActivityContext>(opt => opt.UseSqlite("Data Source=db/ActivityDb.db;"), ServiceLifetime.Singleton);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSoapEndpoint<IActivityService>("/Activities.asmx", new SoapEncoderOptions());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
