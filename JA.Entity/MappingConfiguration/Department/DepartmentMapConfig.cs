using JA.Entity.MappingConfiguration;
using JA.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JA.Entity.MappingConfiguration
{
    public class DepartmentMapConfig : EntityMappingConfiguration<Department>
    {
        public override void Map(EntityTypeBuilder<Department>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

