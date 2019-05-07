using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Shared;
using Application.UseCases.ExchangeRates;
using Application.UseCases.GetClientOrders;
using Application.UseCases.GetOrder;
using Application.UseCases.GetSomeData;
using Application.UseCases.SearchCustomerByName;
using AutoMapper;
using Infrastructure.Database.Context;
using Infrastructure.Database.Repo.Customer;
using Infrastructure.Database.Repo.Orders;
using Infrastructure.Log;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using WebUi.Middleware;
using WebUi.Middleware.ExceptionResponse;
using WebUi.Shared;

namespace WebUi
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            //Configuration = configuration;

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc(o =>
            {
                o.Filters.Add(new ProducesAttribute("application/json"));
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

                // Add Context into the container.
                services.AddDbContext<WideWorldImportersContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("WideWorldImporters"))
                );

            services.AddAutoMapper();

            // Add services into the container.
            services.AddScoped<IDataLogger, DataLogger>();
            services.AddTransient<IClientOrders, ClientOrders>();
            services.AddTransient<IOrder, Order>();
            services.AddTransient<IClientOrder, ClientOrder>();
            services.AddTransient<IOrderRepo, OrderRepo>();
            services.AddTransient<IClientOrderAuthorization, ClientOrderAuthorization>();

            services.AddTransient<ICustomerSearchRepo, CustomerSearchRepo>();
            services.AddTransient<ICustomerSearch, CustomerSearch>();

            services.AddTransient<IExceptionResponse, ExceptionResponse>();

            services.AddTransient<ISomeDataGetter, SomeDataGetter>();


            services.AddTransient<IExchangeRateApi, ExchangeRateApi>();


            AddSerilogServices(services);

            services.AddSwaggerDocumentation();

            // Miniprofiler.
            services.AddMiniProfiler(options =>
                {
                    options.PopupRenderPosition = StackExchange.Profiling.RenderPosition.BottomLeft;
                    options.PopupShowTimeWithChildren = true;
                })
                .AddEntityFramework();
        }

        private void AddSerilogServices(IServiceCollection services)
        {
            //https://github.com/serilog/serilog-settings-configuration

            var configuration = new ConfigurationBuilder()
                .AddJsonFile(path: "appsettings.json", optional: false, reloadOnChange: true)
                .Build();


            services.AddScoped<Serilog.ILogger>
            (x => new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger());

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerDocumentation();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            AddMiddlewareApplications(app);

            // Miniprofiler > before UseMVC!!!!!
            app.UseMiniProfiler();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private static void AddMiddlewareApplications(IApplicationBuilder app)
        {
            app.UseMiddleware<RequestResponseLoggingMiddleware>();
            app.UseMiddleware<UnhandledExceptionHandlerMiddleware>();
        }
    }
}
