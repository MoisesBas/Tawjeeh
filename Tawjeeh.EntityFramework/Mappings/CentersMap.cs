using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Tawjeeh.EntityModel;

namespace Tawjeeh.EntityFramework.Mappings
{
    public class CentersMap : EntityTypeConfiguration<Centers>
    {
        public CentersMap()
        {
            HasKey(a => a.Id);
            Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            ToTable("tblCenters");
            Property(a => a.Name).HasColumnType("nvarchar").HasMaxLength(100).IsOptional();
            Property(a => a.LocationAddress).HasColumnType("nvarchar").HasMaxLength(100).IsOptional();
            Property(a => a.EmiratesId).HasColumnType("bigint").IsOptional();
            Property(a => a.TradeLicense).HasColumnType("nvarchar").HasMaxLength(100).IsOptional();
            Property(a => a.TradeLicenseExpiryDate).HasColumnType("datetime").IsOptional();
            Property(a => a.FaxNo).HasColumnType("nvarchar").HasMaxLength(50).IsOptional();
            Property(a => a.PhoneNo).HasColumnType("nvarchar").HasMaxLength(50).IsOptional();
            Property(a => a.WebSite).HasColumnType("nvarchar").HasMaxLength(50).IsOptional();
            Property(a => a.Email).HasColumnType("nvarchar").HasMaxLength(50).IsOptional();
            Property(a => a.Longitude).HasColumnType("float").IsOptional();
            Property(a => a.Latitude).HasColumnType("float").IsOptional();
            Property(a => a.IsActive).HasColumnType("bit").IsOptional().HasColumnAnnotation("Default", 1);
            Property(a => a.IsDeleted).HasColumnType("bit").IsOptional().HasColumnAnnotation("Default", 0);
            Property(a => a.CreatedOn).HasColumnType("datetime").IsOptional().HasColumnAnnotation("Default", DateTime.Now);
            Property(a => a.CreatedBy).HasColumnType("bigint").IsOptional();
            Property(a => a.UpdatedOn).HasColumnType("datetime").IsOptional();
            Property(a => a.UpdatedBy).HasColumnType("bigint").IsOptional();
            HasOptional(t => t.Emirates)
                .WithMany(t => t.Centers)
                .HasForeignKey(d => d.EmiratesId).WillCascadeOnDelete(false);
            //HasMany(a=>a.Contacts).WithOptional(a => a.Centers).HasForeignKey(a => a.CenterId).WillCascadeOnDelete(true);
            //HasMany(a => a.CenterTrans).WithOptional(a => a.Centers).HasForeignKey(a => a.CenterId).WillCascadeOnDelete(true);
            
        }
       
    }
}
