using DatingAppFS.Extension;
using DatingAppFS.Middlewere;

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

app.Run();

