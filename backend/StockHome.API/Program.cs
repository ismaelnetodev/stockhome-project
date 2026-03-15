using Microsoft.EntityFrameworkCore;
using StockHome.API.Data;
using StockHome.API.Services;
using StockHome.API.Services.Interfaces;
using Scalar.AspNetCore;
using Microsoft.AspNetCore.Identity;
using StockHome.API.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(p =>
    {
        p.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
    });
});

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString));

builder.Services.AddAuthentication(IdentityConstants.BearerScheme).AddBearerToken();
builder.Services.AddAuthorizationBuilder();

builder.Services.AddIdentityApiEndpoints<User>().AddEntityFrameworkStores<AppDbContext>().AddApiEndpoints();

builder.Services.AddScoped<ICategoryService, CategoryService>();

var app = builder.Build();

app.MapIdentityApi<User>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.MapScalarApiReference(options =>
    {
        options
            .WithTitle("API StockHome")
            .WithTheme(ScalarTheme.DeepSpace)
            .AddHttpAuthentication("BearerAuth", auth =>
            {
                auth.Token = "";
            })
            .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
    });
}

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
