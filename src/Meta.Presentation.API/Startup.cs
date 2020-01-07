using Meta.CrossCutting.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System.IO.Compression;

namespace Meta.Presentation.API
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
            services.Configure<GzipCompressionProviderOptions>(
                    options => options.Level = CompressionLevel.Optimal);

            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
                options.EnableForHttps = false;
                
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(opcoes =>
                {
                    opcoes.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                });

            RegisterServices(services, Configuration);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "API para um serviço de gestão de contatos",
                        Version = "v1",
                        Description = "Projeto desenvolvido com .NET CORE",
                        Contact = new Contact
                        {
                            Name = "Luiz Guilherme Bandeira",
                            Url = "https://www.linkedin.com/in/lbandeira/",
                            Email = "arkanael@gmail.com"
                        },
                        License = new License
                        {
                            Name = "MIT License",
                            Url = "https://opensource.org/licenses/MIT"
                           
                        }

                    }); ;
            });

            services.AddCors(c => c.AddPolicy("DefaultPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyHeader()
                       .AllowAnyMethod();
            }));


        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "Meta");

            });

            app.UseCors("DefaultPolicy");
        }

        private static void RegisterServices(IServiceCollection services, IConfiguration Configuration)
        {
            NativeInjectorBootStrapper.Register(services, Configuration);
        }
    }
}
