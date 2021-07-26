using JA.Entity.MappingConfiguration;
using JA.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JA.Entity.MappingConfiguration
{
    public class HouseMapConfig : EntityMappingConfiguration<House>
    {
        public override void Map(EntityTypeBuilder<House>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

