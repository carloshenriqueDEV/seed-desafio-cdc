using Microsoft.EntityFrameworkCore;
using seed_desafio_cdc_api.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Adiciona suporte para Controllers
builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<AppDbContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
