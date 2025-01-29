using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication.Domain.Entity;

namespace WebApplication.Infra.Data.EntitiesConfiguration
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Company");
            builder.HasKey(x => new { x.Identifier });

            builder.Property(c => c.Identifier).HasColumnName("COMPANYID");
            builder.Property(c => c.Name).HasColumnName("NAME");
            builder.Property(c => c.CNPJ).HasColumnName("CNPJ");

            //builder.HasOne(x => x.Association).WithMany(x => x.Company).HasForeignKey(x => new { x.Association.MemberId, x.Association.CompanyId });

            builder.HasMany(x => x.Association).WithOne(x => x.Company).HasForeignKey(x => x.CompanyId);
        }
    }
}
