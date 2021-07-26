using JA.Entity.MappingConfiguration;
using JA.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JA.Entity.MappingConfiguration
{
    public class TenantFeeRecordMapConfig : EntityMappingConfiguration<TenantFeeRecord>
    {
        public override void Map(EntityTypeBuilder<TenantFeeRecord>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

