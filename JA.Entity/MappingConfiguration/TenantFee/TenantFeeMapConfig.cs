using JA.Entity.MappingConfiguration;
using JA.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JA.Entity.MappingConfiguration
{
    public class TenantFeeMapConfig : EntityMappingConfiguration<TenantFee>
    {
        public override void Map(EntityTypeBuilder<TenantFee>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

