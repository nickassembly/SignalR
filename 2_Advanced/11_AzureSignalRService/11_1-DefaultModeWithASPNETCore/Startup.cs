using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Scaffold.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // STEP 1: connection string to azure signalr service
            //    - Get from configuration! 
            var connectionString = "Endpoint=https://signalr-master-test1.service.signalr.net;AccessKey=F/PTOpqo/FtVWK0vwUtRT2EirFkVxvAaKNQxDatRzlg=;Version=1.0;";
            
            // STEP 2: Add Azure SignalR Server
            services.AddSignalR().AddAzureSignalR(connectionString);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseDefaultFiles(); //index.html
            app.UseStaticFiles();

            app.UseEndpoints(configure => {
                configure.MapHub<BackgroundColorHub>("/hub/background");
            });
        }
    }
}
