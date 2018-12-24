using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Http;
using GraphQL.Types;
using GraphQL101.Middleware;
using GraphQL101.Query;
using GraphQL101.Request;
using GraphQL101.Schema;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace GraphQL101
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
            services.AddSingleton<IDocumentWriter, DocumentWriter>();
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<GreetingQuery>();
            services.AddSingleton<ISchema, GreetingSchema>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // new GraphQL schema
            //app.Run(async (context) =>
            //{
            //    if (context.Request.Path.StartsWithSegments("/api/graphql")
            //   && string.Equals(context.Request.Method, "POST", StringComparison.OrdinalIgnoreCase))
            //    {
            //        string body;
            //        using (var streamReader = new StreamReader(context.Request.Body))
            //        {
            //            body = await streamReader.ReadToEndAsync();
            //            var request = JsonConvert.DeserializeObject<GraphQLRequest>(body);
            //            // GraphQL schema
            //            var schema = new Schema { Query = new GreetingQuery() };

            //            var result = await new DocumentExecuter().ExecuteAsync(doc =>
            //            {
            //                doc.Schema = schema;
            //                doc.Query = request.Query;
            //            }).ConfigureAwait(false);

            //            var json = new DocumentWriter(indent: true).Write(result);
            //            await context.Response.WriteAsync(json);
            //        }
            //    }
            //});

            app.UseMiddleware<GraphQLMiddleware>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
