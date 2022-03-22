using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PokeTrade.Application.AutoMapper;
using PokeTrade.Application.IService;
using PokeTrade.Application.Services;
using PokeTrade.Domain.IRepository;
using PokeTrade.Infrastructure.Repository;
using System;

namespace PokeTrade.API
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
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Poke Trade Calculator API",
                    Version = "v1",
                    Description = "Calculates if the trade between two pokemon players is fair for both",
                    Contact = new OpenApiContact
                    {
                        Name = "Lucas Tenório dos Santos",
                        Email = "tenori_o@outlook.com"
                    },
                });
            });

            services.AddSingleton<IConfiguration>(Configuration);

            services.AddAutoMapper(typeof(AutoMapperSetup));

            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            ConfigureDependencyInjection(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Poke Trade API V1");

                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void ConfigureDependencyInjection(IServiceCollection services)
        {
            services.AddScoped<ITradeService, TradeService>();
            services.AddScoped<ITradeRepository, TradeRepository>();
        }

    }
}
