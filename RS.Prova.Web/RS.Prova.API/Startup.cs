using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using RS.Prova.DI;
using RS.Prova.Domain.Contracts.Repositories;
using Swashbuckle.AspNetCore.Swagger;

namespace RS.Prova.API
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //Injeta a dependencia das interfaces de acesso ao banco
            services.AddDependency();

            //adiciona MVC
            services.AddMvc();
            

            //Adiciona o Swagger
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Info() { Title = "Empresa XPTO API" });

            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();      
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("swagger/v1/swagger.json", "Empresa XPTO API");
                s.RoutePrefix = string.Empty;
            });
        }
    }
}
