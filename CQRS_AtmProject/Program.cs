using Microsoft.EntityFrameworkCore;
using UserProductManagementAPI.Data;
using UserProductManagementAPI.Infrastructure.Data.Repositories;
using UserProductManagementAPI.Infrastructure.Services; // CassetteService ve diğer servisler için gerekli
using UserProductManagementAPI.Infrastructure.Data.Repositories.Cassettes;
using UserProductManagementAPI.Infrastructure.Data.Repositories.Atms;
using UserProductManagementAPI.Infrastructure.Data.Repositories.CurrencyDenominations; // CassetteRepository için gerekli

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));


// MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

// Repositories
builder.Services.AddScoped<IAtmRepository, AtmRepository>();
builder.Services.AddScoped<ICassetteRepository, CassetteRepository>();
builder.Services.AddScoped<ICurrencyDenominationRepository, CurrencyDenominationRepository>();

// Services
builder.Services.AddScoped<IAtmService, AtmService>();
builder.Services.AddScoped<ICassetteService, CassetteService>();
builder.Services.AddScoped<ICurrencyDenominationService, CurrencyDenominationService>();

// Controller
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.UseHttpsRedirection();

app.Run();
