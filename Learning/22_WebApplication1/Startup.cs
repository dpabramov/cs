using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace _22_WebApplication1
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //подключаем технологию MVC и опционально устанавливаем совместимую версию
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                //для ответа в том формате в котором попросили в заголовке Accept
                .AddMvcOptions(o => o.OutputFormatters
                .Add(new XmlDataContractSerializerOutputFormatter()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStatusCodePages();

            //app.UseMvc(config => config.MapRoute(
            //        name: "Default",
            //        template: "api/{controller}/{action}/{id?}",
            //        defaults: new
            //            {
            //                controller = "cities",
            //                action = "GetCities"
            //            }));

            app.UseMvc();
        }
    }
}
