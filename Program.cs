using AutoMapper;
using BloodTransferAPI;
using BloodTransferAPI.Data;
using BloodTransferAPI.Handler;
using BloodTransferAPI.Model;
using BloodTransferAPI.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<AppDbContext>();
builder.Services.AddScoped<IRecieverRepository, RecieverRepository>();
builder.Services.AddScoped<ITransferRepository,TransferRepository>();
builder.Services.AddScoped<ITransmitterRepository,TransmitterRepository>();
builder.Services.AddScoped<IRecieverHandler, RecieverHandler>();
builder.Services.AddScoped<ITransmiiterhandler,TransmitterHandler>();
builder.Services.AddScoped<ITransferHandler, TransfertHandler>();
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"), sqlServerOptionsAction: sqlOptions =>
    { sqlOptions.EnableRetryOnFailure();
        options.EnableSensitiveDataLogging();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
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
