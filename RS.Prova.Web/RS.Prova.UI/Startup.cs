using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using RS.Prova.DI;

namespace RS.Prova.UI
{
    public class Startup
    {       
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDependency();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }



            app.UseStaticFiles();

            app.UseMvcWithDefaultRoute();
        }
    }
}
