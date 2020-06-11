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
   public class CampaignDetailMap: EntityTypeConfiguration<CampaignDetail>
    {
        public CampaignDetailMap()
        {
            HasKey(a => a.Id);
            Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.CampaignId).HasColumnType("bigint").IsOptional();
            Property(t => t.Type).HasColumnType("int").IsOptional();
            Property(t => t.SubTypeId).HasColumnType("bigint").IsOptional();
            Property(t => t.MultimediaId).HasColumnType("bigint").IsOptional();
            Property(t => t.Others).HasColumnType("nvarchar").IsOptional();
            Property(a => a.IsActive).HasColumnType("bit").IsOptional().HasColumnAnnotation("Default", 1);
            Property(a => a.IsDeleted).HasColumnType("bit").IsOptional().HasColumnAnnotation("Default", 0);
            Property(a => a.CreatedOn).HasColumnType("datetime").IsOptional().HasColumnAnnotation("Default", DateTime.Now);
            Property(a => a.CreatedBy).HasColumnType("bigint").IsOptional();
            Property(a => a.UpdatedOn).HasColumnType("datetime").IsOptional();
            Property(a => a.UpdatedBy).HasColumnType("bigint").IsOptional();
            ToTable("tblCampaignDetails");
            HasOptional(t => t.Campaign)
                .WithMany(t => t.CampaignDetails)
                .HasForeignKey(d => d.CampaignId).WillCascadeOnDelete(false);
        }
    }
}
