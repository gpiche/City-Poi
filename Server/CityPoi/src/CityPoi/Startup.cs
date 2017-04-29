using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityPoi.DataAccesLayer;
using CityPoi.Services;
using jwt_exemple.Jwt;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CityPoi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsEnvironment("Development"))
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
              //  builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
           // services.AddApplicationInsightsTelemetry(Configuration);

            services.AddCors();

            services.AddMvc();

            services.AddScoped<ICityRepository, CityRepository>();

            

            services.AddDbContext<ApiDbContext>(options => options.UseSqlite("Filename=./city.sqlite"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,ApiDbContext apiDbContext)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseCors(builder => builder
               .WithOrigins("http://localhost:4200")
               .AllowAnyHeader()
               .AllowAnyMethod()
               .AllowCredentials()
             );

            // The secret key every token will be signed with.
            // In production, you should store this securely in environment variables
            // or a key management tool. Don't hardcode this into your application!
            const string SECRET_KEY = "ceciestuneclef$ecretQWayoe212";
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SECRET_KEY));

            //Generation du token par le Middleware
            var tokenProviderOptions = CreateTokenProviderOptions(signingKey);
            app.UseMiddleware<TokenProviderMiddleware>(Options.Create(tokenProviderOptions));

            //Validation du token par le Middleware
            var jwtBearerOptions = CreateJwtBearerOptions(signingKey);
            app.UseJwtBearerAuthentication(jwtBearerOptions);


            // app.UseApplicationInsightsRequestTelemetry();

            // app.UseApplicationInsightsExceptionTelemetry();

            app.UseMvc();
            apiDbContext.EnsureSeedDataForContext();
        }

        private JwtBearerOptions CreateJwtBearerOptions(SymmetricSecurityKey signingKey)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,

                ValidateIssuer = true,
                ValidIssuer = "localhost",

                ValidateAudience = true,
                ValidAudience = "localhost",

                ValidateLifetime = true,

                // If you want to allow a certain amount of clock drift, set that here:
                ClockSkew = TimeSpan.Zero
            };
            var jwtBearerOptions = new JwtBearerOptions
            {
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                TokenValidationParameters = tokenValidationParameters
            };

            return jwtBearerOptions;
        }

        private TokenProviderOptions CreateTokenProviderOptions(SymmetricSecurityKey signingKey)
        {
            var tokenProviderOptions = new TokenProviderOptions
            {
                //voir les options par défauts dans TokenProviderOptions
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256),
            };
            return tokenProviderOptions;
        }
    }
}
