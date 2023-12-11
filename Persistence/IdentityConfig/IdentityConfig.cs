using Application.Contract.Identity;
using Application.Models.IdentityModels;
using Domain.Users;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Persistence.Contexts;
using Persistence.IdentityConfig;
using Persistence.IdentityServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.IdentityConfig
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
            services.AddTransient<IAuthService, AuthService>();
            services.AddDbContext<IdentityDatabaseContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DatabaseConection"));
            });

            services.AddIdentityCore<User>(options => { })
               .AddRoles<IdentityRole>()
               .AddEntityFrameworkStores<IdentityDatabaseContext>()
               .AddSignInManager()
               .AddErrorDescriber<CustomIdentityErrors>()
               .AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
           .AddJwtBearer(o =>
           {
               o.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuerSigningKey = true,
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidateLifetime = true,
                   ClockSkew = TimeSpan.Zero,
                   ValidIssuer = configuration["JwtSettings:Issuer"],
                   ValidAudience = configuration["JwtSettings:Audience"],
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
               };
           })
           .AddCookie("Identity.Application", options =>
           {
               options.Cookie.HttpOnly = true;
               options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
               options.LoginPath = "/Account/Login";
               options.AccessDeniedPath = "/Account/AccessDenied";
               options.SlidingExpiration = true;
           }); ;


            services.Configure<IdentityOptions>(option =>
            {
                // UserSetting
                // option.User.AllowedUserNameCharacters = "abcd123";
                option.User.RequireUniqueEmail = true;

                // Password Setting
                option.Password.RequireDigit = false;
                option.Password.RequireLowercase = false;
                option.Password.RequireNonAlphanumeric = false; //!@#$%^&*()_+
                option.Password.RequireUppercase = false;
                option.Password.RequiredLength = 4;
                option.Password.RequiredUniqueChars = 1;

                // Lockout Setting
                option.Lockout.MaxFailedAccessAttempts = 3;
                option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);

                // SignIn Setting
                option.SignIn.RequireConfirmedAccount = false;
                option.SignIn.RequireConfirmedEmail = false;
                option.SignIn.RequireConfirmedPhoneNumber = false;
            });

            return services;
        }
    }
}
