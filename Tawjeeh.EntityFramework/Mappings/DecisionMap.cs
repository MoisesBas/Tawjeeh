using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Tawjeeh.EntityModel;

namespace Tawjeeh.EntityFramework.Mappings
{
    public class DecisionMap : EntityTypeConfiguration<Decision>
    {
        public DecisionMap()
        {
            HasKey(a => a.Id);
            Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(a => a.Name).HasColumnType("nvarchar").IsRequired().HasMaxLength(50);
            Property(a => a.Description).HasColumnType("ntext").IsOptional();
            Property(a => a.DecisionNo).HasColumnType("nvarchar").IsOptional().HasMaxLength(100);
            Property(a => a.ArticleId).HasColumnType("bigint").IsOptional();
            Property(a => a.IsActive).HasColumnType("bit").IsOptional().HasColumnAnnotation("Default", 1);
            Property(a => a.IsDeleted).HasColumnType("bit").IsOptional().HasColumnAnnotation("Default", 0);
            Property(a => a.CreatedOn).HasColumnType("datetime").IsOptional().HasColumnAnnotation("Default", DateTime.Now);
            Property(a => a.CreatedBy).HasColumnType("bigint").IsOptional();
            Property(a => a.UpdatedOn).HasColumnType("datetime").IsOptional();
            Property(a => a.UpdatedBy).HasColumnType("bigint").IsOptional();            
            ToTable("tblDecision");
            HasOptional(a => a.Article).WithMany(a => a.Decisions).HasForeignKey(a => a.ArticleId).WillCascadeOnDelete(false);
           
        }
    }
}
