using DevbaseChallenge.Core.UnitOfWork;
using DevbaseChallenge.DataAccess.EntityFramework;
using DevbaseChallenge.DataAccess.EntityFramework.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DevbaseChallenge.Core.Service;
using DevbaseChallenge.Service.Service;
using DevbaseChallenge.Core.DataAccess;
using AutoMapper;
using Newtonsoft.Json;

namespace DevbaseChallenge.API
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
            services.AddAutoMapper (typeof(Startup));
            services.AddScoped(typeof(IService<>), typeof(ServiceBase<>));
            services.AddScoped(typeof(Core.DataAccess.IEntityRepository<>), typeof(EfRepositoryBase<>)); 
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped(typeof(IProductService), typeof(ProductService));
            services.AddScoped(typeof(ICategoryService), typeof(CategoryService));
            services.AddControllers();
           
            //services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });


            services.AddDbContext<DevbaseChallengeContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:SqlConStr"].ToString(), o => o.MigrationsAssembly("DevbaseChallenge.DataAccess"));

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
