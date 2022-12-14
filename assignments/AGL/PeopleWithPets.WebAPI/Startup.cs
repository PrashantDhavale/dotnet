using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PeopleWithPets.Domain.Repository;
using PeopleWithPets.DataAccess.Repository;
using PeopleWithPets.DataAccess.Settings;

namespace PeopleWithPets.WebAPI
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
            services.Configure<RepositorySettings>(options => 
                                                    Configuration.GetSection("RepositorySettings").Bind(options)
                                                  );
            services.AddOptions();

            IEnumerable<string> corsOrigin = Configuration.GetSection("CORS:Origins").GetChildren().Select(co => co.Value);
            services.AddCors(options =>
                            {
                                options.AddPolicy("AllowSpecificOrigin",
                                                builder => builder
                                                            .WithOrigins(corsOrigin.ToArray())
                                                            .AllowAnyHeader()
                                                            .AllowAnyMethod()
                                                );
                            });
            services.AddMvc()
            .AddJsonOptions(options =>
                            {
                                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                                options.SerializerSettings.NullValueHandling = NullValueHandling.Include;
                            });
            InjectDependencies(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseCors("AllowSpecificOrigin");
            app.UseMvc();
        }

        private void InjectDependencies(IServiceCollection services)
        {
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddTransient<PeopleWithPetsRepository, HttpClientPeopleWithPetsRepository>();
        }
    }
}
