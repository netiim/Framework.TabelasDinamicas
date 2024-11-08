﻿using Core.Interfaces.Repository;
using Core.Interfaces.Services;
using Dados.Repositorio;
using Microsoft.OpenApi.Models;
using Services;
using System.Reflection;

namespace ContatoAPI.Extension;

public static class ExtensionsProgram
{
    public static IServiceCollection AddInjecoesDependencias(this IServiceCollection services)
    {
        services.AddScoped<ITableModelRepository, TableModelRepository>();
        services.AddScoped<ITableModelService, TableModelService>();

        return services;
    }

    public static IServiceCollection AddDocumentacaoSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Tables API", Description = "Uma API para a criação de tabelas dinamicas que podem sofrer acrescimos de linhas e colunas, reeordenação e troca de nomes" });

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

            c.IncludeXmlComments(xmlPath);
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization Header -  utilizado com Bearer Authentication" +
                              "Digite 'Bearer' [espaço] token" +
                              "Exemplo (informar sem as aspas): 'Bearer 123456abcdef'",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT"
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });

        return services;
    }   

}