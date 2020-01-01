using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Enjaz_StackOverFlow.Models;
using Enjaz_StackOverFlow.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.Swagger;

namespace Enjaz_StackOverFlow
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
            // Regester Dependences For Injection
            services.AddDbContext<Enjaz_Context>(x => x.UseSqlServer(Configuration.GetConnectionString("Connection")));
            services.AddScoped<IUserService, UserServices>();
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddAutoMapper(typeof(Startup));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
      {
        {
          new OpenApiSecurityScheme
          {
            Reference = new OpenApiReference
              {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
              },
              Scheme = "oauth2",
              Name = "Bearer",
              In = ParameterLocation.Header,

            },
            new List<string>()
          }
        });

            });

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes("kNpMKqse4DkJAEEFrbgsJ22iPfTpSr_KuX3RtE27nkroJridN6mQ2qbszI1ooG9GMJoFm1nUQJLpPN_OVCG_Nw")
                    ),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

          
            services.AddAuthorization();

            services.AddMvc().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});
            services.AddControllers();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }



            app.UseHttpsRedirection();


            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyAPI V1");
            });

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthorization();



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });






        }
    }
}
