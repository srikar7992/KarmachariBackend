using AutoMapper;
using Bridge;
using EntityDbContext;
using Karmachari.Business.Contracts;
using Karmachari.Business.Contracts.Users;
using Karmchari.Business.Services;
using Karmchari.Business.Services.Users;
using Karmchari.Data.Contracts;
using Karmchari.Data.Repositories;
using LoggerImplementation;
using ModelMappers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<LoggerImplementation.ILogger, LoggerImplementation.LoggerFactory>();
builder.Services.AddDbContext<KarmachariDbContext>();
builder.Services.AddScoped<IUserBusinessContract, UserServices>();
builder.Services.AddScoped<IUserDataContract, UserRepository>();
builder.Services.AddScoped<UsersClient>();

// Auto Mapper Configurations
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

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
