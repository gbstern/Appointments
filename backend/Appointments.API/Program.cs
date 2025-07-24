using Appointments.Core;
using Appointments.Core.Data;
using Appointments.Core.Service;
using Appointments.Data;
using Appointments.Data.Data;
using Appointments.Service.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;
using static System.Net.WebRequestMethods;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
});



//mapper הזרקת ה
builder.Services.AddAutoMapper(typeof(Mapping));

//dataContex הזרקת ה 
builder.Services.AddDbContext<DataContext>();

//הזרקת רופאים
builder.Services.AddScoped<IDoctorData, DoctorData>();
builder.Services.AddScoped<IDoctorService, DoctorService>();


//הזרקת מקצועות
builder.Services.AddScoped<ISpecialtyData, SpecialtyData>();
builder.Services.AddScoped<ISpecialtyService, SpecialtyService>();


//הזרקת מטופלים
builder.Services.AddScoped<IPatientData, PatientData>();
builder.Services.AddScoped<IPatientService, PatientService>();


//הזרקת תורים
builder.Services.AddScoped<IAppointmentData, AppointmentData>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();

//הזרקת ימי ושעות עבודה
builder.Services.AddScoped<IWorkingHoursData, WorkingHoursData>();
builder.Services.AddScoped<IWorkingHoursService, WorkingHoursService>();


//מניעת מעגליות נתונים
builder.Services.AddControllers().AddJsonOptions(option =>
{
    option.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    option.JsonSerializerOptions.WriteIndented = true;
});


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("manager", policy => policy.RequireRole("manager"));
    options.AddPolicy("patient", policy => policy.RequireRole("patient"));
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "http://localhost:2025/",
        ValidAudience = "http://localhost:4200/",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("hereIsSomeVeryLongKeyToGenerateMyJwtToken"))
    };
});


builder.Services.AddCors(options => {
    options.AddPolicy("CorsPolicy",
                  builder => builder.WithOrigins("http://localhost:4200", "development web site")
                             .AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

//ניהול זהות
app.UseAuthentication();

//מתן הרשאות בהתאם לזהות
app.UseAuthorization();

app.MapControllers();

app.Run();
