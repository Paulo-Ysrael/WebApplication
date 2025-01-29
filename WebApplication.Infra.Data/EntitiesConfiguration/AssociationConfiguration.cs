using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Domain.Entity;

namespace WebApplication.Infra.Data.EntitiesConfiguration
{
    public class AssociationConfiguration : IEntityTypeConfiguration<Association>
    {
        public void Configure(EntityTypeBuilder<Association> builder)
        {
            builder.ToTable("Association");
            builder.HasKey(x => new { x.Identifier });

            builder.Property(c => c.Identifier).HasColumnName("ASSOCIATIONID");
            builder.Property(c => c.MembersId).HasColumnName("MEMBERSID");
            builder.Property(c => c.CompanyId).HasColumnName("COMPANYID");
        }
    }
}
