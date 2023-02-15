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
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.Property(d => d.DoctorName).IsRequired();
            builder.Property(d => d.DoctorSurname).IsRequired();
            builder.Property(d => d.Gender).IsRequired();
            builder.Property(d => d.Phone).IsRequired();
            builder.Property(d => d.Email).IsRequired();
            builder.Property(d => d.Specialization).IsRequired();
            builder.ToTable("Doctor");
        }
    }
}
