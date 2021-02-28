using Effectory.Questionnaire.Domain;
using Effectory.Questionnaire.Infrastructure.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Linq;

namespace Effectory.Questionnaire.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllers()
                .AddNewtonsoftJson();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Effectory.Questionnaire.Api", Version = "v1"});
            });
            
            services.AddDbContext<QuestionnaireDbContext>(options => options.UseInMemoryDatabase("Questionnaire"));

            services
                .AddSingleton<ILoadDataSource, DataSource>()
                .AddSingleton<IParseJson<JObject>, JsonParser>()
                .AddSingleton<IFindQuestionsBy, JsonFileRepository>()
                .AddScoped<ISaveUserResponse, InMemoryDbRepository>()
                .AddScoped<ICalculateResult, InMemoryDbRepository>();
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Effectory.Questionnaire.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}