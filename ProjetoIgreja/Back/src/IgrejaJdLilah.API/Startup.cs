using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using IgrejaJdLilah.Persistence.Contexto;
using IgrejaJdLilah.Application.Contratos.IgrejaJdLilah;
using IgrejaJdLilah.Application.Servicos.IgrejaJdLilah;
using IgrejaJdLilah.Domain.Repository.Contrato;
using IgrejaJdLilah.Persistence.Repository;

namespace IgrejaJdLilah.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            //Acessa o APPService, sendo a abstracao do arquivo de configuração
            //appsetings.Develop
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Configuraçao para sql com Configuration
            services.AddDbContext<IgrejaJdLilahContext>(
                context => context.UseSqlite(Configuration.GetConnectionString("DefaultConnection"))
            );
            //Pelo nuget foi baixado o Microsoft.AspNetCore.Mvc.NewtonsoftJson vs5.0.3 para a API
            //Então será possivel usar o  AddNewtonsoftJson e espercificar para ignorar lops (referencia circular)
            //Em referencia de classes 
            services.AddControllers()
                    .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling =
                         Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    );



            //Aqui Especifico a referencia da injeção de dependia pelo controller
            services.AddScoped<IEventoApp, EventoApp>();
            services.AddScoped<IEventoRepository, EventoRepository>();

            

            //Permite configuração de acesso
            services.AddCors();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "IgrejaJdLilah.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "IgrejaJdLilah.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            //Resolve erro de acesso entre a camada web e a API
            app.UseCors(acesso => acesso.AllowAnyHeader()
                                        .AllowAnyMethod()
                                        .AllowAnyOrigin());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
