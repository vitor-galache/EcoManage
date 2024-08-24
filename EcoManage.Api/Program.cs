using EcoManage.Api.Data;
using EcoManage.Api.Endpoints;
using EcoManage.Api.Handlers;
using EcoManage.Domain;
using EcoManage.Domain.Handlers;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
Configuration.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;

builder.Services.AddDbContext<AppDbContext>(x => { x.UseSqlServer(Configuration.ConnectionString); });
builder.Services.AddTransient<ISupplierHandler, SupplierHandler>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapEndpoints();

app.Run();