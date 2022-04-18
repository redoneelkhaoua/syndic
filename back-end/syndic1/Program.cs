using Microsoft.EntityFrameworkCore;
using Syndic.DependencyInjection;
using Syndic.Persistence.EntityFramework;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
var connectionstring = builder.Configuration.GetConnectionString("SyndicDatabase");
builder.Services.AddDbContext<SyndicContext>(o =>
{
    o.UseNpgsql(connectionstring);
});

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));
builder.Services.AddSyndic();
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

app.UseAuthorization();
app.UseCors("corsapp");
app.MapControllers();

app.Run();
