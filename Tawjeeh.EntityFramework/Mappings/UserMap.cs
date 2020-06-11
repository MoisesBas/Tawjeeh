using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Tawjeeh.EntityModel;

namespace Tawjeeh.EntityFramework.Mappings
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            HasKey(a => a.Id);
            Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(a => a.UserTypeId).HasColumnType("bigint").IsOptional();
            Property(a => a.UserName).HasColumnType("varchar").HasMaxLength(100).IsOptional();
            Property(a => a.Password).HasColumnType("nvarchar").HasMaxLength(100).IsOptional();
            Property(a => a.FullName).HasColumnType("nvarchar").HasMaxLength(100).IsOptional();
            Property(a => a.OfficeNo).HasColumnType("nvarchar").HasMaxLength(100).IsOptional();
            Property(a => a.Department).HasColumnType("nvarchar").HasMaxLength(100).IsOptional();
            Property(a => a.JobTitle).HasColumnType("nvarchar").HasMaxLength(100).IsOptional();
            Property(a => a.MobileNo).HasColumnType("nvarchar").HasMaxLength(15).IsOptional();
            Property(a => a.Photo).HasColumnType("nvarchar").HasMaxLength(150).IsOptional();
            Property(a => a.Email).HasColumnType("nvarchar").HasMaxLength(100).IsOptional();
            Property(a => a.IsActive).HasColumnType("bit").IsOptional().HasColumnAnnotation("Default", 1);
            Property(a => a.IsDeleted).HasColumnType("bit").IsOptional().HasColumnAnnotation("Default", 0);
            Property(a => a.CreatedOn).HasColumnType("datetime").IsOptional().HasColumnAnnotation("Default", DateTime.Now);
            Property(a => a.CreatedBy).HasColumnType("bigint").IsOptional();
            Property(a => a.UpdatedOn).HasColumnType("datetime").IsOptional();
            Property(a => a.IsOTP).HasColumnType("bit").IsOptional().HasColumnAnnotation("Default", 0);
            Property(a => a.OTP).HasColumnType("nvarchar").HasMaxLength(10).IsOptional();
            Property(a => a.LangId).HasColumnType("int").IsOptional();
            Property(a => a.CountryId).HasColumnType("int").IsOptional();
            Property(a => a.CompanyId).HasColumnType("bigint").IsOptional();            
            Property(a=> a.Gender).HasColumnType("nvarchar").HasMaxLength(10).HasColumnAnnotation("Default","Male").IsOptional();
            HasOptional(t => t.UserTypes)
               .WithMany(t => t.Users)
               .HasForeignKey(d => d.UserTypeId);
            HasOptional(t => t.Country)
               .WithMany(t => t.Users)
               .HasForeignKey(d => d.CountryId);
            ToTable("tblUser");
        }
    }
}
