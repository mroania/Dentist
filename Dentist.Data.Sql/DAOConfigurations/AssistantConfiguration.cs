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
    public class AssistantConfiguration : IEntityTypeConfiguration<Assistant>
    {
        public void Configure(EntityTypeBuilder<Assistant> builder)
        {
            builder.Property(a => a.AssistantName).IsRequired();
            builder.Property(a => a.AssistantSurname).IsRequired();
            builder.Property(a => a.Gender).IsRequired();
            builder.Property(a => a.Phone).IsRequired();
            builder.Property(a => a.Email).IsRequired();
            builder.ToTable("Assistant");
        }
    }
}
