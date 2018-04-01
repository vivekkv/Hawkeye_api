using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Admin_Backend.Models;
using Microsoft.EntityFrameworkCore;
using Admin_Backend.Filters;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Admin_Backend.Models.Token;
using Admin_Backend.Models.Security;
using Admin_Backend.Models.DbModels;

namespace Admin_Backend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            var connection = Configuration.GetConnectionString("DefaultConnection");
            var apveraTokenSecKey = Configuration.GetSection("Token").GetSection("SecKey").Value;

            services.AddDbContext<ApveraDbContext>(options => options.UseNpgsql(connection));
            services.AddTransient<DataSeeder>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,

                            ValidIssuer = "Apvera.Security.Bearer",
                            ValidAudience = "Apvera.Security.Bearer",
                            IssuerSigningKey = JwtSecurityKey.Create(apveraTokenSecKey)
                        };

                        options.Events = new JwtBearerEvents
                        {
                            OnAuthenticationFailed = context =>
                            {
                                Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                                return Task.CompletedTask;
                            },
                            OnTokenValidated = context =>
                            {
                                Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                                return Task.CompletedTask;
                            }
                        };
                    });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Member", policy => policy.RequireClaim("MembershipId"));
            });


            services.AddMvc(opt =>
            {
                opt.Filters.Add(typeof(ValidatorActionFilter));
            }).AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseCors(b => b.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=values}/{action=get}/{id?}");
            });

            try
            {
                AddUserDataSeeds();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        private void AddUserDataSeeds()
        {
            var _context = new ApveraDbContext(Configuration.GetConnectionString("DefaultConnection"));

            if (!_context.Users.Any())
            {
                var passwordHash = SimpleHash.ComputeHash("Admin", "SHA1", Encoding.ASCII.GetBytes("APVERA_SALT"));

                _context.Users.Add(new Users
                {
                    UserName = "Admin@apvera",
                    Password = passwordHash,
                    Salt = "APVERA_SALT",
                    Name = "Admin",
                    RoleId = 1
                });

                _context.SaveChanges();
            }
        }
    }
}
