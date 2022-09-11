using Core.CrossCuttingConcerns.Exceptions;
using Microsoft.OpenApi.Models;
using ProgramingLanguage.API;
using ProgramingLanguage.Application;
using ProgramingLanguage.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
                                {
                                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
                                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                                {
                                    Type = SecuritySchemeType.Http,
                                    BearerFormat = "JWT",
                                    In = ParameterLocation.Header,
                                    Scheme = "Bearer"
                                });
                                c.OperationFilter<AuthorizationHeaderParameterOperationFilter>();
                                });

builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.ConfigureCustomExceptionMiddleware();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
