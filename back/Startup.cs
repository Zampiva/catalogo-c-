using System.Text;
using CatalogoVeiculos.API.Data;
using CatalogoVeiculos.API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace CatalogoVeiculos.API
{
    public class Startup
    {
        // ...

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Configurar a autenticação JWT
            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("JwtConfig:SecretKey").Value);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration.GetSection("JwtConfig:ValidIssuer").Value,
                    ValidAudience = Configuration.GetSection("JwtConfig:ValidAudience").Value,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });

            // Configurar o banco de dados SQLite
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
            });

            // Adicionar serviços do projeto
            services.AddScoped<AuthService>();
            services.AddScoped<TokenService>();
        }

        // ...
    }
}
