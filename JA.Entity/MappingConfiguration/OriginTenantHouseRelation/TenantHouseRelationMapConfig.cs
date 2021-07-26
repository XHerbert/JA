using JA.Entity.MappingConfiguration;
using JA.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JA.Entity.MappingConfiguration
{
    public class TenantHouseRelationMapConfig : EntityMappingConfiguration<TenantHouseRelation>
    {
        public override void Map(EntityTypeBuilder<TenantHouseRelation>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

