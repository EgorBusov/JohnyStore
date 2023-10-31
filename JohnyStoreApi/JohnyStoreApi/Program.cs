using JohnyStoreApi.Logging;
using JohnyStoreApi.Logging.Interfaces;
using JohnyStoreApi.Services.AdditionalServices;
using JohnyStoreApi.Services.Data;
using JohnyStoreApi.Services.DataServices;
using JohnyStoreApi.Services.Interfaces;
using JohnyStoreApi.Services.Interfaces.DataInterfaces;
using JohnyStoreData.EF;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string connection = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new Exception("Строка подключения не найдена");
builder.Services.AddDbContext<JohnyStoreContext>(options => options.UseLazyLoadingProxies().UseSqlServer(connection));

builder.Services.AddSingleton<IFileManager, FileManager>();
builder.Services.AddScoped<IJohnyStoreLogger, JohnyStoreLogger>();
builder.Services.AddScoped<ISneakerDataService, SneakerDataSevice>();
builder.Services.AddScoped<IPictureSneakerDataService, PictureSneakerDataService>();
builder.Services.AddScoped<IOrderDataService, OrderDataService>();
builder.Services.AddScoped<IBrandDataService, BrandDataService>();
builder.Services.AddScoped<IAvailabilityDataService, AvailabilityDataService>();
builder.Services.AddScoped<IOrderStatusDataService,OrderDataService>();
builder.Services.AddScoped<IAvailabilityDataStatusService, AvailabilityDataService>();
builder.Services.AddScoped<IPictureBrandDataService, PictureBrandDataService>();
builder.Services.AddScoped<IStyleDataService, StyleDataService>();
builder.Services.AddScoped<IPasswordManager, JWT>();
builder.Services.AddScoped<IJWT, JWT>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddAuthentication(options => //добаление аутентификации в DI
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options => //добавляет поддержку аутентификации с помощью JWT Bearer token
{
    options.RequireHttpsMetadata = false; //только HTTPS-соединения при передаче токена, если true(HTTPS зашифрован и более безопасен чем HTTP)
    options.SaveToken = true; //сохраняет токен в контексте, позволяет использовать в дальнейшем
    options.TokenValidationParameters = new TokenValidationParameters //условия валидации токена
    {
        ValidateIssuerSigningKey = true, //проверка подписи токена при аутентификации
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("JwtSettings:SecretKey"))),//секретный ключ для подписи
        ValidateIssuer = false, //проверка издателя токена
        ValidateAudience = false //проверка аудитории токена
    };
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builderPolicy =>
        {
            builderPolicy.WithOrigins(builder.Configuration.GetValue<string>("Domains:ClientDomain"))
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});


var app = builder.Build();

var fileManager = app.Services.GetRequiredService<IFileManager>();
fileManager.CheckAndCreateDirectoryOrFilesForApp();

// Configure the HTTP request pipeline.
app.UseCors("AllowSpecificOrigin");

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
