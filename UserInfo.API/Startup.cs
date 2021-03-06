using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using UserInfo.Business.Abstract;
using UserInfo.Business.Concrete;
using UserInfo.Business.Handler;
using UserInfo.DataAccess;
using UserInfo.DataAccess.Abstract;
using UserInfo.DataAccess.Concrete;
using UserInfo.DataAccess.MapperProfiles;

namespace UserInfo.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //controller
            services.AddControllers();
            

            //mapper
            services.AddAutoMapper(typeof(ApplicationProfile));

            //dependincy injection
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IGeolocationService, GeolocationService>();
            services.AddScoped<IGeolocationRepository, GeolocationRepository>();
            services.AddScoped<IJwtTokenHandler, JwtTokenHandler>();
            services.AddScoped(typeof(ICacheManipulation<>), typeof(CacheManipulation<>));

            //database connection
            services.AddDbContext<UserDbContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("DatabaseDBConnection"),
                providerOptions => providerOptions.EnableRetryOnFailure());
            });

            //redis connection
            services.AddStackExchangeRedisCache(options => {
                //var host = Configuration["RedisDbHost"] ?? "localhost";
                //var port = Configuration["RedisDbPort"] ?? "6379";
                //options.Configuration =$"{host}:{port}";
                options.Configuration = Configuration.GetConnectionString("RedisDBConnection");
            });


            //data protection
            services.AddDataProtection().PersistKeysToFileSystem(new DirectoryInfo(@"server/share/directory/"));



            //swagger
            services.AddSwaggerGen(x => {
                //x.EnableAnnotations();
                x.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "User Information API",
                    Version = "v1",
                    //Description="This is description"
                });
                x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name="Authentication",
                    Type=SecuritySchemeType.Http,
                    Scheme ="Bearer",
                    BearerFormat="JWT",
                    In=ParameterLocation.Header,
                    Description= "JWT Authorization header using the Bearer scheme."
                });
                x.AddSecurityRequirement(new OpenApiSecurityRequirement
                {{
                    new OpenApiSecurityScheme
                    {
                        Reference=new OpenApiReference
                        {
                            Type=ReferenceType.SecurityScheme,
                            Id="Bearer"
                        }
                    },
                    new string[]{}}
                });
                
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                x.IncludeXmlComments(xmlPath);
            });
            //services.AddAuthentication("BasicAuthentication").AddScheme<AuthenticationSchemeOptions, AuthHandler>("BasicAuthentication", null);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience=false,
                    ValidateLifetime=true,
                    //ValidIssuer= Configuration["JwtAuth:Issuer"],
                    //ValidAudience= Configuration["JwtAuth:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["JwtAuth:Key"]))
                };
            });
            //
            services.AddControllers().AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserDbContext userDbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //userDbContext.Database.Migrate();
            userDbContext.Database.EnsureCreated();
            /*using (var context = new UserDbContext())
            {
                context.Database.EnsureCreated();
            };*/

            //swagger
            app.UseSwagger();
            app.UseSwaggerUI(x => { x.SwaggerEndpoint("/swagger/v1/swagger.json","User API"); });
            
            //auth
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            //endpoint
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                /*endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });*/
            });
        }
    }
}
