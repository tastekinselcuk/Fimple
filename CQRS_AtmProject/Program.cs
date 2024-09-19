using Microsoft.EntityFrameworkCore;
using CQRS_AtmProject.Data;
using CQRS_AtmProject.Infrastructure.Data.Repositories;
using CQRS_AtmProject.Infrastructure.Services; // CassetteService ve diğer servisler için gerekli
using CQRS_AtmProject.Infrastructure.Data.Repositories.Cassettes;
using CQRS_AtmProject.Infrastructure.Data.Repositories.Atms;
using CQRS_AtmProject.Infrastructure.Data.Repositories.CurrencyDenominations;
using CQRS_AtmProject.Infrastructure.ExceptionHandling; // CassetteRepository için gerekli

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS settings
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:8080") // Vue uygulamanızın URL'si
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

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
builder.Services.AddScoped<ITransactionService, TransactionService>();

// Controller
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseRouting();

// CORS ayarlarını burada uygulayın
app.UseCors("AllowSpecificOrigin");

app.UseAuthorization();

app.MapControllers();

app.UseHttpsRedirection();

app.Run();
