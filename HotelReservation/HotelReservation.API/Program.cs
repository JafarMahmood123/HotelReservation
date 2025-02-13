using Hotel.API.Data;
using HotelReservation.API.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<HotelReservationDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("HotelReservation"));
});
builder.Services.AddScoped<IHotelRepository, SqlHotelRepository>();
builder.Services.AddScoped<ICustomerRepository,SqlCustomerRepository>();

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
