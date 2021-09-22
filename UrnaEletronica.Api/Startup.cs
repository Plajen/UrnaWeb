using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using UrnaEletronica.Infra.Context;
using Microsoft.EntityFrameworkCore;
using UrnaEletronica.Api.Configuration;
using MediatR;
using UrnaEletronica.Application.Interfaces;
using UrnaEletronica.Application.Services;
using UrnaEletronica.Domain.Interfaces;
using UrnaEletronica.Infra.Repository;
using UrnaEletronica.Infra.UnitOfWork;
using UrnaEletronica.Domain.Core.Bus;
using UrnaEletronica.Domain.Core.Notifications;
using Microsoft.OpenApi.Models;

namespace UrnaEletronica.Api
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

            services.AddSwaggerGen(c => { //<-- NOTE 'Add' instead of 'Configure'
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "UrnaEletronica.API",
                    Version = "v1"
                });
            });

            services.AddDbContext<UrnaEletronicaContext>(cfg =>
            {
                cfg.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddAutoMapperSetup();

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            services.AddMediatR(assemblies);

            services.AddScoped<IMediatorHandler, InMemoryBus>();
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            services.AddScoped<ICandidateAppService, CandidateAppService>();
            services.AddScoped<IVoteAppService, VoteAppService>();

            services.AddScoped<ICandidateRepository, CandidateRepository>();
            services.AddScoped<IVoteRepository, VoteRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UrnaEletronica.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
