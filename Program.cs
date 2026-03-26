using HMS.Data;
using HMS.Repositories;
using HMS.Repositories.GenericRepo;
using HMS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();



builder.Services.AddDbContext<HMSDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("conn")));


builder.Services.AddScoped(typeof(IGenericRepo<>),typeof(GenericRepo<>));
builder.Services.AddScoped<IPatientRepo, PatientRepo>();
builder.Services.AddScoped<IDoctorRepo, DoctorRepo>();
builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();
builder.Services.AddScoped<IAppointmentRepo, AppointmentRepo>();
builder.Services.AddScoped<IMedicalRecordRepo, MedicalRecordRepo>();




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
