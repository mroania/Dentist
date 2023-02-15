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
    public class AppointmentTreatmentConfiguration : IEntityTypeConfiguration<AppointmentTreatment>
    {
        public void Configure(EntityTypeBuilder<AppointmentTreatment> builder)
        {
            builder.HasOne(x => x.Appointment)
                .WithMany(x => x.AppointmentTreatments)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.AppointmentId);
            builder.HasOne(x => x.Treatment)
                .WithMany(x => x.AppointmentTreatments)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.TreatmentId);

            builder.ToTable("AppointmentTreatment");
        }
    }
}
