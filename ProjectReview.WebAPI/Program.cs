using Microsoft.EntityFrameworkCore;
using ProjectReview.WebAPI.Extensions;
using ProjectReviewWebAPI.Application;
using ProjectReviewWebAPI.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureDataBaseContext(builder.Configuration);
builder.Services.AddAutoMapper(typeof(MapInitializers));
builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();
builder.Services.ResolveDependencyInjection();
builder.Services.ConfigureJWT(builder.Configuration);
builder.Services.ConfigureSwaggerAuth();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
