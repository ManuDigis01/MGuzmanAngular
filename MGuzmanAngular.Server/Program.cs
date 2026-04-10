
using DL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MGuzmanAngular.Server
{
    public class Program 
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidateLifetime = true,
                       ValidateIssuerSigningKey = true,
                       ValidIssuer = "yourdomain.com",
                       ValidAudience = "yourdomain.com",
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("miclave_super_secreta_12345678901234567890"))
                   };
               });

            builder.Services.AddDbContext<MguzmanProgramacionNcapasContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("connectionDB")
                ));

            builder.Services.AddScoped<BL.Usuario>();
            //builder.Services.AddScoped<BL.Rol>();
            //builder.Services.AddScoped<BL.Colonia>();
            //builder.Services.AddScoped<BL.Estado>();
            //builder.Services.AddScoped<BL.Municipio>();



            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication(); // ? FALTA
            app.UseAuthorization();


            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
