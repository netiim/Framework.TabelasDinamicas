using ContatoAPI.Extension;
using LocalizacaoService._03_Repositorys.Config;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDocumentacaoSwagger();
builder.Services.AddInjecoesDependencias();
builder.Services.AddAutoMapper();
builder.Services.AddCorsConfig();
builder.Services.AddConfiguracaoMongo(builder.Configuration);


var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
