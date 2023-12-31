
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SuperTurista.Core.Helpers;
using SuperTurista.DataAccess;
using SuperTurista.DataAccess.Repository;
using SuperTuriste.Service.Services;
using System.Text;

namespace SuperTurista.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var CorsOrigin = new string[]
            {
                "http://localhost:4200",
                "http://localhost:4201",
                "http://localhost:4202",
            };

            void CorsPolicy(CorsPolicyBuilder g) => g
                    .WithOrigins(CorsOrigin)
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()
                    .SetPreflightMaxAge(new TimeSpan(0, 0, 24));

            builder.Services.AddCors(f =>
            {
                f.AddPolicy("app", CorsPolicy);
                f.AddDefaultPolicy(CorsPolicy);
            });

            string connString = configuration.GetConnectionString("DefaultConnection") ?? "";
            if (string.IsNullOrWhiteSpace(connString))
                throw new Exception("Cant find connection string.");

            builder.Services.AddDbContext<DbContext, SuperTuristaDbContext>(
                options => options
                     .UseSqlServer(connString)
                     .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
            );

            ConfigureIoC(builder.Services);
            ConfigureAuthorization(builder.Services, configuration);

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
        }
        public static void ConfigureAuthorization(IServiceCollection services, ConfigurationManager config)
        {
            services.AddAuthorization();
            services.AddTokenAuthentication(config);
            services.AddSwaggerGen(
                c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "SuperTurista", Version = "v1" });
                    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                    {
                        Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer token')",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.Http,
                        Scheme = "Bearer"
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
        }
        public static void ConfigureIoC(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            //services.AddSingleton<ServerFolders>();
            services.AddScoped<JwtHelper>();
            services.AddScoped<JwtService>();
            services.AddScoped<IBaseService, BaseService>();

            services.AddScoped<ISystemParametersRepository, SystemParametersRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IVehiculoRepository, VehiculoRepository>();
            services.AddScoped<IAlojamientoRepository, AlojamientoRepository>();
            services.AddScoped<IEntityFilesRepository, EntityFilesRepository>();

            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<ISeguridadService, SeguridadService>();
            services.AddScoped<IVehiculoService, VehiculoService>();
            services.AddScoped<IAlojamientoService, AlojamientoService>();
            services.AddScoped<IEntityFilesService, EntityFilesService>();
        }
    }
}