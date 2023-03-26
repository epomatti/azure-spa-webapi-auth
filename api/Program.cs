using Microsoft.Identity.Web;
using dotenv.net;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Logging;

DotEnv.Load();

var builder = WebApplication.CreateBuilder(args);

JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

// builder.Services.AddAuthentication(defaultScheme: AppServicesAuthenticationDefaults.AuthenticationScheme)
//   .AddAppServicesAuthentication();

builder.Services.AddMicrosoftIdentityWebApiAuthentication(builder.Configuration);

builder.Services.AddCors(o => o.AddPolicy("default", builder =>
    {
      builder.AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyHeader();
    }));

builder.Services.AddHealthChecks();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
  app.UseDeveloperExceptionPage();
  IdentityModelEventSource.ShowPII = true;
}

app.UseCors("default");
app.UseRouting();
app.UseAuthorization();
app.UseAuthorization();
app.MapHealthChecks("/healthz");

app.MapControllers();

app.Run();
