using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_exam_project.core.ApplicationService;
using Final_exam_project.core.ApplicationService.MensIService;
using Final_exam_project.core.ApplicationService.Services.MensService;
using Final_exam_project.core.DomainService;
using Final_exam_project.core.DomainService.MensIRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using TheRange.Core.ApplicationService;
using TheRange.Core.ApplicationService.Services;
using TheRange.Core.ApplicationService.Services.MensService;
using TheRange.Core.DomainService;
using TheRange.Core.Helper;
using TheRange.Infrastructure.SQL.Data;
using TheRange.Infrastructure.SQL.Data.MensRepositories;
using TheRange.Infrastructure.SQL.Data.Repositories;

namespace Final_exam_The_Range
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Byte[] secretBytes = new byte[40];
            Random rand = new Random();
            rand.NextBytes(secretBytes);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretBytes),
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(5)
                };
            });
            if (Environment.IsDevelopment())
            {
                services.AddDbContext<TheRangeContext>
                    (opt => opt.UseSqlite("Data Source=UmbrellaShopSQLLite.db")
                );
            }
            else
            {
                services.AddDbContext<TheRangeContext>(
                    opt =>
                    {
                        opt.UseSqlServer(Configuration.GetConnectionString("defaultConnection"));
                    });

            }

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ISweatshirtsRepository, SweatshirtsRepository>();
            services.AddScoped<ISweatshirtsService, SweatshirtsService>();
            services.AddScoped<ITopsRepository, TopsRepository>();
            services.AddScoped<ITopsService, TopsService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerService, CustomerService>();

            services.AddSingleton<IAuthenticationHelper>(new AuthenticationHelper(secretBytes));
            services.AddTransient<IDBInitialiser, DBInitialiser>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                options.SerializerSettings.MaxDepth = 5;
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder
                        //.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
                        .WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod()
                );
            });
            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("AllowSpecificOrigin");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    var context = scope.ServiceProvider.GetService<TheRangeContext>();
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                    var dbInitializer = services.GetService<IDBInitialiser>();
                    dbInitializer.Seed(context);
                }


            }
            else
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {

                    var context = scope.ServiceProvider.GetRequiredService<TheRangeContext>();
                    IDBInitialiser dbInitializer = scope.ServiceProvider.GetService<IDBInitialiser>();
                    context.Database.EnsureCreated();
                    dbInitializer.Seed(context);

                }
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
