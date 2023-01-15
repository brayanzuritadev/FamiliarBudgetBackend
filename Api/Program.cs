using Data.DataAccess;
using Microsoft.EntityFrameworkCore;
using Services;
using Services.Utilities;
using Services.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers();
builder.Services.AddTransient<IFamilyDAO, FamilyDAO>();
builder.Services.AddTransient<IFamilyService, FamilyService>();
builder.Services.AddTransient<IAccountDAO, AccountDAO>();
builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<UserValidator>();
builder.Services.AddTransient<Hash>();
builder.Services.AddTransient<TokenGenerator>();

//add automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection")));

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
