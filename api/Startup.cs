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
using core.interfaces;
using core.models;
using infrastructure.data;
using api.Middleware;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;
using api.Services;
using FluentMigrator.Runner;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace api
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

            // Get connetion string from configuration file to global use
            var connectionString = new ConnectionString(Configuration.GetConnectionString("DefaultConnection"));
            services.AddSingleton(connectionString);

            // Client url 
            var clientURL = new ClientURL(Configuration.GetValue<string>("ClientURL"));
            services.AddSingleton(clientURL);

            //Configuration Migrator
            /*services.AddFluentMigratorCore()
                .ConfigureRunner(config =>
                    config.AddSqlServer()
                    .WithGlobalConnectionString(Configuration.GetConnectionString("DefaultConnection"))
                    .ScanIn(Assembly.GetExecutingAssembly()).For.All())
                    .AddLogging(config => config.AddFluentMigratorConsole());
            */

            // Get mail remitent 
            //var fromMail = new FromMail(Configuration.GetValue<string>("FromMail"));
            //services.AddSingleton(fromMail);

            // Get Firebase keys 
            var firebaseKeys = new FirebaseKey() {
                FirebaseServerKeyToken = Configuration.GetValue<string>("FirebaseServerKeyToken"), 
                FirebaseSenderID = Configuration.GetValue<string>("FirebaseSenderID"), 
                FirebaseURL = Configuration.GetValue<string>("FirebaseURL")
            };
            services.AddSingleton(firebaseKeys);

            // File routes 
            var fileRoutes = new FileRoutes()
            {
                PhysicalFolderPrivate = Configuration.GetValue<string>("physicalFolderPrivate"), 
                PhysicalFolder = Configuration.GetValue<string>("physicalFolder"), 
                WebFolder = Configuration.GetValue<string>("webFolder"),
                PhysicalUploadsFolder = Configuration.GetValue<string>("physicalUploadsFolder"),
                WebUploadsFolder = Configuration.GetValue<string>("webUploadsFolder")
            };
            services.AddSingleton(fileRoutes);

            // Registrer objects for injection dependency
                    
            /*
            services.AddScoped <IClienteRepository, ClienteRepository>();
            services.AddScoped <IProspectoRepository, ProspectoRepository>();
            services.AddScoped<IModuloRolRepository, ModuloRolRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRolRepository, RolRepository>();
            services.AddScoped<IDireccionEntregaRepository, DireccionEntregaRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IComunicacionRepository, ComunicacionRepository>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IUnidadMedidaRepository, UnidadMedidaRepositoty>();
            services.AddScoped<IPedidoDetalleRepository, PedidoDetalleRepository>();
            services.AddScoped<ITipoNotificacionRepository, TipoNotificacionRepository>();
            services.AddScoped<ITipoMonedaRepository, TipoMonedaRepository>();
            services.AddScoped<ICategoriaProductoRepository, CategoriaProductoRepository>();
            services.AddScoped<ISubcategoriaProductoRepository, SubcategoriaProductoRepository>();
            services.AddScoped<IRolTraduccionRepository, RolTraduccionRepository>();
            services.AddScoped<ITipoMonedaRepository, TipoMonedaRepository>();
            services.AddScoped<IUnidadMedidaRepository, UnidadMedidaRepositoty>();
            services.AddScoped<ITipoNotificacionRepository, TipoNotificacionRepository>();
            services.AddScoped<ICategoriaProductoRepository, CategoriaProductoRepository>();
            services.AddScoped<ISubcategoriaProductoRepository, SubcategoriaProductoRepository>();
            services.AddScoped<IIdiomaRepository, IdiomaRepository>();
            services.AddScoped<IReclamacionRepository, ReclamacionRepository>();
            services.AddScoped<IMailConfigurationRepository, MailConfigurationRepository>();
            services.AddScoped<IContactoClienteRepository, ContactoClienteRepository>();
            services.AddScoped<IProductoRepository, ProductoRepository>();
            services.AddScoped<ITipoDocumentoPedidoRepository, TipoDocumentoPedidoRepository>();
            services.AddScoped<ICaracteristicasProductoRepository, CaracteristicasProductoRepository>();
            services.AddScoped<IDeclinacionPedidoRepository, DeclinacionPedidoRepository>();
            services.AddScoped<IPropiedadFamiliaProductoRepository, PropiedadFamiliaProductoRepository>();
            services.AddScoped<IHorarioIngresoPedidoRepository, HorarioIngresoPedidoRepository>();
            services.AddScoped<IConfiguracionNotificacionesRepository, ConfiguracionNotificacionesRepository>();
            services.AddScoped<IFamiliaProductoRepository, FamiliaProductoRepository>();
            services.AddScoped<ITipoDocumento, TipoDocumentoRepository>();
            services.AddScoped<IGrupoPropiedadFamiliaProductoRepository, GrupoPropiedadFamiliaProductoRepository>();
            services.AddScoped<IDeclinacionTraduccionRepositoy, DeclinacionTraduccionRepository>();
            services.AddScoped<IProductoCaracteristicasRepository, ProductoCaracteristicasRepository>();
            services.AddScoped<ICategoriaTraduccionRepository, CategoriaTraduccionRepository>();
            services.AddScoped<ITipoNoificacionTraduccionRepository, TipoNotificacionTraduccionRepository>();
            services.AddScoped<INotificacionWebRepository, NotificacionWebRepository>();
            services.AddScoped<IPedidoDocumentoRepository, PedidoDocumentoRepository>();
            services.AddScoped<IFacturacionClienteRepository, FacturacionClienteRepository>();
            services.AddScoped<IPartidaTrackingRepository, PartidaTrackingRepository>();
            services.AddScoped<IEstadoCuentaRepository, EstadoCuentaRepository>();
            */

            services.AddScoped<IRegistroRepository, RegistroRepository>();
            services.AddScoped<IEspecialidadRepository, EspecialidadRepository>();
            services.AddScoped<IConvenioRepository, ConvenioRepository>();

            /*
            services.AddScoped<IUserService, MockUserService>();
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<IPushNotificationService, PushNotificationService>();

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();*/
            
            // Get token properties from configuration file
            services.AddTokenAuthentication(Configuration);

            // Register the Swagger Generator service. This service is responsible for genrating Swagger Documents.
            // Note: Add this service at the end after AddMvc() or AddMvcCore().
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "ReDi API",
                    Version = "v1",
                    Description = "API for ReDi Platform",
                    Contact = new OpenApiContact
                    {
                        Name = "Janeth Vazquez",
                        Email = "janeth.vazquez@scadna.com.mx",
                        Url = new Uri("https://bons-ai.mx/"),
                    },
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger(options =>
            {
                options.RouteTemplate = "docs/{documentName}/docs.json";
            });

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/docs/v1/docs.json", "ReDi API V1");

                // To serve SwaggerUI at application's root page, set the RoutePrefix property to an empty string.
                c.RoutePrefix = "docs";
            });

            // app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            /*
            //Configuration Migrator
            using var scope = app.ApplicationServices.CreateScope();
            var migrator = scope.ServiceProvider.GetService<IMigrationRunner>();
            //migrator.ListMigrations();
            migrator.MigrateUp();*/
        }
    }
}
     