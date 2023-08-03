using JohnyStoreApi.Logging;
using JohnyStoreApi.Logging.Interfaces;
using JohnyStoreApi.Services;
using JohnyStoreApi.Services.Interfaces;
using JohnyStoreData.EF;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string connection = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new Exception("������ ����������� �� �������");
builder.Services.AddDbContext<JohnyStoreContext>(options => options.UseSqlServer(connection));
builder.Services.AddScoped<IJohnyStoreLogger, JohnyStoreLogger>();
builder.Services.AddScoped<IFileManager, FileManager>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
