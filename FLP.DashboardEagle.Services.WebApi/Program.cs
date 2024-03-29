using FLP.DashboardEagle.Application.Interface;
using FLP.DashboardEagle.Application.Main;
using FLP.DashboardEagle.Domain.Core;
using FLP.DashboardEagle.Domain.Interface;
using FLP.DashboardEagle.Infraestructure.Data;
using FLP.DashboardEagle.Infraestructure.Interface;
using FLP.DashboardEagle.Infraestructure.Repository;
using FLP.DashboardEagle.Transversal.Common;
using FLP.DashboardEagle.Transversal.Mapper;
using Npgsql;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var corsPolicy = "_corsPolicy";
var corsOrigin = builder.Configuration.GetSection("CorsOrigins").Value.ToString();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsPolicy,
        policy =>
            policy.WithOrigins(corsOrigin));
});

builder.Services.AddAutoMapper(x => x.AddProfile(new MappingsProfile()));
builder.Services.AddSingleton<IConnectionFactory, ConnectionFactory>();
builder.Services.AddScoped<IEagleResponseApplication, EagleResponseApplication>();
builder.Services.AddScoped<IEagleResponseDomain, EagleResponseDomain>();
builder.Services.AddScoped<IEagleRepository, EagleRepository>();

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

app.MapControllers();

app.UseCors(corsPolicy);

app.Run();
