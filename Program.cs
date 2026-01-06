using CarWorkshopAPI.Data;
using CarWorkshopAPI.Profiles;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<CarWorkshopDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(cfg => 
{
    cfg.AddProfile<MappingProfile>(); 
}, AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();




if (app.Environment.IsDevelopment())
{


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();