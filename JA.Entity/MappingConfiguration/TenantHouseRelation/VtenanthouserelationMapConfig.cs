using JA.Entity.MappingConfiguration;
using JA.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JA.Entity.MappingConfiguration
{
    public class VtenanthouserelationMapConfig : EntityMappingConfiguration<Vtenanthouserelation>
    {
        public override void Map(EntityTypeBuilder<Vtenanthouserelation>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

