using JohnyStoreApi.Logging;
using JohnyStoreApi.Logging.Interfaces;
using JohnyStoreApi.Services;
using JohnyStoreApi.Services.Data;
using JohnyStoreApi.Services.DataServices;
using JohnyStoreApi.Services.Interfaces;
using JohnyStoreApi.Services.Interfaces.DataInterfaces;
using JohnyStoreData.EF;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string connection = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new Exception("Строка подключения не найдена");
builder.Services.AddDbContext<JohnyStoreContext>(options => options.UseLazyLoadingProxies().UseSqlServer(connection));

builder.Services.AddScoped<IJohnyStoreLogger, JohnyStoreLogger>();
builder.Services.AddScoped<IFileManager, FileManager>();
builder.Services.AddScoped<ISneakerDataService, SneakerDataSevice>();
builder.Services.AddScoped<IPictureDataService, PictureSneakerDataService>();
builder.Services.AddScoped<IOrderDataService, OrderDataService>();
builder.Services.AddScoped<IBrandDataService, BrandDataService>();
builder.Services.AddScoped<IAvailabilityDataService, AvailabilityDataService>();
builder.Services.AddScoped<IOrderStatusDataService,OrderDataService>();

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
