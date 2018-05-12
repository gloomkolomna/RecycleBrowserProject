using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RecycleProject.Interfaces;
using RecycleProject.Interfaces.Authenticate.Jwt;
using RecycleProject.Interfaces.DI;
using RecycleProject.Interfaces.Models;
using RecycleProject.Model;
using RecycleProject.Model.Authenticate.JWT;
using RecycleProject.Model.DI;
using System;
using System.Text;

namespace RecycleProject
{
    public class Startup
    {
        private readonly SecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("iNivDmHLpUA223sqsfhqGbMRdRj1PVkH"));

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddTransient<IAddress, Address>();
            services.AddTransient<ICategory, Category>();
            services.AddTransient<ICompany, Company>();
            services.AddTransient<IContact, Contact>();
            services.AddTransient<ILocation, Location>();
            services.AddTransient<IRecyclePoint, RecyclePoint>();

            services.TryAddSingleton<IDIMeta>(s =>
            {
                return new DIMetaDefault(services);
            });

            services.AddTransient<IConfigureOptions<MvcJsonOptions>, JsonOptionsSetup>();

            services.AddDbContext<IdentityContext>(options => options.UseMySQL(Configuration.GetConnectionString("ManageDbConnection")));
            // ("Server=localhost;database=users;user=root;password=root"));
            // (Configuration.GetConnectionString("ManageDbConnection")));
            services.AddDbContextPool<RecycleContext>(options => options.UseMySQL(Configuration.GetConnectionString("RecycleDbConnection")));
            // ("Server=localhost;database=recycle;user=root;password=root"));
            // (Configuration.GetConnectionString("RecycleDbConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>();

            services.AddSingleton<IJwtFactory, JwtFactory>();

            services.TryAddTransient<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<IRepository, Repository>();

            // jwt wire up
            // Get options from app settings
            var jwtAppSettingOptions = Configuration.GetSection(nameof(JwtIssuerOptions));

            JwtIssuerOptions jwtOptions = new JwtIssuerOptions
            {
                Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)],
                Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)],
                ValidFor = int.Parse(jwtAppSettingOptions[nameof(JwtIssuerOptions.ValidFor)]),
                SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256)
            };

            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                        .RequireAuthenticatedUser()
                        .Build());
            });
            
            // Configure JwtIssuerOptions
            services.Configure<JwtIssuerOptions>(options =>
            {
                options.Issuer = jwtOptions.Issuer;
                options.Audience = jwtOptions.Audience;
                options.ValidFor = jwtOptions.ValidFor;
                options.SigningCredentials = jwtOptions.SigningCredentials;
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                    .AddJwtBearer(configureOptions =>
                    {
                        configureOptions.ClaimsIssuer = jwtOptions.Issuer;
                        configureOptions.SaveToken = true;
                        configureOptions.RequireHttpsMetadata = false;
                        configureOptions.TokenValidationParameters = new TokenValidationParameters
                        {
                            // укзывает, будет ли валидироваться издатель при валидации токена
                            ValidateIssuer = true,
                            // строка, представляющая издателя
                            ValidIssuer = jwtOptions.Issuer,

                            // будет ли валидироваться потребитель токена
                            ValidateAudience = true,
                            // установка потребителя токена
                            ValidAudience = jwtOptions.Audience,
                            // будет ли валидироваться время существования
                            ValidateLifetime = true,

                            RequireExpirationTime = false,

                            ClockSkew = TimeSpan.Zero,

                            // установка ключа безопасности
                            IssuerSigningKey = _signingKey,
                            // валидация ключа безопасности
                            ValidateIssuerSigningKey = true
                        };
                    });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", p =>
                {
                    p.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();

            app.UseCors("AllowAll");
            app.UseMvc();
        }
    }
}
