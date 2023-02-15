using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dentist.Data.Sql.DAO;
using Dentist.Data.Sql.DAOConfigurations;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace Dentist.Data.Sql
{
    public class DentistDbContext : DbContext
    {
        public DentistDbContext(DbContextOptions<DentistDbContext> options) : base(options) {}

        //Ustawienie klas z folderu DAO jako tabele bazy danych
        public virtual DbSet<DAO.Patient> Patient { get; set; }
        public virtual DbSet<Doctor> Doctor { get; set; }
        public virtual DbSet<Assistant> Assistant { get; set; }
        public virtual DbSet<DAO.Appointment> Appointment { get; set; }
        public virtual DbSet<Treatment> Treatment { get; set; }
        public virtual DbSet<AppointmentTreatment> AppointmentTreatment { get; set; }

        //Przykład konfiguracji modeli/encji poprzez klasy konfiguracyjne z folderu DAOConfigurations
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PatientConfiguration());
            builder.ApplyConfiguration(new DoctorConfiguration());
            builder.ApplyConfiguration(new AssistantConfiguration());
            builder.ApplyConfiguration(new AppointmentConfiguration());
            builder.ApplyConfiguration(new TreatmentConfiguration());
            builder.ApplyConfiguration(new AppointmentTreatmentConfiguration());
        }
    }
}
