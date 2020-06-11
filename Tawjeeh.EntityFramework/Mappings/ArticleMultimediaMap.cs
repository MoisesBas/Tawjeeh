using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Tawjeeh.EntityModel;

namespace Tawjeeh.EntityFramework.Mappings
{
    public class ArticleMultimediaMap : EntityTypeConfiguration<ArticleMultimedia>
    {
        public ArticleMultimediaMap()
        {
            HasKey(a => a.Id);
            Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(a => a.ArticleId).HasColumnType("bigint").IsOptional();
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
            ToTable("tblArticleMultimedia");
            HasOptional(a => a.Article).WithMany(a => a.MultimediaArticles).HasForeignKey(d => d.ArticleId).WillCascadeOnDelete(false);
        }
    }
}
