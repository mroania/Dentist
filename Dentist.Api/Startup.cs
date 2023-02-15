using FluentValidation;
using FluentValidation.AspNetCore;
using Dentist.Data.Sql;
using Dentist.Data.Sql.Migrations;
using Dentist.Data.Sql.Patient;
using Dentist.Data.Sql.Appointment;
using Dentist.Api.BindingModels;
using Dentist.Api.Middlewares;
using Dentist.Api.Validation;
using Dentist.IData.Patient;
using Dentist.IData.Appointment;
using Dentist.IServices.Patient;
using Dentist.IServices.Appointment;
using Dentist.Services.Patient;
using Dentist.Services.Appointment;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Dentist.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DentistDbContext>(options => options
                .UseMySQL(Configuration.GetConnectionString("DentistDbContext")));
            services.AddTransient<DatabaseSeed>();
            services.AddControllers().AddNewtonsoftJson(options => {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            })
                .AddFluentValidation();
            services.AddTransient<IValidator<EditPatient>, EditPatientValidator>();
            services.AddTransient<IValidator<CreatePatient>, CreatePatientValidator>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IPatientRepository, PatientRepository>();

            services.AddTransient<IValidator<EditAppointment>, EditAppointmentValidator>();
            services.AddTransient<IValidator<CreateAppointment>, CreateAppointmentValidator>();
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();

            services.AddApiVersioning(o =>
            {
                o.ReportApiVersions = true;
                o.UseApiBehavior = false;
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<DentistDbContext>();
                var databaseSeed = serviceScope.ServiceProvider.GetRequiredService<DatabaseSeed>();

                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                databaseSeed.Seed();

                app.UseMiddleware<ErrorHandlerMiddleware>();
                app.UseRouting();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
            }
        }
    }
}
