using Microsoft.EntityFrameworkCore;
using Taller_2_PatronProxy.Data;
using Taller_2_PatronProxy.Repository;
using Taller_2_PatronProxy.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

//Cache
builder.Services.AddMemoryCache();

//App Db Context
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ?? 
                           throw new InvalidOperationException("Connection string 'Default Connection' not found'"));
});

builder.Services.AddScoped<IHeroRepository, HeroRepository>();

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