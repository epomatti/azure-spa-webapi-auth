using Microsoft.Identity.Web;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using dotenv.net;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Logging;

DotEnv.Load();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
//             .AddMicrosoftIdentityWebApi(options => builder.Configuration.Bind("AzureAd", options));

JwtSecurityTokenHandler.DefaultMapInboundClaims = false;
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

// Only for development
IdentityModelEventSource.ShowPII = true;

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
  app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.UseAuthorization();
app.UseAuthorization();
app.MapHealthChecks("/healthz");

app.MapControllers();

app.Run();
