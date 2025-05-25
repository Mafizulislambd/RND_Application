using DapperApi.Services.Contracts;
using DapperApi.Services.DapperCon;
using DapperApi.Services.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi(); 
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddControllers();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
