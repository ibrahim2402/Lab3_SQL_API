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
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Olakunle_Ibrahim_MS_API.Models;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System.Net;
using System.Net.Security;

namespace Olakunle_Ibrahim_MS_API
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
            try
            {
                var connection = Configuration.GetConnectionString("chateragent");
                services.AddDbContext<chateragent>(options => options.UseSqlServer(connection));

            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
        /*    try
            {
                services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

                //ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, SslPolicyErrors) => true;
                services.AddSingleton<IDocumentClient>(x => new DocumentClient(new Uri(Configuration["CosmosDB:URL"]), Configuration["CosmosDB:PrimaryKey"]));

            }
            catch (ArgumentNullException e)
            {
                throw e;
            }*/

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
