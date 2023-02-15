using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dentist.Data.Sql.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dentist.Data.Sql.DAOConfigurations
{
    //Klasa konfiguracyjna encji Appointment
    public class AppointmentConfiguration : IEntityTypeConfiguration<DAO.Appointment>
    {
        public void Configure(EntityTypeBuilder<DAO.Appointment> builder)
        {
            builder.HasOne(a => a.Patient)
                .WithMany(a => a.Appointments)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(a => a.PatientId);
            builder.HasOne(a => a.Doctor)
                .WithMany(a => a.Appointments)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(a => a.DoctorId);
            builder.HasOne(a => a.Assistant)
                .WithMany(a => a.Appointments)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(a => a.AssistantId);

            builder.Property(a => a.ApDate).IsRequired();
            builder.Property(a => a.ApTime).IsRequired();

            //Wymuszenie nazwy encji
            builder.ToTable("Appointment");
        }
    }
}
