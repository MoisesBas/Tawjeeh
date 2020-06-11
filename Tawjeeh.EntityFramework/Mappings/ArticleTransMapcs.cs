using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Tawjeeh.EntityModel;

namespace Tawjeeh.EntityFramework.Mappings
{
    public class ArticleTransMap : EntityTypeConfiguration<ArticleTrans>
    {
        public ArticleTransMap()
        {
            HasKey(a => a.Id);
            Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(a => a.Name).HasColumnType("nvarchar").IsRequired().HasMaxLength(150);
            Property(a => a.Description).HasColumnType("NTEXT").IsOptional();
            Property(a => a.ArticleId).HasColumnType("bigint").IsOptional();
            Property(a => a.ArticleNo).HasColumnType("nvarchar").IsOptional().HasMaxLength(100);
            Property(a => a.LangId).HasColumnType("int").IsOptional();
            Property(a => a.IsActive).HasColumnType("bit").IsOptional().HasColumnAnnotation("Default", 1);
            Property(a => a.IsDeleted).HasColumnType("bit").IsOptional().HasColumnAnnotation("Default", 0);
            Property(a => a.CreatedOn).HasColumnType("datetime").IsOptional().HasColumnAnnotation("Default", DateTime.Now);
            Property(a => a.CreatedBy).HasColumnType("bigint").IsOptional();
            Property(a => a.UpdatedOn).HasColumnType("datetime").IsOptional();                     
            ToTable("tblArticleTrans");
            HasOptional(a => a.Article).WithMany(a => a.ArticleTranslations).HasForeignKey(d => d.ArticleId).WillCascadeOnDelete(false);
        }
    }
}
