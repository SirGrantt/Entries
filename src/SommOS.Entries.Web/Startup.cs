using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.GraphiQL;
using GraphQL.Server.Ui.Playground;
using GraphQL.Server.Ui.Voyager;
using GraphQL.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SommOS.Entries.Infrastructure.DbContexts;
using SommOS.Entries.Web.ApiSchema;
using SommOS.Entries.Web.Auth;

namespace SommOS.Entries.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }

        public IHostingEnvironment _hostingEnvironment;
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var connectionString = Configuration["ConnectionStrings:SommOSEntries"];

            services.AddDbContext<EntriesContext>(o => o.UseNpgsql(connectionString));

            services.AddScoped<IDependencyResolver>(
               c => new FuncDependencyResolver(type =>
               c.GetRequiredService(type)));

            services.AddGraphQL(_ =>
            {
                _.EnableMetrics = true;
                _.ExposeExceptions = true;
            }).AddWebSockets()
            .AddDataLoader()
            .AddUserContextBuilder(context => new GraphQLUserContext { User = context.User });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var validationRules = app.ApplicationServices.GetService<IValidationRule>();

            app.UseWebSockets();
            app.UseGraphQLWebSockets<EntriesSchema>();

            // Summary:
            //  There should be one endpoint "/graphql" that handles all of the services queries and mutations.
            app.UseGraphQL<EntriesSchema>("/graphql");

            if (env.IsDevelopment())
            {
                app.UseGraphiQLServer(new GraphiQLOptions());
                app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
                app.UseGraphQLVoyager(new GraphQLVoyagerOptions());
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc();
        }
    }
}
