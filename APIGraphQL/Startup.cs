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
using GraphQL;
using Newtonsoft;
using GraphQL.Server.Ui.Playground;
using APIGraphQL.Services;
using APIGraphQL.Schemas;
using APIGraphQL.Types;
using GraphQL.Server.Ui.Voyager;

namespace APIGraphQL
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
            services.AddSingleton<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddHttpClient<IChampionService, ChampionService>();
            services.AddSingleton<ChampionQuery>();
            services.AddSingleton<ChampionType>();
            services.AddSingleton<AbilityType>();
            services.AddSingleton<MainSchema>();

            services.AddCors(o => o.AddPolicy("MyPolicy", p =>
            {
                p.AllowAnyHeader();
                p.AllowAnyMethod();
                p.AllowAnyOrigin();
            }));

            services.AddControllers().AddNewtonsoftJson();
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

            app
                .UseCors("MyPolicy")
                .UseWebSockets()
                .UseGraphQLPlayground(new GraphQLPlaygroundOptions() { Path = "/graphql" })
                .UseGraphQLVoyager(new GraphQLVoyagerOptions() { Path = "/voyager" });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
