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
    public class PatientConfiguration : IEntityTypeConfiguration<DAO.Patient>
    {
        public void Configure(EntityTypeBuilder<DAO.Patient> builder)
        {
            builder.Property(p => p.PatientName).IsRequired();
            builder.Property(p => p.PatientSurname).IsRequired();
            builder.Property(p => p.Gender).IsRequired();
            builder.Property(p => p.BirthDate).IsRequired();
            builder.Property(p => p.Phone).IsRequired();
            builder.Property(p => p.City).IsRequired();
            builder.Property(p => p.Street).IsRequired();
            builder.Property(p => p.HouseNumber).IsRequired();
            builder.ToTable("Patient");
        }
    }
}
