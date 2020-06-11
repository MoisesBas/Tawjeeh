
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Tawjeeh.EntityModel;

namespace Tawjeeh.EntityFramework.Mappings
{
    public class DecisionMultimediaMap : EntityTypeConfiguration<DecisionMultimedia>
    {
        public DecisionMultimediaMap()
        {
            HasKey(a => a.Id);
            Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(a => a.DecisionId).HasColumnType("bigint").IsOptional();
            Property(a => a.LangId).HasColumnType("int").IsOptional();
            Property(a => a.FileName).HasColumnType("nvarchar").IsOptional().HasMaxLength(150);
            Property(a => a.FileUrl).HasColumnType("nvarchar").IsOptional().HasMaxLength(150);
            Property(a => a.VideoUrl).HasColumnType("nvarchar").IsOptional().HasMaxLength(150);
            Property(a => a.FileType).HasColumnType("int").IsOptional();
            Property(a => a.CntDisLikes).HasColumnType("bigint").IsOptional();
            Property(a => a.CntLikes).HasColumnType("bigint").IsOptional();
            Property(a => a.CntViews).HasColumnType("bigint").IsOptional();
            Property(a => a.Description).HasColumnType("ntext").IsOptional();
            Property(a => a.IsMobile).HasColumnType("bit").IsOptional().HasColumnAnnotation("Default", 0);
            Property(a => a.IsActive).HasColumnType("bit").IsOptional().HasColumnAnnotation("Default", 1);
            Property(a => a.IsDeleted).HasColumnType("bit").IsOptional().HasColumnAnnotation("Default", 0);
            Property(a => a.CreatedOn).HasColumnType("datetime").IsOptional().HasColumnAnnotation("Default", DateTime.Now);
            Property(a => a.CreatedBy).HasColumnType("bigint").IsOptional();
            Property(a => a.UpdatedOn).HasColumnType("datetime").IsOptional();
            Property(a => a.UpdatedBy).HasColumnType("bigint").IsOptional();
            ToTable("tblDecisionMultimedia");
            HasOptional(a=> a.Decision).WithMany(a => a.MultimediaDecisions).HasForeignKey(d => d.DecisionId).WillCascadeOnDelete(false);
        }
    }
}
