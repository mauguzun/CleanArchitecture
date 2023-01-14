using ApplicationServices.Interfaces;
using ApplicatonServices.Implementation;
using DataAccess.Interfaces;
using DataAccess.Mssql;
using Delivery.Bold;
using Delivery.Interfaces;
using DomainServices.Implementation;
using DomainServices.Intefaces;
using Email.Interfaces;
using Email.Mailchimp;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Mobile.UseCases.Orders.Commands.Create;
using Mobile.UseCases.Orders.Utils;
using Mobile.UseCases.Services;
using WebApp.Interfaces;
using WebApp.Services;

namespace WebApp
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

     
            // Domain
            services.AddScoped<IOrderDomainService, OrderDomainService>();

            //Infrascture

            services.AddScoped<IDeliveryService,DeliveryService>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<IEmailService,   EmailService>();
            services.AddDbContext<IDbContext,AppDbContext>(builder =>
                builder.UseSqlServer(Configuration.GetConnectionString("MsSql")));


            // Application
            services.AddScoped<IOrderService, OrderService>(); // one way user service
            services.AddMediatR(typeof(CreateOrderCommand)); //  use SQRC

            services.AddScoped<ISecurityService, SecurityService>();

            //framework
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApp", Version = "v1" });
            });
            services.AddAutoMapper(typeof(MapperProfile));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApp v1"));
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
