using DatingAppFS.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

//connecting to sql lite 
builder.Services.AddDbContext<AppUserDataContext>(option => {
    //type of database to be used which has been installed from nuget package manager 
    // provide the connection string 
    option.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// HTTP request to HTTPS request 
//app.UseHttpsRedirection();

// authorize the incoming request
app.UseAuthorization();

//CORS allowed 
app.UseCors(policyBuilder => policyBuilder.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"));

//maps the controller to the service atline #4 
app.MapControllers();

app.Run();

