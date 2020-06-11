using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Tawjeeh.EntityModel;

namespace Tawjeeh.EntityFramework.Mappings
{
    public class InitiativeCampaignMap: EntityTypeConfiguration<InitiativeCampaign>
    {
        public InitiativeCampaignMap()
        {
            HasKey(a => a.Id);
            Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.CampaignId).HasColumnType("bigint").IsOptional();
            Property(t => t.InitiativeId).HasColumnType("bigint").IsOptional();
            Property(t => t.StartDateTime).HasColumnType("datetime").IsOptional();
            Property(t => t.Result).HasColumnType("nvarchar").IsOptional();
            Property(t => t.EvidenceResult).HasColumnType("nvarchar").IsOptional();
            Property(t => t.EvidenceName).HasColumnType("nvarchar").IsOptional();
            Property(t => t.StartDate).HasColumnType("datetime").IsOptional();
            Property(t => t.EndDate).HasColumnType("datetime").IsOptional();
            Property(t => t.Description).HasColumnType("nvarchar").IsOptional();
            Property(t => t.Target).HasColumnType("nvarchar").IsOptional();
            Property(a => a.IsActive).HasColumnType("bit").IsOptional().HasColumnAnnotation("Default", 1);
            Property(a => a.IsDeleted).HasColumnType("bit").IsOptional().HasColumnAnnotation("Default", 0);
            Property(a => a.CreatedOn).HasColumnType("datetime").IsOptional().HasColumnAnnotation("Default", DateTime.Now);
            Property(a => a.CreatedBy).HasColumnType("bigint").IsOptional();
            Property(a => a.UpdatedOn).HasColumnType("datetime").IsOptional();
            Property(a => a.UpdatedBy).HasColumnType("bigint").IsOptional();
            ToTable("tblInitiativeCampaign");
            HasOptional(a => a.Campaign).WithMany(a => a.InitiativeCampaigns).HasForeignKey(a => a.CampaignId).WillCascadeOnDelete(false);
            HasOptional(a => a.Initiative).WithMany(a => a.InitiativeCampaigns).HasForeignKey(a => a.InitiativeId).WillCascadeOnDelete(false);
        }
    }
}
