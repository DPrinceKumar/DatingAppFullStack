using DatingAppFS.Data;
using DatingAppFS.Extension;
using DatingAppFS.Middlewere;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Db realted
builder.Services.AddAppService(builder.Configuration);

//Authentication
builder.Services.AddAppIdentity(builder.Configuration);


var app = builder.Build();

//Generating development error page 
/*if (builder.Environment.IsProduction())
{
    app.UseDeveloperExceptionPage();
}
*/

app.UseMiddleware<ExceptionMiddlewere>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// HTTP request to HTTPS request 
//app.UseHttpsRedirection();

//CORS allowed 
app.UseCors(policyBuilder => policyBuilder.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"));

// authorize the incoming request
app.UseAuthentication();
app.UseAuthorization();
//maps the controller to the service atline #4 
app.MapControllers();

using var scope =app.Services.CreateScope();
var services =scope.ServiceProvider;
try
{
    var context =services.GetRequiredService<AppUserDataContext>();
    await context.Database.MigrateAsync();
    await Seed.SeedUsers(context);
}
catch (Exception e)
{

	var logger =services.GetService<ILogger<Program>>();
    logger.LogError(e, "An error COccured during Migration");
}

app.Run();

