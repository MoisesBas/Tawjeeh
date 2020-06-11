using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tawjeeh.EntityModel;

namespace Tawjeeh.EntityFramework.Mappings
{
  public  class InitiativeMap: EntityTypeConfiguration<Initiative>
    {
        public InitiativeMap()
        {
            HasKey(t => t.Id);
            Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            ToTable("tblInitiative");
            Property(a => a.Id).HasColumnName("Id");
            Property(a => a.InitiativeTypeId).HasColumnType("bigint").IsOptional();
            Property(a => a.Title).HasColumnType("nvarchar").HasMaxLength(150).IsOptional();
            Property(a => a.Description).HasColumnType("nvarchar").HasMaxLength(150).IsOptional();
            Property(a => a.IsActive).HasColumnType("bit").IsOptional().HasColumnAnnotation("Default", 1);
            Property(a => a.IsDeleted).HasColumnType("bit").IsOptional().HasColumnAnnotation("Default", 0);
            Property(a => a.CreatedOn).HasColumnType("datetime").IsOptional().HasColumnAnnotation("Default", DateTime.Now);
            Property(a => a.CreatedBy).HasColumnType("bigint").IsOptional();
            Property(a => a.UpdatedOn).HasColumnType("datetime").IsOptional();
            Property(a => a.UpdatedBy).HasColumnType("bigint").IsOptional();
        }
    }
}
