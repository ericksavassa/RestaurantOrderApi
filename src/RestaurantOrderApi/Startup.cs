using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RestaurantOrder.Application.Repositories;
using RestaurantOrder.Application.Services;
using RestaurantOrder.Domain.Services;
using RestaurantOrder.Infrastructure.InMemoryDataAccess;
using RestaurantOrder.Infrastructure.InMemoryDataAccess.Repositories;

namespace RestaurantOrder.Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
                        
            services.AddTransient<IOrderService, OrderService>();

            services.AddScoped<IDayTimeStrategy, DayTimeStrategy>();
            services.AddScoped<ICalculateOrderService, MorningService>();
            services.AddScoped<ICalculateOrderService, NightService>();

            services.AddScoped<IOrderWriteRepository, OrderRepository>();
            services.AddScoped<IOrderReadRepository, OrderRepository>();

            services.AddSingleton<Context>();            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
