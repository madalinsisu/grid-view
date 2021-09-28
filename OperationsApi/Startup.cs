using AutoMapper;
using AutoMapper.EquivalencyExpression;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using OperationsApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using OperationsApi.Features.Deposits;
using OperationsApi.Features.Operations;
using OperationsApi.Features.TradeOrders;
using OperationsApi.Features.Withdrawals;
using OperationsApi.Features.OperationTypes;
using OperationsApi.Features.TradeOrderTypes;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using OperationsApi.Infrastructure.Routing;

namespace OperationsApi
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

            services.AddControllers(options =>
            {
                options.Conventions.Add(new RouteTokenTransformerConvention(new KebabCaseRoutingConvention()));
            });

            services.AddDbContext<OperationsDBContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("ConnectionString")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddAutoMapper(
                config =>
                {
                    config.AddCollectionMappers();
                },
                Assembly.GetExecutingAssembly()
            );

            services.AddTransient<DepositService>();
            services.AddTransient<OperationService>();
            services.AddTransient<TradeOrderService>();
            services.AddTransient<WithdrawalService>();
            services.AddTransient<OperationTypeService>();
            services.AddTransient<TradeOrderTypeService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "OperationsApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OperationsApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
