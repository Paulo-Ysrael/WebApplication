using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication.Domain.Entity;

namespace WebApplication.Infra.Data.EntitiesConfiguration
{
    public class MembersConfiguration : IEntityTypeConfiguration<Members>
    {
        public void Configure(EntityTypeBuilder<Members> builder)
        {
            builder.ToTable("Members");
            builder.HasKey(x => new { x.Identifier });

            builder.Property(c => c.Identifier).HasColumnName("MEMBERSID");
            builder.Property(c => c.Name).HasColumnName("NAME");
            builder.Property(c => c.CPF).HasColumnName("CPF");
            builder.Property(c => c.Birth).HasColumnName("BIRTH");

            //builder.HasOne(x => x.Association).WithMany(a => a.Members).HasForeignKey(x => new { x.Association.MemberId, x.Association.CompanyId });

            builder.HasMany(x => x.Association).WithOne(x => x.Members).HasForeignKey(x => x.MembersId);
        }
    }
}
